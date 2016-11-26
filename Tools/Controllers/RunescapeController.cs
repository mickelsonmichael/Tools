using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Tools.Models;

namespace Tools.Controllers
{
    public class RunescapeController : Controller
    {
        // GET: Runescape
        public ActionResult Index()
        {
            WebClient client = new WebClient();
            string downloadString = client.DownloadString("http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=rens0n");
            downloadString = downloadString.Replace('\n', ';');
            List<Skills.SkillData> skills = Skills.GetSkills("rens0n");

            PlayerData data = PlayerData.GetPlayer("rens0n");

            return View(data);
        }

        public ActionResult ViewSkills()
        {
            //WebClient client = new WebClient();
            //string downloadString = client.DownloadString("http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=rens0n");
            //downloadString = downloadString.Replace('\n', ';');
            //List<Skills.SkillData> skills = Skills.UpdateSkills("rens0n", downloadString);

            List<Skills.SkillData> skills = Skills.GetSkills("rens0n");

            return View(skills);
        }

        public ActionResult ViewQuests()
        {
            return View();
        }

        public PartialViewResult QuestRequirements(string data)
        {
            string url = "http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=doctorrenson";
            List<Skills> obj = (new JavaScriptSerializer()).Deserialize<List<Skills>>(data); 
            return PartialView(obj);
        }

        public ActionResult Update(string username, string data)
        {
            RunescapeDataContext db = new RunescapeDataContext();

            Player playerToUpdate = db.Players.Where(a => a.RS_Username == username).FirstOrDefault();
            string[] skillsRaw = data.Split(';');
            string[] order = {
                "Overall", "Attack", "Defense", "Strength", "Hitpoints", "Ranged", "Prayer", "Magic", "Cooking", "Woodcutting", "Fletching", "Fishing", "Firemaking", "Crafting", "Smithing", "Mining",
                "Herblore", "Agility", "Thieving", "Slayer", "Farming", "Runecraft", "Hunter", "Construction" };

            // Player already exists, update the data
            if (playerToUpdate != null)
            {
                int skillIndex = 0; //Keeps track of the skill order
                foreach (string skill in order)
                {
                    if (skillIndex < order.Length) // Make sure not to overflow into Bounty Hunder + LMS
                    {
                        string[] stats = skillsRaw[skillIndex].Split(',');
                        string skillName = skill,
                            skillRank = stats[0],
                            skillLevel = stats[1],
                            skillExp = stats[2];

                        // Update the values in the database
                        Skill sk = db.Skills.Where(a => a.Name == skill).FirstOrDefault();
                        PlayerSkill ps = db.PlayerSkills.Where(a => a.SkillID == sk.SkillID && a.PlayerID == playerToUpdate.PlayerID).FirstOrDefault();

                        if (ps == null) // If no entry exists for the player
                        {
                            ps = new PlayerSkill();
                            ps.PlayerID = playerToUpdate.PlayerID;
                            ps.SkillID = db.Skills.Where(a => a.Name == skill).FirstOrDefault().SkillID;
                        }

                        ps.Rank = Convert.ToInt32(skillRank);
                        ps.Level = Convert.ToInt32(skillLevel);
                        ps.Exp = Convert.ToInt32(skillExp);

                        skillIndex++;
                    }
                }
                db.SubmitChanges();
            }
            // Create new Player in the DB
            else
            {
                playerToUpdate = new Player();
                playerToUpdate.RS_Username = username;
                db.Players.InsertOnSubmit(playerToUpdate);
                db.SubmitChanges();

                int skillIndex = 0; //Keeps track of the skill order
                foreach (string skill in order)
                {
                    if (skillIndex < order.Length) // Make sure not to overflow into Bounty Hunder + LMS
                    {
                        string[] stats = skillsRaw[skillIndex].Split(',');
                        string skillName = skill,
                            skillRank = stats[0],
                            skillLevel = stats[1],
                            skillExp = stats[2];

                        // Create the association with the skill
                        PlayerSkill ps = new PlayerSkill();
                        ps.Rank = Convert.ToInt32(skillRank);
                        ps.Level = Convert.ToInt32(skillLevel);
                        ps.Exp = Convert.ToInt32(skillExp);
                        ps.PlayerID = playerToUpdate.PlayerID;
                        ps.SkillID = db.Skills.Where(a => a.Name == skillName).FirstOrDefault().SkillID;

                        skillIndex++;
                        db.PlayerSkills.InsertOnSubmit(ps);
                    }
                }
                db.SubmitChanges();
            }

            return Content("Successfully updated the user!");
        }

        public JsonResult UpdateQuest(bool newValue, string questid)
        {
            string currentUser = "rens0n"; // Change later if adding users db

            RunescapeDataContext db = new RunescapeDataContext();
            Player p = db.Players.Where(a => a.RS_Username == currentUser).FirstOrDefault();

            if (p != null)
            {
                PlayerQuest q = db.PlayerQuests.Where(a => a.PlayerID == p.PlayerID && a.QuestID == Convert.ToInt32(questid)).FirstOrDefault();
                if (q != null)
                {
                    q.Status = newValue;
                    db.SubmitChanges();
                    return Json("Succesful change!");
                }

                else
                {
                    return Json("No quest matches the id given. PlayerID = " + p.PlayerID + ", QuestID = " + questid);
                }
            }

            else
            {
                return Json("No user was found");
            }
        }
    }
}
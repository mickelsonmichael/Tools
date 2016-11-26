using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Tools.Models
{
    public class Skills
    {
        public class SkillData
        {
            public Skill skill { get; set; }
            public int level { get; set; }
            public int experience { get; set; }
            public int rank { get; set; }
            public string name { get; set; }
            public int questreq { get; set; }
            public int diaryreq { get; set; }
            public decimal questprogress { get; set; }
            public decimal diaryprogress { get; set; }
            public decimal levelprogress { get; set; }

            public SkillData()
            {
                skill = null;
                level = 1;
                experience = 0;
                rank = -1;
                name = "";
                questreq = 1;
                diaryreq = 1;
                questprogress = 0;
                diaryprogress = 0;
            }
        }
        

        /// <summary>
        /// Gather the information on a particular username and save it to the database.
        /// This is a temporary funtion
        /// TODO: Replace this with a simple web api lookup and return
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>A list of Skills</returns>
        public static List<SkillData> GetSkills(string username)
        {
            RunescapeDataContext db = new RunescapeDataContext();
            Player playerToFind = db.Players.Where(a => a.RS_Username == username).FirstOrDefault(); // TODO: Find player based on login info  with GetSkills(void)
            List<SkillData> toReturn = new List<SkillData>(); // Create empty list
            UpdateSkills(username);

            // If the player exists in the database
            if (playerToFind != null)
            {
                // Gather the info for each skill
                foreach (Skill skill in db.Skills)
                {
                    string skillName = skill.Name;
                    PlayerSkill ps = db.PlayerSkills.Where(a => a.PlayerID == playerToFind.PlayerID && a.SkillID == skill.SkillID).FirstOrDefault();
                    SkillData sD = new SkillData();
                    sD.level = (int)ps.Level;
                    sD.experience = (int)ps.Exp;
                    sD.rank = (int)ps.Rank;
                    sD.questreq = (int)skill.MinimumQuestRequirement;
                    sD.diaryreq = (int)skill.MinimumDiaryRequirement;
                    sD.name = skill.Name;
                    sD.skill = skill;

                    //Quest progress
                    sD.questprogress = sD.level / sD.questreq;
                    sD.diaryprogress = sD.level / sD.diaryreq;
                    sD.levelprogress = 100; // Default value is 100% for Overall

                    if (sD.name != "Overall" && sD.level < 99)
                    {
                        Level nl = db.Levels.Where(a => a.Value == sD.level+1).FirstOrDefault();
                        Level ll = db.Levels.Where(a => a.Value == sD.level).FirstOrDefault();
                        sD.levelprogress = Math.Round(((decimal)sD.experience - ll.Experience) / ((decimal)nl.Experience - ll.Experience) * 100, 2);
                        if (sD.levelprogress > 100)
                        {
                            sD.levelprogress = 100;
                        }
                    }

                    toReturn.Add(sD); // Add the skill to the output list
                }
                return toReturn;
            }

            // Player does not exist, will need to create it
            else
            {
                PlayerData.CreatePlayer(username);
                return GetSkills(username); // Recursive call on the newly created data
            }
            
        }

        public static bool UpdateSkills(string username)
        {
            RunescapeDataContext db = new RunescapeDataContext();
            // The order that the skills will be recieved by Runscape API. THIS ORDER MATTERS
            string[] order = { "Overall", "Attack", "Defense", "Strength", "Hitpoints", "Ranged", "Prayer", "Magic", "Cooking", "Woodcutting", "Fletching", "Fishing", "Firemaking", "Crafting", "Smithing", "Mining", "Herblore", "Agility", "Thieving", "Slayer", "Farming", "Runecraft", "Hunter", "Construction" };

            Player playerToUpdate = db.Players.Where(a => a.RS_Username == username).FirstOrDefault();

            if (playerToUpdate != null)
            {
                // Get skill data from Runescape
                WebClient client = new WebClient();
                string[] jsonResult = client.DownloadString("http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=" + username.ToLower()).Replace('\n', ';').Split(';');

                // Update Skills for the user
                int skillIndex = 0;
                foreach (string skillName in order)
                {
                    string[] stats = jsonResult[skillIndex].Split(',');
                    string skillRank = stats[0],
                        skillLevel = stats[1],
                        skillExp = stats[2];

                    Skill sk = db.Skills.Where(a => a.Name == skillName).FirstOrDefault();
                    PlayerSkill ps = db.PlayerSkills.Where(a => a.PlayerID == playerToUpdate.PlayerID && a.SkillID == sk.SkillID).FirstOrDefault();
                    if (ps == null)
                    {
                        ps.PlayerID = playerToUpdate.PlayerID;
                        ps.SkillID = sk.SkillID;
                    }
                    ps.Rank = Convert.ToInt32(stats[0]);
                    ps.Exp = Convert.ToInt32(stats[2]);
                    ps.Level = Convert.ToInt32(stats[1]);
                    db.SubmitChanges();
                    skillIndex++;
                }
                
                return true;
            }

            // Player does not exist, so create him/her
            else
            {
                return PlayerData.CreatePlayer(username);
            }
        }
    }

}
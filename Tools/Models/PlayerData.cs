using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Tools.Models
{
    public class PlayerData
    {
        // TODO: Delete a player and all their stats
        // TODO: Associate a player with an oAuth login
        // TODO: Restrict the number of Players that can be associated with an account (Saves space, can be altered later)
        // TODO: Add Diary Tracking/Skill Requirements
        // TODO: Hide quests if they've been completed on the Dashboard?

        public List<Skills.SkillData> skills { get; set; }
        public List<QuestData> quests { get; set; }

        public static PlayerData Lookup(string username)
        {
            return null; // TODO: Get a player for player stat lookup without any login information. This should be done using an input on the page and a submit button
        }

        public static PlayerData GetPlayer(string username)
        {
            return null; 
            // TODO: Get the active player for the user
        }

        /// <summary>
        /// Create a Player entry in the Runescape database containing the username, skills, and blank quest progress
        /// Skills are retrieved dynamically via the Runescape.com api
        /// </summary>
        /// <param name="username">The Runescape username to create</param>
        /// <returns>Whether the Player was successfully created</returns>
        public static bool CreatePlayer(string username)
        {
            RunescapeDataContext db = new RunescapeDataContext();
            // The order that the skills will be recieved by Runscape API. THIS ORDER MATTERS
            string[] order = { "Overall", "Attack", "Defense", "Strength", "Hitpoints", "Ranged", "Prayer", "Magic", "Cooking", "Woodcutting", "Fletching", "Fishing", "Firemaking", "Crafting", "Smithing", "Mining", "Herblore", "Agility", "Thieving", "Slayer", "Farming", "Runecraft", "Hunter", "Construction" };

            // Check if the player exists already
            // TODO: Alter so that it instead looks up the current user's player and replaces them with the new one
            Player playerToCreate = db.Players.Where(a => a.RS_Username == "username").FirstOrDefault();

            // The player does not exist, proceed with the creation
            if (playerToCreate == null)
            {
                //Create the new user
                playerToCreate = new Player();
                playerToCreate.RS_Username = username;
                playerToCreate.Admin = false;
                db.Players.InsertOnSubmit(playerToCreate);
                db.SubmitChanges();

                // Create quests for the user
                foreach (Quest quest in db.Quests.ToList())
                {
                    PlayerQuest pq = new PlayerQuest();
                    pq.Status = false;
                    pq.PlayerID = playerToCreate.PlayerID;
                    pq.QuestID = quest.QuestID;
                    db.PlayerQuests.InsertOnSubmit(pq);
                }

                // Get skill data from Runescape
                WebClient client = new WebClient();
                string[] jsonResult = client.DownloadString("http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=" + username.ToLower()).Replace('\n',';').Split(';');

                // Create skills for the user
                int skillIndex = 0;
                foreach (string skillName in order)
                {            
                    string[] stats = jsonResult[skillIndex].Split(',');
                    string skillRank = stats[0],
                        skillLevel = stats[1],
                        skillExp = stats[2];

                    PlayerSkill ps = new PlayerSkill();
                    ps.SkillID = db.Skills.Where(a => a.Name == skillName).FirstOrDefault().SkillID;
                    ps.Rank = Convert.ToInt32(stats[0]);
                    ps.Exp = Convert.ToInt32(stats[2]);
                    ps.Level = Convert.ToInt32(stats[1]);
                    ps.PlayerID = playerToCreate.PlayerID;

                    db.PlayerSkills.InsertOnSubmit(ps);
                    skillIndex++;                    
                }



                db.SubmitChanges();
                return true;
            }

            // If the player exists, it doesn't need to be created, make sure they have stats
            else
            {
                // Check the skills
                foreach (Skill skill in db.Skills.ToList())
                {
                    PlayerSkill ps = db.PlayerSkills.Where(a => a.PlayerID == playerToCreate.PlayerID && a.SkillID == skill.SkillID).FirstOrDefault();

                    // The skill does not exist for the player; create it
                    if (ps == null)
                    {
                        ps.PlayerID = playerToCreate.PlayerID;
                        ps.SkillID = skill.SkillID;
                        ps.Rank = 0;
                        ps.Level = 1;
                        ps.Exp = 1; // Set these stats to 1 until the next update
                        db.PlayerSkills.InsertOnSubmit(ps);
                    }
                }

                // Check the quests
                foreach (Quest quest in db.Quests.ToList())
                {
                    PlayerQuest pq = db.PlayerQuests.Where(a => a.PlayerID == playerToCreate.PlayerID && a.QuestID == quest.QuestID).FirstOrDefault();

                    // The quest does not exist for the player; create it
                    if (pq == null)
                    {
                        pq.PlayerID = playerToCreate.PlayerID;
                        pq.QuestID = quest.QuestID;
                        pq.Status = false;
                        db.PlayerQuests.InsertOnSubmit(pq);
                    }
                }

                db.SubmitChanges();
                return true;
            }
        }
    }
}
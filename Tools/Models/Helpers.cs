﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools.Models
{
    public class Helpers
    {
        public class Achievement
        {
            string id { get; set; }
            string title { get; set; }
        }

        public class Runescape
        {
            public class UserData
            {
                public List<SkillData> skills { get; set; }
                public List<QuestData> quests { get; set; }
            }

            public class QuestData
            {
                public Quest quest { get; set; }
                public bool status { get; set; }

            }

            public class SkillData
            {
                public int exp { get; set; }
                public int lvl { get; set; }
                public int rank { get; set; }
                public int req { get; set; }
                public string name { get; set; }
                public decimal progress { get; set; }
            }

            public static UserData GetData(string username, string data)
            {
                UserData u = new UserData();
                u.skills = UpdateSkills(username, data);
                u.quests = GetQuests(username);

                return u;
            }

            public static List<SkillData> UpdateSkills(string username, string data)
            {
                ToolsDataContext db = new ToolsDataContext();
                Player playerToUpdate = db.Players.Where(a => a.RS_Username == username).FirstOrDefault();
                List<SkillData> skillListToReturn = new List<SkillData>();

                // Split the data string from the API into individual parts
                string[] skillsRaw = data.Split(';'),
                    order = { "Overall", "Attack", "Defense", "Strength", "Hitpoints", "Ranged", "Prayer", "Magic", "Cooking", "Woodcutting", "Fletching", "Fishing", "Firemaking", "Crafting", "Smithing", "Mining", "Herblore", "Agility", "Thieving", "Slayer", "Farming", "Runecraft", "Hunter", "Construction" };

                // Player already exists, update the data
                if (playerToUpdate != null)
                {
                    int skillIndex = 0; //Keeps track of the skill order
                    foreach (string skill in order)
                    {
                        string[] stats = skillsRaw[skillIndex].Split(',');
                        string skillName = skill,
                            skillRank = stats[0],
                            skillLevel = stats[1],
                            skillExp = stats[2];

                        // Update the values in the database
                        Skill sk = db.Skills.Where(a => a.Name == skill).FirstOrDefault();
                        PlayerSkill ps = db.PlayerSkills.Where(a => a.RS_Skill == sk.SkillID && a.RS_Player == playerToUpdate.PlayerID).FirstOrDefault();

                        if (ps == null) // If no entry exists for the player
                        {
                            ps = new PlayerSkill();
                            ps.RS_Player = playerToUpdate.PlayerID;
                            ps.RS_Skill = db.Skills.Where(a => a.Name == skill).FirstOrDefault().SkillID;
                        }

                        ps.Rank = Convert.ToInt32(skillRank);
                        ps.Level = Convert.ToInt32(skillLevel);
                        ps.Experience = Convert.ToInt32(skillExp);

                        skillIndex++;

                        SkillData toList = new SkillData();
                        toList.exp = Convert.ToInt32(ps.Experience);
                        toList.lvl = Convert.ToInt32(ps.Level);
                        toList.rank = Convert.ToInt32(ps.Rank);
                        toList.req = Convert.ToInt32(sk.QuestMinimum);
                        toList.name = skill;
                        toList.progress = 100;

                        if (toList.name != "Overall")
                        {
                            if (toList.lvl < 99)
                            {
                                Level nl = db.Levels.Where(a => a.LevelNumber == toList.req).FirstOrDefault();
                                toList.progress = Math.Round(((decimal)toList.exp) / ((decimal)nl.Experience) * 100, 2);
                                if (toList.progress > 100)
                                {
                                    toList.progress = 100;
                                }
                            }
                        }


                        skillListToReturn.Add(toList);
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
                            ps.Experience = Convert.ToInt32(skillExp);
                            ps.RS_Player = playerToUpdate.PlayerID;
                            Skill sk = db.Skills.Where(a => a.Name == skillName).FirstOrDefault();
                            ps.RS_Skill = sk.SkillID;

                            skillIndex++;
                            db.PlayerSkills.InsertOnSubmit(ps);
                            SkillData toList = new SkillData();
                            toList.exp = Convert.ToInt32(ps.Experience);
                            toList.lvl = Convert.ToInt32(ps.Level);
                            toList.rank = Convert.ToInt32(ps.Rank);
                            toList.req = Convert.ToInt32(sk.QuestMinimum);
                            toList.name = skill;
                            toList.progress = 100;

                            if (toList.name != "Overall")
                            {
                                if (toList.lvl < 99)
                                {
                                    Level ll = db.Levels.Where(a => a.LevelNumber == toList.lvl).FirstOrDefault();
                                    Level nl = db.Levels.Where(a => a.LevelNumber == toList.lvl + 1).FirstOrDefault();
                                    toList.progress = Math.Round(((decimal)toList.exp - ll.Experience) / ((decimal)nl.Experience - ll.Experience) * 100, 2);
                                }
                            }


                            skillListToReturn.Add(toList);
                        }
                    }
                    db.SubmitChanges();
                }

                return skillListToReturn;
            }

            public static List<QuestData> UpdateQuests(string username, string data)
            {
                return new List<QuestData>();
            }

            public static List<QuestData> GetQuests(string username)
            {
                ToolsDataContext db = new ToolsDataContext();
                Player p = db.Players.Where(a => a.RS_Username == username).FirstOrDefault();
                List<QuestData> output = new List<QuestData>();

                // If the player does not exist, create one
                if (p == null)
                {
                    p = NewPlayer(username);
                }

                foreach (Quest q in db.Quests)
                {
                    QuestData qd = new QuestData();
                    qd.quest = q;

                    PlayerQuest questStatus = db.PlayerQuests.Where(a => a.PlayerID == p.PlayerID && a.QuestID == q.QuestID).FirstOrDefault();
                    if (questStatus != null)
                    {
                        qd.status = questStatus.Status;
                    }
                    else
                    {
                        questStatus = new PlayerQuest();
                        questStatus.QuestID = q.QuestID;
                        questStatus.PlayerID = p.PlayerID;
                        questStatus.Status = false;
                        db.PlayerQuests.InsertOnSubmit(questStatus);
                    }
                    output.Add(qd);
                }
                db.SubmitChanges();

                return output;
            }

            public static Player NewPlayer(string username)
            {
                ToolsDataContext db = new ToolsDataContext();

                Player p = db.Players.Where(a => a.RS_Username == username).FirstOrDefault();

                if (p == null)
                {
                    p = new Player();
                    p.RS_Username = username;
                    db.Players.InsertOnSubmit(p);
                    db.SubmitChanges();
                    return p;
                }
                else
                {
                    return p;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools.Models
{
    public class Quests
    {
        public class QuestData
        {
            public Quest quest { get; set; }
            public string name { get; set; }
            public int reward { get; set; }
            public string url { get; set; }
            public bool status { get; set; }

            public QuestData GetQuestData(string username)
            {
                return new QuestData();
            }
        }


        public bool GetQuests(string username)
        {


            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public static class QuestController
    {
        public static List<Quest> CompletedQuest = new List<Quest>();
        public static List<Quest> ActiveQuests = new List<Quest>();
        public static Quest LoadQuest(string questName)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader("..\\..\\..\\Quests\\Quests.csv");
            }
            catch
            {
                return null;
            }

            string line;
            while (true)
            {
                line = sr.ReadLine();
                if (line == "" || line == null)
                {
                    return null;
                }

                if (line.Split(';')[0] == questName)
                {
                    string[] data = line.Split(';');
                    return new Quest(data[0], data[1], data[2], data[3], data[4]);
                }
            } 
        }
    }
}

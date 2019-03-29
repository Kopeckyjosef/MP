using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TheGame.Objects;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public static class NPCGenerator
    {
        public static List<NPC> LoadNPCs(string mapName)
        {
            string path = "..\\..\\..\\Maps\\MapNPCs\\";
            StreamReader sr;
            try
            {
                sr = new StreamReader(path + mapName + ".csv");
            }
            catch
            {
                return new List<NPC>();
            }

            List<NPC> enemies = new List<NPC>();
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null || line == "")
                {
                    break;
                }
                string[] data = line.Split(';');
                Roam r;
                if (data[3] == "")
                {
                    r = null;
                }
                else
                {
                    r = null;
                }
                enemies.Add(GenerateNPC(new Coordinates(float.Parse(data[0]), float.Parse(data[1])), data[2], r, QuestController.LoadQuest(data[4]), data[5]));
            }
            return enemies;
        }
        public static NPC GenerateNPC(Coordinates coordinates, string textureName, Roam roam, Quest quest, string facing)
        {
            NPC npc = new NPC(coordinates, textureName, roam, quest);
            if (facing == "left")
            {
                npc.texture.ChangeDirection(false);
            }
            Random r = new Random();
            npc.Level = 1;
            npc.MaximumHealth = npc.Level * 15 + 100;
            npc.Health = npc.Level * 15 + 100;
            npc.MaximumStamina = npc.Level * 9 + 50;
            npc.Stamina = npc.Level * 9 + 50;
            // ADD Equip

            //

            return npc;
        }
    }
}

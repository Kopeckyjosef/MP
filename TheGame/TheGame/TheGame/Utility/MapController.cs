using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TheGameNamespace.Objects;
using Microsoft.Xna.Framework.Content;
using TheGameNamespace.Objects.MapObject;
using TheGame.Objects;
using TheGame.Objects.MapObject.TerrainItems;
using TheGame.Utility;

namespace TheGameNamespace.Utility
{
    public static class MapController
    {
        public static Map GetMap(string mapName)
        {
            StreamReader map = LoadMap(mapName);
            TerrainList tl = new TerrainList();
            List<Terrain> terrain = new List<Terrain>();

            int y = 0;
            int x = 0;
            while (true)
            {
                x = 0;
                string row = map.ReadLine();
                if (row == string.Empty || row == null)
                {
                    break;
                }
                foreach (string cell in row.Split(';'))
                {
                    if (cell == string.Empty)
                    {
                        x++;
                        continue;
                    }
                    else
                    {
                        var terrainObject = tl.GetTerrain(cell, x, y);
                        if (terrainObject == null)
                        {
                            continue;
                        }
                        else
                        {
                            terrain.Add(terrainObject);
                        }
                    }
                    x++;
                }
                y++;
            }
            List<Terrain> additional = LoadAdditional(tl, mapName);
            foreach (Terrain t in additional)
            {
                terrain.Add(t);
            }

            Map m = new Map(terrain);
            m.Name = mapName;
            m.Teleports = LoadTeleports(mapName);
            m.Chests = LoadChests(mapName);
            foreach (Teleport t in m.Teleports)
            {
                m.allObjects.Add(t);
            }
            foreach (Chest c in m.Chests)
            {
                m.allObjects.Add(c);
            }
            return m;
        }
        private static List<Terrain> LoadAdditional(TerrainList tl, string mapName)
        {
            List<Terrain> finalList;
            finalList = new List<Terrain>();
            string path = "..\\..\\..\\Maps\\Additional\\";
            StreamReader sr;
            try
            {
                sr = new StreamReader(path + mapName + ".csv");
            }
            catch
            {
                return new List<Terrain>();
            }

            while (true)
            {
                string line = sr.ReadLine();
                int firstCoordinate = 0;
                int secondCoordinate = 0;
                string terrain = string.Empty;

                if (line == string.Empty || line == null)
                {
                    break;
                }

                string temp = string.Empty;
                int index = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ' ')
                    {
                        switch (index)
                        {
                            case 0: firstCoordinate = Int32.Parse(temp); break;
                            case 1: secondCoordinate = Int32.Parse(temp); break;
                            default: break;
                        }
                        index++;
                        temp = string.Empty;
                    }
                    else
                    {
                        temp += line[i];
                    }
                }
                if (index == 2)
                {
                    terrain = temp;
                }
                finalList.Add(tl.GetTerrain(terrain, firstCoordinate, secondCoordinate));
            }
            return finalList;
        }
        private static List<Teleport> LoadTeleports(string mapName)
        {
            TerrainList tl = new TerrainList();
            List<Teleport> finalList = new List<Teleport>();
            string path = "..\\..\\..\\Maps\\Teleporters\\";
            StreamReader sr;
            try
            {
                sr = new StreamReader(path + mapName + ".csv");
            }
            catch
            {
                return new List<Teleport>();
            }

            while (true)
            {
                string line = sr.ReadLine();
                if (line == null || line == "")
                {
                    break;
                }
                if (!line.Contains("Teleport"))
                {
                    continue;
                }
                string[] data = line.Split(';');
                finalList.Add(tl.GetTeleport(new Coordinates(Int32.Parse(data[0]), Int32.Parse(data[1])), "walls/" + data[2], new Coordinates(Int32.Parse(data[3]), Int32.Parse(data[4])), data[5]));
            }
            foreach (Teleport t in finalList)
            {
                t.Initialize();
            }
            return finalList;
        }
        private static List<Chest> LoadChests(string mapName)
        {
            TerrainList tl = new TerrainList();
            List<Chest> finalList = new List<Chest>();
            string path = "..\\..\\..\\Maps\\Teleporters\\";
            StreamReader sr;
            try
            {
                sr = new StreamReader(path + mapName + ".csv");
            }
            catch
            {
                return new List<Chest>();
            }

            while (true)
            {
                string line = sr.ReadLine();
                if (line == null || line == "")
                {
                    break;
                }
                if (!line.Contains("Chest"))
                {
                    continue;
                }
                string[] data = line.Split(';');
                List<InventoryItem> loot = new List<InventoryItem>();
                foreach (string s in data[3].Split(','))
                {
                    loot.Add(GearLoader.LoadEquip(s));
                }
                finalList.Add(tl.GetChest(new Coordinates(float.Parse(data[0]), float.Parse(data[1])), data[2], loot));
            }
            foreach (Chest c in finalList)
            {
                c.Initialize();
            }
            return finalList;
        }
        private static StreamReader LoadMap(string mapName)
        {
            string path = "..\\..\\..\\Maps\\";
            return new StreamReader(path + mapName + ".csv");
        }
    }
}

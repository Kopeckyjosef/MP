using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TheGameNamespace.Objects;
using Microsoft.Xna.Framework.Content;
using TheGameNamespace.Objects.MapObject;

namespace TheGameNamespace.Utility
{
    public static class MapController
    {
        public static Map GetMap(string mapName, ContentManager content)
        {
            StreamReader map = LoadMap(mapName);
            TerrainList tl = new TerrainList();
            List<Terrain> terrain = new List<Terrain>();
            List<Floor> floor = new List<Floor>();

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
            return new Map(terrain);
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

                if (line == string.Empty)
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
        private static StreamReader LoadMap(string mapName)
        {
            string path = "..\\..\\..\\Maps\\";
            return new StreamReader(path + mapName + ".csv");
        }
    }
}

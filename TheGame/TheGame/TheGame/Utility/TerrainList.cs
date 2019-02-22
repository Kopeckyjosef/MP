using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameNamespace.Objects;
using Microsoft.Xna.Framework.Content;
using TheGameNamespace.Objects.MapObject;
using TheGame.Objects;
using TheGame.Objects.MapObject.TerrainItems;
using TheGame.Utility;

namespace TheGameNamespace.Utility
{
    public class TerrainList
    {
        public Terrain GetTerrain(string Texturename, int x, int y)
        {
            string name = "walls/" + Texturename;
            if (name.Contains("Floor_"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.Floor, true, false);
            }
            else if (name.Contains("WallLeftShort_"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.LeftWallShort, true, false);
            }
            else if (name.Contains("WallBackShort_"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.BackWallShort, false, false);
            }
            else if (name.Contains("WallBack_"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.BackWall, false, false);
            }
            else if (name.Contains("WallFront_"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.FrontWall, false, false);
            }
            else if (name.Contains("WallRightFull_"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.WallRightFull, false, false);
            }
            else if (name.Contains("WallLeft_"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.LeftWall, false, false);
            }
            else if (name.Contains("WallRight_"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.RightWall, false, false);
            }
            else if (name.Contains("Ceiling"))
            {
                return new Terrain(new Coordinates(x, y), name, TerrainType.Ceiling, false, false);
            }
            else
            {
                return null;
            }
        }
        public Teleport GetTeleport(Coordinates coordinates, string pathToTexture, Coordinates spawnCoordinates, string destinationName)
        {
            TerrainType tt;
            if (pathToTexture.Contains("LeftShort"))
            {
                tt = TerrainType.LeftWallShort;
            }
            else if (pathToTexture.Contains("Left"))
            {
                tt = TerrainType.LeftWall;
            }
            else if (pathToTexture.Contains("RightFull"))
            {
                tt = TerrainType.WallRightFull;
            }
            else if (pathToTexture.Contains("Ceiling"))
            {
                tt = TerrainType.Ceiling;
            }
            else if (pathToTexture.Contains("Right"))
            {
                tt = TerrainType.RightWall;
            }
            else if (pathToTexture.Contains("Back"))
            {
                tt = TerrainType.BackWall;
            }
            else if (pathToTexture.Contains("Front"))
            {
                tt = TerrainType.FrontWall;
            }
            else
            {
                tt = TerrainType.Floor;
            }
            return new Teleport(coordinates, pathToTexture, tt, spawnCoordinates, destinationName);
        }
        public Chest GetChest(Coordinates coordinates, string pathToTexture, List<InventoryItem> loot)
        {
            List<InventoryItem> newLoot = loot;
            foreach (InventoryItem ii in newLoot)
            {
                if (ii == null)
                {
                    newLoot.Clear();
                    break;
                }
            }
            switch (pathToTexture)
            {
                case "woodenChest": newLoot.Add(GearLoader.LoadTypedEquip("Leather")); break;
            }
            return new Chest(coordinates, "chests/" + pathToTexture, loot);
        }
    }
}

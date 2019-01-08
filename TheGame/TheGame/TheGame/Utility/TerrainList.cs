using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGameNamespace.Objects;
using Microsoft.Xna.Framework.Content;
using TheGameNamespace.Objects.MapObject.TerrainObject;
using TheGameNamespace.Objects.MapObject;
using TheGameNamespace.Objects.MapObject.FloorObject;
using TheGame.Objects.MapObject.Doors;
using TheGame.Objects.MapObject.TerrainObject;

namespace TheGameNamespace.Utility
{
    public class TerrainList
    {
        public Terrain GetTerrain(string name, int x, int y)
        {   
            switch (name)
            {
                case "TestWallBack":
                    return new TestWallBack(new Coordinates(x, y));
                case "TestWallBackShort":
                    return new TestWallBackShort(new Coordinates(x, y));
                case "TestWallFront":
                    return new TestWallFront(new Coordinates(x, y));
                case "TestWallLeft":
                    return new TestWallLeft(new Coordinates(x, y));
                case "TestWallRight":
                    return new TestWallRight(new Coordinates(x, y));
                case "TestFloor":
                    return new TestFloor(new Coordinates(x, y));
                case "TestDoor":
                    return new TestDoor(new Coordinates(x, y));
                default:
                    return null;
            }
        }
    }
}

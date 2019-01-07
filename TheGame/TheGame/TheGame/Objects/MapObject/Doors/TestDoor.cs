using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameNamespace.Objects;
using TheGameNamespace.Objects.MapObject;

namespace TheGame.Objects.MapObject.Doors
{
    class TestDoor : Door
    {
        public TestDoor(Coordinates coordinates) : base(coordinates)
        {
            this.TerrainType = TerrainType.LeftWall;
            this.pathToTexture = "testdoor";
        }
    }
}

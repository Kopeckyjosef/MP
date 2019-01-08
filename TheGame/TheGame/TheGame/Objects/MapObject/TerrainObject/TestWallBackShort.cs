using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameNamespace.Objects;
using TheGameNamespace.Objects.MapObject;

namespace TheGame.Objects.MapObject.TerrainObject
{
    class TestWallBackShort : Wall
    {
        public TestWallBackShort(Coordinates coordinates) : base(coordinates)
        {
            this.TerrainType = TerrainType.BackWallShort;
            this.pathToTexture = "frontwall";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TheGame.Objects;

namespace TheGameNamespace.Objects.MapObject.FloorObject
{
    public class TestFloor : Floor
    {
        public TestFloor(Coordinates coordinates) : base(coordinates)
        {
            this.pathToTexture = "floor";
        }
    }
}

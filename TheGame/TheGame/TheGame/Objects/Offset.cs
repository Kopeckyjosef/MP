using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Objects
{
    public struct Offset
    {
        public float x { get; set; }
        public float y { get; set; }
        public Offset(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

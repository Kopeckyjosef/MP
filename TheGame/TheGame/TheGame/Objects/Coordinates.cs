using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameNamespace.Objects
{
    public struct Coordinates
    {
        public float x { get; set; }
        public float y { get; set; }
        public Coordinates(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

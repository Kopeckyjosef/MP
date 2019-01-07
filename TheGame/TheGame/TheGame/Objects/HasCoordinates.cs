using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class HasCoordinates : IComparable
    {
        public Coordinates Coordinates;

        public int CompareTo(object obj)
        {
            try
            {
                HasCoordinates second = (HasCoordinates)obj;
                if (this.Coordinates.y == second.Coordinates.y)
                {
                    return this.Coordinates.x.CompareTo(second.Coordinates.x);
                }
                else
                {
                    return this.Coordinates.y.CompareTo(second.Coordinates.y);
                }
            }
            catch
            {
                return -1;
            }
        }

        public virtual void Draw()
        {

        }
    }
}

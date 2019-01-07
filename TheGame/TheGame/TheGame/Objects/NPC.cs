using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class NPC : Character
    {
        protected Roam roam;

        public NPC(Coordinates coordinates, string textureName) : base (coordinates, textureName)
        {
        }
        public void OnUpdate()
        {
            if (this.roam != null)
            {
                Vector a = roam.OnUpdate();
                this.Coordinates.x += a.x;
                this.Coordinates.y += a.y;
            }
        }
        public virtual void OnActivation()
        {

        }
    }
}

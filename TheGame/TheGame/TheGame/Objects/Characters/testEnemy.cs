using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using TheGameNamespace.Objects;

namespace TheGame.Objects.Characters
{
    class testEnemy : Enemy
    {
        public testEnemy(Coordinates coordinates) : base(coordinates, "enemy")
        {
            this.speed = 0.2;
        }
    }
}

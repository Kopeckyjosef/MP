using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameNamespace.Objects;

namespace TheGame.Objects.Characters
{
    public class Player : Character
    {
        public Player(Coordinates coordinates) : base(coordinates, "player")
        {
            this.Health = 100;
            this.MaximumHealth = 100;
            this.Stamina = 100;
            this.MaximumStamina = 100;
            this.speed = 0.5;
        }
        public new void Draw()
        {
            base.Draw();
        }
    }
}

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
        }
        public new void Draw()
        {
            base.Draw();
        }
    }
}

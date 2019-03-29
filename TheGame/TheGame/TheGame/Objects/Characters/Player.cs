using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects.Characters
{
    public class Player : Character
    {
        public int levelProgress { get; set; }
        public Player(Coordinates coordinates) : base(coordinates, "character/player")
        {
            this.levelProgress = 0;
            this.Level = 1;
            this.Health = 100;
            this.MaximumHealth = 100;
            this.Stamina = 100;
            this.MaximumStamina = 100;
            this.speed = 7;
        }
        public new void Draw()
        {
            base.Draw();
        }

        public void AddToLevelProgress(int xp)
        {
            this.levelProgress += xp;
            while (this.levelProgress >= this.Level * 100)
            {
                this.levelProgress -= this.Level * 100;
                this.Level += 1;
            }
        }

        public new void Die()
        {
            End.ExitGame();
        }
    }
}

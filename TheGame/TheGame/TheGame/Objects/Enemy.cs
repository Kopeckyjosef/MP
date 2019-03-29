using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class Enemy : Character
    {
        public WavePoint CurrentPath;
        public Enemy(Coordinates coordinates, string name) : base(coordinates, name)
        {
            this.Timer = 0;
            this.CurrentPath = new WavePoint(coordinates.x, coordinates.y, new List<WavePoint>());
            this.speed = 3;
            this.Health = 400;
        }

        public void OnUpdate(GameTime gameTime)
        {
            this.Timer += gameTime.ElapsedGameTime.Milliseconds;
            EnemyCollision.GoForPlayer(this, gameTime);
            if (this.Timer > 1000)
            {
                this.Timer -= 1000;
            }
        }
    }
}

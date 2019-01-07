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
        public Enemy(Coordinates coordinates, string name) : base(coordinates, name)
        {
        }

        public void OnUpdate()
        {
            Vector dFP = new Vector(EnemyCollision.Player.Coordinates.x - this.Coordinates.x, EnemyCollision.Player.Coordinates.y - this.Coordinates.y);

            EnemyCollision.MoveEnemy(new Vector((float)(this.speed * dFP.x / Math.Abs(dFP.x)), (float)(this.speed * dFP.y / Math.Abs(dFP.y))), this);
        }
    }
}

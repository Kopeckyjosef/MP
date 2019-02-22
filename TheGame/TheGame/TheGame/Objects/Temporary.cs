using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class Temporary : HasCoordinates
    {
        private double miliSeconds;
        private GameTexture gameTexture;
        private bool isFacingRight;
        public Temporary(double seconds, GameTexture gameTexture, bool isFacingRight, Coordinates coordinates)
        {
            this.Coordinates = coordinates;
            this.miliSeconds = seconds * 1000;
            this.gameTexture = gameTexture;
            this.gameTexture.ChangeDirection(isFacingRight);
        }
        public override void Draw()
        {
            this.gameTexture.Draw(this.Coordinates.x, this.Coordinates.y);
        }
        public void OnUpdate(GameTime GameTime)
        {
            this.miliSeconds -= GameTime.ElapsedGameTime.Milliseconds;
            if (this.miliSeconds < 0)
            {
                Access.Gamebody.returnTemporary().Remove(this);
            }
        }
    }
}

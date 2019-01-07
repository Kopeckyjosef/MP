using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;

namespace TheGame.Objects
{
    public class GameTexture
    {
        private Texture2D texture;
        private Offset offSet;
        private SpriteEffects spriteEffect = SpriteEffects.None;
        public GameTexture(Texture2D texture, Offset offSet)
        {
            this.texture = texture;
            this.offSet = offSet;
        }
        public void ChangeDirection(bool isFacingRight)
        {
            if (isFacingRight)
            {
                this.spriteEffect = SpriteEffects.None;
            }
            else
            {
                this.spriteEffect = SpriteEffects.FlipHorizontally;
            }
        }
        public void Draw(float x, float y)
        {
            GraficStuff.SpriteBatch.Draw(this.texture, new Vector2((int)((x - GraficStuff.Player.Coordinates.x) * 16 * GraficStuff.Scale - ((y - GraficStuff.Player.Coordinates.y) * 16 * GraficStuff.Scale / 2) + this.offSet.x * GraficStuff.Scale) + GraficStuff.WindowOffset.x, (int)((y - GraficStuff.Player.Coordinates.y) * 8 * GraficStuff.Scale + this.offSet.y * GraficStuff.Scale) + GraficStuff.WindowOffset.y), null, Color.White, 0, new Vector2(0, 0), GraficStuff.Scale, this.spriteEffect, 0f);
        }
    }
}

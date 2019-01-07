using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class Character : HasCoordinates
    {
        public Inventory Inventory { get; private set; }
        public GameTexture texture;
        protected string name;
        protected double speed;
        public bool isFacingRight { get; private set; }
        public void ChangeDirection(bool isFacingRight)
        {
            this.texture.ChangeDirection(isFacingRight);
            this.isFacingRight = isFacingRight;
        }

        public Character(Coordinates coordinates, string name)
        {
            this.texture = new GameTexture(GraficStuff.Content.Load<Texture2D>(@"" + name), new Offset(0, -28F));
            this.Coordinates = coordinates;
            this.Inventory = new Inventory();
        }
        public override void Draw()
        {
            this.texture.Draw((float)this.Coordinates.x, (float)this.Coordinates.y);
            this.Inventory.Draw(this.Coordinates);
        }
    }
}

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects.Characters;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class Character : HasCoordinates
    {
        public int Timer { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int MaximumHealth { get; set; }
        public int Stamina { get; set; }
        public int MaximumStamina { get; set; }
        public Inventory Inventory { get; protected set; }
        public GameTexture texture;
        protected string name;
        public double speed;
        protected int basicDmg = 5;
        public bool isFacingRight { get; private set; }
        public void ChangeDirection(bool isFacingRight)
        {
            this.texture.ChangeDirection(isFacingRight);
            this.isFacingRight = isFacingRight;
            this.Inventory.ChangeDirection(isFacingRight, this.texture.texture.Width);
        }

        public Character(Coordinates coordinates, string name)
        {
            this.texture = new GameTexture(GraficStuff.Content.Load<Texture2D>(@"" + name), new Offset(0, -28F));
            this.Coordinates = coordinates;
            this.Inventory = new Inventory();
        }
        public void TakeDmg(int damage)
        {
            int armor = 0;
            foreach(Slot s in this.Inventory.slots)
            {
                if (s.inventoryItem != null)
                {
                    armor += s.inventoryItem.Armor;
                } 
            }
            this.Health -= (int)(((float)damage / 100F) * (100 - armor));
            if (this.Health <= 0)
            {
                this.Die();
            }
        }
        public void DealDmg(Character attacked)
        {
            int damage = 0;
            damage += this.basicDmg;
            foreach (Slot s in this.Inventory.slots)
            {
                if (s.inventoryItem != null)
                {
                    damage += s.inventoryItem.Damage;
                }
            }
            attacked.TakeDmg(damage);
        }
        public void Die()
        {
            if (Access.Gamebody.returnEnemies().Contains(this))
            {
                Access.Gamebody.returnEnemies().Remove((Enemy)this);
            }
            else if (Access.Gamebody.returnNPCs().Contains(this))
            {
                Access.Gamebody.returnNPCs().Remove((NPC)this);
            }
            else if (this is Player) {
                End.ExitGame();
            }
        }
        public override void Draw()
        {
            this.texture.Draw((float)this.Coordinates.x, (float)this.Coordinates.y);
            this.Inventory.Draw(this.Coordinates, this.isFacingRight);
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class InventoryItem
    {
        public string Name { get; private set; }
        public string TextureName { get; private set; }
        public SlotType SlotType { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }
        public int Weight { get; private set; }
        public GameTexture gameTexture;

        public InventoryItem(string name, string textureName, SlotType slotType, int damage, int armor, int weight, Offset offset)
        {
            this.Name = name;
            this.TextureName = textureName;
            this.SlotType = slotType;
            this.Damage = damage;
            this.Armor = armor;
            this.Weight = weight;

            this.gameTexture = new GameTexture(GraficStuff.Content.Load<Texture2D>(@"" + textureName), offset);
        }
        public void Draw(Coordinates playerCoordinates)
        {
            this.gameTexture.Draw(playerCoordinates.x, playerCoordinates.y);
        }
    }
    public enum SlotType
    {
        Head,
        Chest,
        Legs,
        Boots,
        Weapon
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects.MapObject.FloorObject;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class Inventory
    {
        public int weight { get; private set; }
        private List<InventoryItem> spareItems;
        private List<Slot> slots;
        private List<GameTexture> InventoryTextures;
        public Inventory()
        {
            this.InventoryTextures = new List<GameTexture>();
            this.InventoryTextures.Add(new GameTexture(GraficStuff.Content.Load<Texture2D>(@"inventoryTile"), new Offset(0, 0)));
            this.InventoryTextures.Add(new GameTexture(GraficStuff.Content.Load<Texture2D>(@"inventoryTileFull"), new Offset(0, 0)));
            this.InventoryTextures.Add(new GameTexture(GraficStuff.Content.Load<Texture2D>(@"inventoryDetail"), new Offset(0, 0)));
            this.InventoryTextures.Add(new GameTexture(GraficStuff.Content.Load<Texture2D>(@"inventorySelection"), new Offset(0, 0)));

            this.spareItems = new List<InventoryItem>();
            this.slots = new List<Slot>();
            this.slots.Add(new Slot(SlotType.Head));
            this.slots.Add(new Slot(SlotType.Chest));
            this.slots.Add(new Slot(SlotType.Legs));
            this.slots.Add(new Slot(SlotType.Boots));
            this.slots.Add(new Slot(SlotType.Weapon));

            this.spareItems.Add(GearLoader.LoadWeapon("testWeapon"));
        }
        public void Draw(Coordinates coordinates)
        {
            foreach (Slot s in this.slots)
            {
                s.Draw(coordinates);
            }
        }

        public void AddItem(InventoryItem inventoryItem)
        {
            this.spareItems.Add(inventoryItem);
        }

        public void DropItem()
        {
            if (InventorySelection.SpareIndex >= 0 && InventorySelection.SpareIndex <= this.spareItems.Count - 1)
            {
                Access.Gamebody.returnMap().Dropped.Add(new Dropped(GraficStuff.Player.Coordinates, this.spareItems[InventorySelection.SpareIndex]));
                this.spareItems.RemoveAt(InventorySelection.SpareIndex);
            }
        }

        public void DrawInventory()
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if (y * 6 + x + 1 > this.spareItems.Count)
                    {
                        this.InventoryTextures[0].Draw(x + GraficStuff.Player.Coordinates.x + y, (y * 2) + GraficStuff.Player.Coordinates.y);
                    }
                    else
                    {
                        this.InventoryTextures[1].Draw(x + GraficStuff.Player.Coordinates.x + y, (y * 2) + GraficStuff.Player.Coordinates.y);
                    }
                }
            }
            for (int x = 0; x < 5; x ++)
            {
                if (this.slots[x].inventoryItem == null)
                {
                    this.InventoryTextures[0].Draw(x + GraficStuff.Player.Coordinates.x + 5, (5 * 2) + GraficStuff.Player.Coordinates.y);
                }
                else
                {
                    this.InventoryTextures[1].Draw(x + GraficStuff.Player.Coordinates.x + 5, (5 * 2) + GraficStuff.Player.Coordinates.y);
                }
            }

            this.InventoryTextures[2].Draw(6 + GraficStuff.Player.Coordinates.x, 0 + GraficStuff.Player.Coordinates.y);
            this.InventoryTextures[3].Draw(InventorySelection.Coordinates.x + GraficStuff.Player.Coordinates.x + InventorySelection.Coordinates.y, (InventorySelection.Coordinates.y * 2) + GraficStuff.Player.Coordinates.y);

            GraficStuff.Player.texture.Draw(9.8F + GraficStuff.Player.Coordinates.x, 5F + GraficStuff.Player.Coordinates.y);
            if (InventorySelection.SpareIndex >= 0)
            {
                if (InventorySelection.SpareIndex <= this.spareItems.Count - 1)
                {
                    this.spareItems[InventorySelection.SpareIndex].Draw(new Coordinates(9.8F + GraficStuff.Player.Coordinates.x, 5F + GraficStuff.Player.Coordinates.y));
                }
            }
            if (InventorySelection.SlotIndex >= 0)
            {
                if (InventorySelection.SlotIndex <= this.slots.Count - 1)
                {
                    this.slots[InventorySelection.SlotIndex].Draw(new Coordinates(9.8F + GraficStuff.Player.Coordinates.x, 5F + GraficStuff.Player.Coordinates.y));
                }
            }      
        }

        public void Equip()
        {
            if (InventorySelection.SpareIndex < 0)
            {
                if (InventorySelection.SlotIndex >= 0 && InventorySelection.SlotIndex <= this.slots.Count - 1)
                {
                    if (this.slots[InventorySelection.SlotIndex].inventoryItem != null)
                    {
                        this.spareItems.Add(this.slots[InventorySelection.SlotIndex].inventoryItem);
                        this.slots[InventorySelection.SlotIndex].inventoryItem = null;
                    }
                }
            }
            else
            {
                if (InventorySelection.SpareIndex >= 0 && InventorySelection.SpareIndex <= this.spareItems.Count - 1)
                {
                    Slot wantedSlot = this.slots.Where(x => x.type == this.spareItems[InventorySelection.SpareIndex].SlotType).FirstOrDefault();
                    if (wantedSlot.inventoryItem == null)
                    {
                        wantedSlot.inventoryItem = this.spareItems[InventorySelection.SpareIndex];
                        this.spareItems.RemoveAt(InventorySelection.SpareIndex);
                    }
                    else
                    {
                        this.spareItems.Add(wantedSlot.inventoryItem);
                        wantedSlot.inventoryItem = this.spareItems[InventorySelection.SpareIndex];
                        this.spareItems.RemoveAt(InventorySelection.SpareIndex);
                    }
                }
            }
        }
    }
    public class Slot
    {
        public SlotType type { get; private set; }
        public InventoryItem inventoryItem { get; set; }
        public Slot(SlotType type)
        {
            this.type = type;
        }
        public void Draw(Coordinates coordinates)
        {
            if (this.inventoryItem != null)
            {
                this.inventoryItem.Draw(coordinates);
            }
        }
    }
}

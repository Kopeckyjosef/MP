using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;
using TheGameNamespace.Objects.MapObject;

namespace TheGame.Objects.MapObject.TerrainItems
{
    public class Dropped : Terrain
    {
        public InventoryItem InventoryItem;
        public Dropped(Coordinates coordinates, InventoryItem inventoryItem) : base(coordinates, "dropped", TerrainType.Dropped, true, true)
        {
            this.InventoryItem = inventoryItem;
            this.Initialize(new Offset(0, -8));
        }
        public override void OnActivation()
        {
            GraficStuff.Player.Inventory.AddItem(this.InventoryItem);
            Access.Gamebody.returnMap().Dropped.Remove(this);
        }
    }
}

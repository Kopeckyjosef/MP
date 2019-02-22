using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;
using TheGameNamespace.Objects.MapObject;

namespace TheGame.Objects.MapObject.TerrainItems
{
    public class Chest : Terrain
    {
        public List<InventoryItem> Loot;
        public bool HasBeenOpened;
        public Chest(Coordinates coordinates, string pathToTexture, List<InventoryItem> loot) : base(coordinates, pathToTexture, TerrainType.Chest, false, true)
        {
            this.Loot = loot;
            this.HasBeenOpened = false;
        }

        public override void OnActivation()
        {
            if (!this.HasBeenOpened)
            {
                foreach (InventoryItem i in this.Loot)
                {
                    GraficStuff.Player.Inventory.AddItem(i);
                }
                this.HasBeenOpened = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TheGame.Objects;

namespace TheGame.Utility
{
    public static class GearLoader
    {
        public static InventoryItem LoadEquip(string gearName)
        {
            StreamReader file = new StreamReader("..\\..\\..\\Armor\\Armor.csv");
            while (true)
            {
                string line = file.ReadLine();
                if (line == "" || line == null)
                {
                    return null;
                }
                InventoryItem ii = makeItem(line);
                if (ii.Name == gearName)
                {
                    return ii;
                }
            }
        }
        public static InventoryItem LoadTypedEquip(string gearTypeName)
        {
            StreamReader file = new StreamReader("..\\..\\..\\Armor\\Armor.csv");
            List<InventoryItem> itemList = new List<InventoryItem>();
            while (true)
            {
                string line = file.ReadLine();
                if (line == "" || line == null)
                {
                    break;
                }
                InventoryItem ii = makeItem(line);
                if (ii.Name.Contains(gearTypeName))
                {
                    itemList.Add(ii);
                }
            }
            Random r = new Random();
            int i = r.Next(0, itemList.Count - 1);
            return itemList[i];
        }

        private static InventoryItem makeItem(string line)
        {
            string[] stats = line.Split(';');

            SlotType st;
            switch (stats[2])
            {
                case "Weapon": st = SlotType.Weapon; break;
                case "Legs": st = SlotType.Legs; break;
                case "Chest": st = SlotType.Chest; break;
                case "Head": st = SlotType.Head; break;
                case "Boots": st = SlotType.Boots; break;
                default: st = SlotType.Weapon; break;
            }
            return new InventoryItem(stats[0], stats[1], st, Int32.Parse(stats[3]), Int32.Parse(stats[4]), Int32.Parse(stats[5]), new Offset(float.Parse(stats[6]), float.Parse(stats[7])));
        }
    }
}

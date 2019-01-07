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
        public static InventoryItem LoadWeapon(string weaponName)
        {
            StreamReader file = new StreamReader("..\\..\\..\\Weapons\\Weapons.csv");
            while (true)
            {
                InventoryItem ii = makeItem(file.ReadLine());
                if (ii.TextureName == weaponName)
                {
                    return ii;
                }
            }
        }

        private static InventoryItem makeItem(string line)
        {
            string[] stats = new string[8];
            int index = 0;

            foreach (char c in line)
            {
                if (c == ';')
                {
                    index += 1;
                    continue;
                }
                else
                {
                    stats[index] += c;
                }
            }

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

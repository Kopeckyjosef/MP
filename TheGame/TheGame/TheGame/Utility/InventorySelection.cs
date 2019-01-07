using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public static class InventorySelection
    {
        public static Coordinates Coordinates;
        public static int SpareIndex;
        public static int SlotIndex;

        public static void Init()
        {
            InventorySelection.Coordinates = new Coordinates(0, 0);
            InventorySelection.SpareIndex = 0;
            InventorySelection.SlotIndex = -1;
        }

        public static void Left()
        {
            if (!(InventorySelection.Coordinates.x - 1 < 0))
            {
                InventorySelection.Coordinates.x -= 1;
                if (InventorySelection.Coordinates.y == 5)
                {
                    InventorySelection.SlotIndex -= 1;
                }
                else
                {
                    InventorySelection.SpareIndex -= 1;
                }
            }
        }
        public static void Up()
        {
            try
            {
                if (!(InventorySelection.Coordinates.y - 1 < 0))
                {
                    if (InventorySelection.Coordinates.y == 5)
                    {
                        InventorySelection.SlotIndex = -1;
                        InventorySelection.Coordinates.y -= 1;
                        InventorySelection.SpareIndex = 24 + (int)InventorySelection.Coordinates.x;
                    }
                    else
                    {

                    }
                    InventorySelection.Coordinates.y -= 1;
                    InventorySelection.SpareIndex -= 6;
                }
            }
            catch
            {

            }
        }
        public static void Right()
        {
            if (!(InventorySelection.Coordinates.x + 1 > 5))
            {
                if (InventorySelection.Coordinates.y == 5)
                {
                    if (InventorySelection.Coordinates.x + 1 < 5)
                    {
                        InventorySelection.Coordinates.x += 1;
                        InventorySelection.SlotIndex += 1;
                    }
                }
                else
                {
                    InventorySelection.Coordinates.x += 1;
                    InventorySelection.SpareIndex += 1;
                }
            }
        }
        public static void Down()
        {
            try
            {
                if (!(InventorySelection.Coordinates.y + 1 > 5))
                {
                    if (InventorySelection.Coordinates.y + 1 == 5)
                    {
                        if (InventorySelection.Coordinates.x != 5)
                        {
                            InventorySelection.SpareIndex = -1;
                            InventorySelection.Coordinates.y += 1;
                            InventorySelection.SlotIndex = (int)InventorySelection.Coordinates.x;
                        }
                    }
                    else
                    {
                        InventorySelection.Coordinates.y += 1;
                        InventorySelection.SpareIndex += 6;
                    }
                }
            }
            catch
            {

            }
        }
    }
}

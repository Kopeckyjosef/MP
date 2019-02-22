using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame.Objects;
using TheGame.Utility;

namespace TheGameNamespace.Objects
{
    public class Quest
    {
        public string Name;
        public string Description;
        public bool IsCompleted;
        public string NextQuest;
        public int QuestCounter;
        public int RewardXP;
        public InventoryItem RewardItem;
        public Quest(string name, string description, string nextQuest, string rewardXP, string rewardItem)
        {
            this.Name = name;
            this.Description = description;
            this.NextQuest = nextQuest;
            this.RewardXP = Int32.Parse(rewardXP);
            if (!(rewardItem == "" || rewardItem == null))
            {
                this.RewardItem = GearLoader.LoadEquip(rewardItem);
            }
            this.IsCompleted = false;
            this.QuestCounter = 0;
        }
        public void Complete()
        {
            GraficStuff.Player.levelProgress += this.RewardXP;
            GraficStuff.Player.Inventory.AddItem(this.RewardItem);

            QuestController.ActiveQuests.Remove(this);
        }
    }
}

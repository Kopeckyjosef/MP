using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects
{
    public class NPC : Character
    {
        public Roam Roam;
        public Quest Quest;

        public NPC(Coordinates coordinates, string textureName, Roam roam, Quest quest) : base (coordinates, textureName)
        {
            this.Roam = roam;
            this.Quest = quest;
        }
        public void OnUpdate()
        {
            if (this.Roam != null)
            {
                Vector a = Roam.OnUpdate();
                this.Coordinates.x += a.x;
                this.Coordinates.y += a.y;
            }
        }
        public virtual void OnActivation()
        {
            if (this.Quest != null)
            {
                QuestController.ActiveQuests.Add(this.Quest);
            }
        }
    }
}

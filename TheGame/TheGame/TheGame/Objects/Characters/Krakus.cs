using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects.Characters
{
    class Krakus : Enemy
    {
        public Krakus(Coordinates coordinates) : base(coordinates, "Krakus")
        {
        }

        public new void Die()
        {
            if (QuestController.ActiveQuests.Where(x => x.Name == "Kill Krusus").Any())
            {
                QuestController.ActiveQuests.Where(x => x.Name == "Kill Krusus").FirstOrDefault().Complete();
            }
            base.Die();
        }
    }
}

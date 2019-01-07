using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Utility;
using TheGameNamespace.Objects;

namespace TheGame.Objects.Characters
{
    public class testNPC : NPC
    {
        public testNPC(Coordinates coordinates) : base(coordinates, "npc")
        {
            // this.roam = new Roam(new Vector(5, 2), 100);
        }
        public override void OnActivation()
        {
            Pause.PauseGame(PauseType.Conversation);
        }
    }
}

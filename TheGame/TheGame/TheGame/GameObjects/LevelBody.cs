using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame.Objects;
using TheGame.Objects.Characters;
using TheGameNamespace.Objects;
using TheGame.Utility;
using TheGameNamespace.Objects.MapObject;

namespace TheGameNamespace.GameObjects
{
    public class LevelBody
    {
        private List<Enemy> enemies;
        private List<NPC> NPCs;
        private Map map;
        public LevelBody(Map map)
        {
            this.NPCs = new List<NPC>();
            this.enemies = new List<Enemy>();
            this.map = map;
            map.Initialize();
            // Delete
            this.enemies.Add(new testEnemy(new Coordinates(30, 30)));
            this.NPCs.Add(new testNPC(new Coordinates(2, 2)));
        }
        public void Draw()
        {
            this.map.Draw(this.enemies, this.NPCs);
        }
        public Map returnMap()
        {
            return this.map;
        }
        public List<NPC> returnNPCs()
        {
            return this.NPCs;
        }
        public List<Enemy> returnEnemies()
        {
            return this.enemies;
        }
        public void OnUpdate()
        {
            if (!Pause.IsPaused)
            {
                foreach (Enemy e in this.enemies)
                {
                    e.OnUpdate();
                }
                foreach (NPC n in this.NPCs)
                {
                    n.OnUpdate();
                }
            }
        }
    }
}

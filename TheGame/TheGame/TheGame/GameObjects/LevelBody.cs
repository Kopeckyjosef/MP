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
using Microsoft.Xna.Framework;

namespace TheGameNamespace.GameObjects
{
    public class LevelBody
    {
        private List<Enemy> enemies;
        private List<NPC> NPCs;
        private Map map;
        private List<Temporary> temporary;
        public LevelBody(Map map)
        {
            this.temporary = new List<Temporary>();
            this.NPCs = new List<NPC>();
            this.enemies = new List<Enemy>();
            this.map = map;
            map.Initialize();
            this.enemies = EnemyGenerator.LoadEnemies(this.map.Name);
            this.NPCs = NPCGenerator.LoadNPCs(this.map.Name);
        }
        public void Draw()
        {
            this.map.Draw(this.enemies, this.NPCs);
            foreach (Temporary t in this.temporary)
            {
                t.Draw();
            }
        }
        public void AddTemp()
        {

        }
        public Map returnMap()
        {
            return this.map;
        }
        public List<NPC> returnNPCs()
        {
            return this.NPCs;
        }
        public List<Temporary> returnTemporary()
        {
            return this.temporary;
        }
        public List<Enemy> returnEnemies()
        {
            return this.enemies;
        }
        public void OnUpdate(GameTime gameTime)
        {
            if (!Pause.IsPaused)
            {
                int control;
                for (int i = 0; i < this.temporary.Count; i++)
                {
                    control = this.temporary.Count;
                    this.temporary[i].OnUpdate(gameTime);
                    if (this.temporary.Count != control)
                    {
                        i--;
                    }
                }
                foreach (Enemy e in this.enemies)
                {
                    e.OnUpdate(gameTime);
                }
                foreach (NPC n in this.NPCs)
                {
                    n.OnUpdate();
                }
            }
        }
    }
}

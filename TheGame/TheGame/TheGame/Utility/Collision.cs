using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects;
using TheGame.Objects.Characters;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public class Collision
    {
        private Map map;
        private List<NPC> NPCs;
        List<Enemy> enemies;
        public Player Player { get; private set; }

        public Collision(Map map, List<NPC> NPCs, List<Enemy> enemies, Player player)
        {
            this.map = Access.Gamebody.returnMap();
            this.NPCs = NPCs;
            this.enemies = enemies;
            this.Player = player;
        }
        public void MovePlayer(Vector vector)
        {
            if (!map.terrain.Where(x => 
                x.Coordinates.x <= this.Player.Coordinates.x + vector.x + 0.5 &&
                x.Coordinates.x >= this.Player.Coordinates.x + vector.x - 0.5 &&
                x.Coordinates.y <= this.Player.Coordinates.y + vector.y + 0.5 &&
                x.Coordinates.y >= this.Player.Coordinates.y + vector.y - 0.5
                ).Any())
            {
                if (vector.x > 0)
                {
                    this.Player.ChangeDirection(true);
                }
                else if (vector.x < 0)
                {
                    this.Player.ChangeDirection(false);
                }
                
                this.Player.Coordinates.x += (float)(vector.x * this.Player.speed);
                this.Player.Coordinates.y += (float)(vector.y * this.Player.speed);
            }
        }
        public void Attack()
        {
            if (this.Player.isFacingRight)
            {
                List<Enemy> en = Access.Gamebody.returnEnemies().Where(x =>
                    x.Coordinates.x <= this.Player.Coordinates.x + 1 &&
                    x.Coordinates.x >= this.Player.Coordinates.x &&
                    x.Coordinates.y <= this.Player.Coordinates.y + 1 &&
                    x.Coordinates.y >= this.Player.Coordinates.y - 1).ToList();
                foreach (Enemy e in en)
                {
                    e.TakeDmg(this.Player.DealDmg());
                }
            }
            else
            {
                List<Enemy> en = Access.Gamebody.returnEnemies().Where(x =>
                    x.Coordinates.x <= this.Player.Coordinates.x &&
                    x.Coordinates.x >= this.Player.Coordinates.x - 1 &&
                    x.Coordinates.y <= this.Player.Coordinates.y + 1 &&
                    x.Coordinates.y >= this.Player.Coordinates.y - 1).ToList();
                foreach (Enemy e in en)
                {
                    e.TakeDmg(this.Player.DealDmg());
                }
            }
        }
        public void ActivateTile()
        {
            try
            {
                if (this.Player.isFacingRight)
                {
                    try
                    {
                        map.terrain.Where(terrain =>
                            terrain.Coordinates.x <= this.Player.Coordinates.x + 1 &&
                            terrain.Coordinates.x >= this.Player.Coordinates.x &&
                            terrain.Coordinates.y <= this.Player.Coordinates.y + 0.5 &&
                            terrain.Coordinates.y >= this.Player.Coordinates.y - 0.5
                            ).FirstOrDefault().OnActivation();
                    }
                    catch
                    {
                        try
                        {
                            map.Dropped.Where(terrain =>
                                terrain.Coordinates.x <= this.Player.Coordinates.x + 1 &&
                                terrain.Coordinates.x >= this.Player.Coordinates.x &&
                                terrain.Coordinates.y <= this.Player.Coordinates.y + 0.5 &&
                                terrain.Coordinates.y >= this.Player.Coordinates.y - 0.5
                                ).FirstOrDefault().OnActivation();
                        }
                        catch
                        {
                            this.NPCs.Where(npc =>
                                npc.Coordinates.x <= this.Player.Coordinates.x + 2 &&
                                npc.Coordinates.x >= this.Player.Coordinates.x &&
                                npc.Coordinates.y <= this.Player.Coordinates.y + 0.5 &&
                                npc.Coordinates.y >= this.Player.Coordinates.y - 0.5
                                ).FirstOrDefault().OnActivation();
                        }
                    }
                }
                else
                {
                    try
                    {
                        map.terrain.Where(terrain =>
                            terrain.Coordinates.x <= this.Player.Coordinates.x &&
                            terrain.Coordinates.x >= this.Player.Coordinates.x - 1 &&
                            terrain.Coordinates.y <= this.Player.Coordinates.y + 0.5 &&
                            terrain.Coordinates.y >= this.Player.Coordinates.y - 0.5
                            ).FirstOrDefault().OnActivation();
                    }
                    catch
                    {
                        this.NPCs.Where(npc =>
                            npc.Coordinates.x <= this.Player.Coordinates.x &&
                            npc.Coordinates.x >= this.Player.Coordinates.x - 2 &&
                            npc.Coordinates.y <= this.Player.Coordinates.y + 0.5 &&
                            npc.Coordinates.y >= this.Player.Coordinates.y - 0.5
                            ).FirstOrDefault().OnActivation();
                    }      
                } 
            }
            catch
            {

            }
        }
    }
}

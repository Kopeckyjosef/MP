using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects;
using TheGame.Objects.Characters;
using TheGameNamespace.GameObjects;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public static class Collision
    {
        private static Map map;
        private static List<NPC> NPCs;
        public static List<Enemy> enemies;
        public static Player Player { get; private set; }

        public static void Init()
        {
            map = Access.Gamebody.returnMap();
            NPCs = Access.Gamebody.returnNPCs();
            enemies = Access.Gamebody.returnEnemies();
            Player = GraficStuff.Player;
        }
        public static void newMap(GameBody gb)
        {
            map = gb.returnMap();
            NPCs = gb.returnNPCs();
            enemies = gb.returnEnemies();
        }
        public static void MovePlayer(Vector vector)
        {
            if (!map.terrain.Where(x => 
                x.Coordinates.x <= Player.Coordinates.x + vector.x + 0.5 &&
                x.Coordinates.x >= Player.Coordinates.x + vector.x - 1 &&
                x.Coordinates.y <= Player.Coordinates.y + vector.y + 0.5 &&
                x.Coordinates.y >= Player.Coordinates.y + vector.y - 0.5
                ).Any())
            {
                if (vector.x > 0)
                {
                    Player.ChangeDirection(true);
                }
                else if (vector.x < 0)
                {
                    Player.ChangeDirection(false);
                }
                
                Player.Coordinates.x += (float)(vector.x);
                Player.Coordinates.y += (float)(vector.y);
            }
            else
            {
                string a = "";
            }
        }
        public static void Attack()
        {
            Access.Gamebody.returnTemporary().Add(TemporaryCreater.returnWeaponSlash(GraficStuff.Player.isFacingRight, GraficStuff.Player.Coordinates));
            if (Player.isFacingRight)
            {
                List<Enemy> en = Access.Gamebody.returnEnemies().Where(x =>
                    x.Coordinates.x <= Player.Coordinates.x + 1 &&
                    x.Coordinates.x >= Player.Coordinates.x &&
                    x.Coordinates.y <= Player.Coordinates.y + 1 &&
                    x.Coordinates.y >= Player.Coordinates.y - 1).ToList();
                foreach (Enemy e in en)
                {
                    e.TakeDmg(Player.DealDmg());
                }
            }
            else
            {
                List<Enemy> en = Access.Gamebody.returnEnemies().Where(x =>
                    x.Coordinates.x <= Player.Coordinates.x &&
                    x.Coordinates.x >= Player.Coordinates.x - 1 &&
                    x.Coordinates.y <= Player.Coordinates.y + 1 &&
                    x.Coordinates.y >= Player.Coordinates.y - 1).ToList();
                foreach (Enemy e in en)
                {
                    e.TakeDmg(Player.DealDmg());
                }
            }
        }
        public static void ActivateTile()
        {
            try
            {
                if (Player.isFacingRight)
                {
                    try
                    {
                        var a = map.Teleports.Where(terrain =>
                            terrain.Coordinates.x <= Player.Coordinates.x + 1 &&
                            terrain.Coordinates.x >= Player.Coordinates.x &&
                            terrain.Coordinates.y <= Player.Coordinates.y + 0.7 &&
                            terrain.Coordinates.y >= Player.Coordinates.y - 0.7
                            ).FirstOrDefault();
                        a.OnActivation();
                    }
                    catch
                    {
                        try
                        {
                            map.Dropped.Where(terrain =>
                                terrain.Coordinates.x <= Player.Coordinates.x + 1 &&
                                terrain.Coordinates.x >= Player.Coordinates.x &&
                                terrain.Coordinates.y <= Player.Coordinates.y + 0.7 &&
                                terrain.Coordinates.y >= Player.Coordinates.y - 0.7
                                ).FirstOrDefault().OnActivation();
                        }
                        catch
                        {
                            try
                            {
                                map.Chests.Where(terrain =>
                                    terrain.Coordinates.x <= Player.Coordinates.x + 1 &&
                                    terrain.Coordinates.x >= Player.Coordinates.x &&
                                    terrain.Coordinates.y <= Player.Coordinates.y + 0.7 &&
                                    terrain.Coordinates.y >= Player.Coordinates.y - 0.7
                                    ).FirstOrDefault().OnActivation();
                            }
                            catch
                            {
                                NPCs.Where(npc =>
                                    npc.Coordinates.x <= Player.Coordinates.x + 2 &&
                                    npc.Coordinates.x >= Player.Coordinates.x &&
                                    npc.Coordinates.y <= Player.Coordinates.y + 0.7 &&
                                    npc.Coordinates.y >= Player.Coordinates.y - 0.7
                                    ).FirstOrDefault().OnActivation();
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        var a = map.Teleports.Where(terrain =>
                            terrain.Coordinates.x <= Player.Coordinates.x &&
                            terrain.Coordinates.x >= Player.Coordinates.x - 2 &&
                            terrain.Coordinates.y <= Player.Coordinates.y + 0.7 &&
                            terrain.Coordinates.y >= Player.Coordinates.y - 0.7
                            ).FirstOrDefault();
                        a.OnActivation();
                    }
                    catch
                    {
                        try
                        {
                            var suitable = map.Dropped.Where(terrain =>
                                    terrain.Coordinates.x <= Player.Coordinates.x &&
                                    terrain.Coordinates.x >= Player.Coordinates.x - 1 &&
                                    terrain.Coordinates.y <= Player.Coordinates.y + 0.7 &&
                                    terrain.Coordinates.y >= Player.Coordinates.y - 0.7
                                    ).FirstOrDefault();
                            suitable.OnActivation();
                        }
                        catch
                        {
                            try
                            {
                                var suitable = map.Chests.Where(terrain =>
                                    terrain.Coordinates.x <= Player.Coordinates.x &&
                                    terrain.Coordinates.x >= Player.Coordinates.x - 1 &&
                                    terrain.Coordinates.y <= Player.Coordinates.y + 0.7 &&
                                    terrain.Coordinates.y >= Player.Coordinates.y - 0.7
                                    ).FirstOrDefault();
                                suitable.OnActivation();
                            }
                            catch
                            {
                                NPCs.Where(npc =>
                                    npc.Coordinates.x <= Player.Coordinates.x &&
                                    npc.Coordinates.x >= Player.Coordinates.x - 2 &&
                                    npc.Coordinates.y <= Player.Coordinates.y + 0.7 &&
                                    npc.Coordinates.y >= Player.Coordinates.y - 0.7
                                    ).FirstOrDefault().OnActivation();
                            }
                        }
                    }   
                } 
            }
            catch
            {

            }
        }
    }
}

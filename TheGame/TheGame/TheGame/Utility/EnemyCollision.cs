using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Objects;
using TheGame.Objects.Characters;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public static class EnemyCollision
    {
        public static void GoForPlayer(Enemy enemy, GameTime gameTime)
        {
            float x = GraficStuff.Player.Coordinates.x - enemy.Coordinates.x;
            float y = GraficStuff.Player.Coordinates.y - enemy.Coordinates.y;
            double range = Math.Sqrt(x * x + y * y);
            enemy.Timer += gameTime.ElapsedGameTime.Milliseconds;

            if (range > 1.5)
            {
                if (x > 0)
                {
                    enemy.Coordinates.x += (float)(gameTime.ElapsedGameTime.Milliseconds * enemy.speed / 1000);
                }
                if (y > 0)
                {
                    enemy.Coordinates.y += (float)(gameTime.ElapsedGameTime.Milliseconds * enemy.speed / 1000 / 2);
                }
                if (x < 0)
                {
                    enemy.Coordinates.x -= (float)(gameTime.ElapsedGameTime.Milliseconds * enemy.speed / 1000);
                }
                if (y < 0)
                {
                    enemy.Coordinates.y -= (float)(gameTime.ElapsedGameTime.Milliseconds * enemy.speed / 1000 / 2);
                }
            }        

            if (enemy.Timer >= 1000 && range < 1.5)
            {
                enemy.DealDmg(GraficStuff.Player);
            }

            return;

            if (enemy.Timer >= 500)
            {
                enemy.CurrentPath = FindPlayer(enemy);
            }
            else
            {
                float pointCoordinateX;
                float pointCoordinateY;
                try
                {
                    pointCoordinateX = enemy.CurrentPath.Origins[0].Coordinates.x;
                    pointCoordinateY = enemy.CurrentPath.Origins[0].Coordinates.y;
                }
                catch
                {
                    return;
                }
                if (pointCoordinateX > enemy.Coordinates.x - 0.35 &&
                    pointCoordinateX < enemy.Coordinates.x + 0.35 &&
                    pointCoordinateY > enemy.Coordinates.y - 0.35 &&
                    pointCoordinateY < enemy.Coordinates.y + 0.35)
                {
                    enemy.CurrentPath.Origins.Remove(enemy.CurrentPath.Origins[0]);
                    pointCoordinateX = enemy.CurrentPath.Origins[0].Coordinates.x;
                    pointCoordinateY = enemy.CurrentPath.Origins[0].Coordinates.y;
                }

                if (pointCoordinateX > enemy.Coordinates.x)
                {
                    enemy.Coordinates.x += (float)(gameTime.ElapsedGameTime.Milliseconds * enemy.speed / 1000);
                }
                if (pointCoordinateY > enemy.Coordinates.y)
                {
                    enemy.Coordinates.y += (float)(gameTime.ElapsedGameTime.Milliseconds * enemy.speed / 1000 / 2);
                }
                if (pointCoordinateX < enemy.Coordinates.x)
                {
                    enemy.Coordinates.x -= (float)(gameTime.ElapsedGameTime.Milliseconds * enemy.speed / 1000);
                }
                if (pointCoordinateY < enemy.Coordinates.y)
                {
                    enemy.Coordinates.y -= (float)(gameTime.ElapsedGameTime.Milliseconds * enemy.speed / 1000 / 2);
                }
            }
        }
        public static WavePoint FindPlayer(Enemy enemy)
        {
            WavePoint firstWP = new WavePoint(enemy.Coordinates.x, enemy.Coordinates.y, new List<WavePoint>());
            List<WavePoint> wavePoints = new List<WavePoint>();
            List<WavePoint> usedWavePoints = new List<WavePoint>();
            List<WavePoint> newWavePoints = new List<WavePoint>();
            wavePoints.Add(firstWP);
            for (int i = 0; i < 10 ; i++)
            {
                foreach (WavePoint wp in wavePoints)
                {
                    WavePoint[] newWavePointsPack = wp.Spread();
                    foreach (WavePoint w in newWavePointsPack)
                    {
                        if (GraficStuff.Player.Coordinates.x <= w.Coordinates.x + 0.5 &&
                            GraficStuff.Player.Coordinates.x >= w.Coordinates.x - 0.5 &&
                            GraficStuff.Player.Coordinates.y <= w.Coordinates.y + 0.5 &&
                            GraficStuff.Player.Coordinates.y >= w.Coordinates.y - 0.5)
                        {
                            return w;
                        }
                        else if (usedWavePoints.Where(x => x.Coordinates.x == w.Coordinates.x && x.Coordinates.y == w.Coordinates.y).Any())
                        {
                            continue;
                        }
                        else if (wavePoints.Where(x => x.Coordinates.x == w.Coordinates.x && x.Coordinates.y == w.Coordinates.y).Any())
                        {
                            continue;
                        }
                        else if (newWavePoints.Where(x => x.Coordinates.x == w.Coordinates.x && x.Coordinates.y == w.Coordinates.y).Any())
                        {
                            continue;
                        }
                        else if (Access.Gamebody.returnMap().terrain.Where(terrain =>
                                terrain.Coordinates.x <= w.Coordinates.x + 0.5 &&
                                terrain.Coordinates.x >= w.Coordinates.x - 0.5 &&
                                terrain.Coordinates.y <= w.Coordinates.y + 0.5 &&
                                terrain.Coordinates.y >= w.Coordinates.y - 0.5
                                ).Any())
                        {
                            continue;
                        }
                        else
                        {
                            newWavePoints.Add(w);
                        }
                    }
                }
                foreach (WavePoint w in wavePoints)
                {
                    usedWavePoints.Add(w);
                }
                wavePoints = newWavePoints;
                newWavePoints = new List<WavePoint>();
            }
            return null;
        }
    }
    public class WavePoint
    {
        public Coordinates Coordinates;
        public List<WavePoint> Origins;

        public WavePoint(float x, float y, List<WavePoint> l)
        {
            this.Coordinates.x = x;
            this.Coordinates.y = y;
            this.Origins = new List<WavePoint>();
            foreach (WavePoint w in l)
            {
                this.Origins.Add(w);
            }
        }
        public WavePoint[] Spread()
        {
            this.Origins.Add(this);
            WavePoint[] w = new WavePoint[4];
            w[0] = new WavePoint(this.Coordinates.x + 1, this.Coordinates.y, this.Origins);
            w[1] = new WavePoint(this.Coordinates.x, this.Coordinates.y + 1, this.Origins);
            w[2] = new WavePoint(this.Coordinates.x - 1, this.Coordinates.y, this.Origins);
            w[3] = new WavePoint(this.Coordinates.x, this.Coordinates.y - 1, this.Origins);
            return w;
        }
    }
}

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
        public static void GoForPlayer(Enemy enemy)
        {
            WavePoint wp = FindPlayer(enemy);
            if (wp != null)
            {     
                try
                {
                    
                    Vector v = new Vector(wp.Origins[0].Coordinates.x - wp.Origins[1].Coordinates.x, wp.Origins[0].Coordinates.y - wp.Origins[1].Coordinates.y);
                    enemy.Coordinates.x -= (float)(enemy.speed * v.x);
                    enemy.Coordinates.y -= (float)(enemy.speed * v.y);
                    /*enemy.Coordinates.x = wp.Origins[1].Coordinates.x;
                    enemy.Coordinates.y = wp.Origins[1].Coordinates.y;*/
                }
                catch
                {

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

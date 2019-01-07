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
        private static Map map;
        public static Player Player  { get; private set; }

        public static void Initialize(Map map, Player player)
        {
            EnemyCollision.map = map;
            EnemyCollision.Player = player;
        }
        public static void MoveEnemy(Vector vector, Enemy enemy)
        {
            Coordinates way = EnemyCollision.findWay(enemy);

            enemy.Coordinates.x += way.x;
            enemy.Coordinates.y += way.y;

            /*if (!map.terrain.Where(x =>
                x.Coordinates.x <= enemy.coordinates.x + vector.x + 0.5 &&
                x.Coordinates.x >= enemy.coordinates.x + vector.x - 0.5 &&
                x.Coordinates.y <= enemy.coordinates.y + vector.y + 0.5 &&
                x.Coordinates.y >= enemy.coordinates.y + vector.y - 0.5
                ).Any())
            {
                enemy.coordinates.x += vector.x;
                enemy.coordinates.y += vector.y;
            }*/
        }
        private static Coordinates findWay(Enemy enemy)
        {
            List<WavePoint> old = new List<WavePoint>();
            List<WavePoint> last = new List<WavePoint>();

            old.Add(new WavePoint(enemy.Coordinates.x, enemy.Coordinates.y, new List<WavePoint>()));

            for (int i = 0; i < 50; i++)
            {
                foreach (WavePoint w in old)
                {
                    WavePoint[] points = w.Spread();

                    foreach (WavePoint point in points)
                    {
                        if (old.Where(x => x.Coordinates.x == point.Coordinates.x && x.Coordinates.y == point.Coordinates.y).Any())
                        {
                            continue;
                        }
                        if (last.Where(x => x.Coordinates.x == point.Coordinates.x && x.Coordinates.y == point.Coordinates.y).Any())
                        {
                            continue;
                        }
                        if (!map.terrain.Where(x =>
                            x.Coordinates.x <= point.Coordinates.x + 0.5 &&
                            x.Coordinates.x >= point.Coordinates.x - 0.5 &&
                            x.Coordinates.y <= point.Coordinates.y + 0.5 &&
                            x.Coordinates.y >= point.Coordinates.y - 0.5
                            ).Any())
                        {
                            last.Add(point);
                        }
                        if (
                            GraficStuff.Player.Coordinates.x <= point.Coordinates.x + 0.5 &&
                            GraficStuff.Player.Coordinates.x >= point.Coordinates.x - 0.5 &&
                            GraficStuff.Player.Coordinates.y <= point.Coordinates.y + 0.5 &&
                            GraficStuff.Player.Coordinates.y >= point.Coordinates.y - 0.5
                           )
                        {
                            return new Coordinates(point.Origins[0].Coordinates.x, point.Origins[0].Coordinates.y);
                        }
                    }
                }
                old = last;
                last = new List<WavePoint>();
            }
            return new Coordinates(enemy.Coordinates.x, enemy.Coordinates.y);
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
            this.Origins = l;
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

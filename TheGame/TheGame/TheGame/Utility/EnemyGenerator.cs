using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TheGame.Objects;
using TheGameNamespace.Objects;

namespace TheGame.Utility
{
    public static class EnemyGenerator
    {
        public static List<Enemy> LoadEnemies(string mapName)
        {
            string path = "..\\..\\..\\Maps\\MapEnemies\\";
            StreamReader sr;
            try
            {
                sr = new StreamReader(path + mapName + ".csv");
            }
            catch
            {
                return new List<Enemy>();
            }

            List<Enemy> enemies = new List<Enemy>();
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] data = line.Split(';');
                enemies.Add(GenerateEnemy(new Coordinates(float.Parse(data[1]), float.Parse(data[2])), data[0], GraficStuff.Player.Level));
            }
            return enemies;
        }
        public static Enemy GenerateEnemy(Coordinates coordinates, string textureName, int level)
        {
            Enemy enemy = new Enemy(coordinates, textureName);
            Random r = new Random();
            enemy.Level = level + r.Next(1, 6);
            enemy.MaximumHealth = enemy.Level * 15 + 100;
            enemy.Health = enemy.Level * 15 + 100;
            enemy.MaximumStamina = enemy.Level * 9 + 50;
            enemy.Stamina = enemy.Level * 9 + 50;
            // ADD Equip

            //

            return enemy;
        }
    }
}

using System.Collections.Generic;
using TheGame.Objects;
using System.Linq;
using TheGame.Utility;
using TheGameNamespace.Objects.MapObject;
using TheGame.Objects.MapObject.FloorObject;

namespace TheGameNamespace.Objects
{
    public class Map
    {
        public Map(List<Terrain> allObjects)
        {
            this.allObjects = allObjects;
            this.floor = new List<Terrain>();
            this.terrain = new List<Terrain>();
            this.Dropped = new List<Dropped>();
        }
        public List<Terrain> allObjects;
        public List<Terrain> terrain;
        public List<Terrain> floor;
        public List<Dropped> Dropped;

        public void Draw(List<Enemy> enemies, List<NPC> npcs)
        {
            List<object> alreadyDrawn = new List<object>();
            List<object> everything = new List<object>();
            foreach (Enemy e in enemies)
            {
                everything.Add((object)e);
            }
            foreach (NPC n in npcs)
            {
                everything.Add((object)n);
            }
            foreach (Dropped d in this.Dropped)
            {
                everything.Add((object)d);
            }
            foreach (Terrain t in this.allObjects)
            {
                everything.Add((object)t);
            }
            everything.Add((object)GraficStuff.Player);
            everything.Sort();

            foreach (HasCoordinates o in everything)
            {
                if (o is Character)
                {
                    var list = everything
                        .Where(x => x is Terrain)
                        .Select(x => (Terrain)x)
                        .Where(x => x.Coordinates.y < o.Coordinates.y + 1 && x.Coordinates.y > o.Coordinates.y && x.Coordinates.x < o.Coordinates.x + 0.8 && x.Coordinates.x > o.Coordinates.x - 0.8)
                        .ToList();
                    foreach (Terrain t in list)
                    {
                        if (!t.IsCrossable)
                        {
                            continue;
                        }
                        if (!alreadyDrawn.Contains(t))
                        {
                            alreadyDrawn.Add(t);
                            t.Draw();
                        }
                    }
                }
                if (!alreadyDrawn.Contains(o))
                {
                    o.Draw();
                }
            }
        }
        public void Initialize()
        {
            for (int i = 0; i < this.allObjects.Count; i++)
            {
                this.allObjects[i].Initialize();
                if (this.allObjects[i].IsCrossable)
                {
                    this.floor.Add(this.allObjects[i]);
                }
                else
                {
                    this.terrain.Add(this.allObjects[i]);
                }
            }
            this.allObjects.Sort();
        }
    }
}

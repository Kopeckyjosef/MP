using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Objects
{
    public class Roam
    {
        private Vector way;
        private bool isMovingForward;
        private int stage;
        private int time;

        public Roam(Vector way, int time)
        {
            this.way = way;
            this.time = time;
            this.isMovingForward = true;
            this.stage = 0;
        }
        public Vector OnUpdate()
        {
            if (this.isMovingForward)
            {
                stage++;
                if (this.stage == this.time)
                {
                    this.isMovingForward = !this.isMovingForward;
                }
                return new Vector(this.way.x / this.time, this.way.y / this.time);
            }
            else
            {
                stage--;
                if (this.stage == 0)
                {
                    this.isMovingForward = !this.isMovingForward;
                }
                return new Vector(this.way.x / this.time * -1, this.way.y / this.time * -1);
            }
        }
    }
}

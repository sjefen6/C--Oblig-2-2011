using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    abstract class GameObject
    {
        protected float xCoord, yCoord;

        public float XCoord
        {
            get { return xCoord; }
            set { xCoord = value; }
        }

        public float YCoord
        {
            get { return yCoord; }
            set { yCoord = value; }
        }

        public abstract Rectangle getRect();

        public abstract void draw(Graphics g);

    }
}

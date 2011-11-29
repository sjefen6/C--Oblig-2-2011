using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    abstract class GameObject
    {
        protected double xCoord, yCoord, shieldRadius;
        protected GamePanel _MyPanel;

        public double XCoord
        {
            get { return xCoord; }
            set { xCoord = value; }
        }

        public double YCoord
        {
            get { return yCoord; }
            set { yCoord = value; }
        }

        public abstract void draw(Graphics g);

    }
}

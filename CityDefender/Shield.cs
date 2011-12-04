using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    class Shield : GameObject
    {
        protected static bool shield;
        private int hitPoints;

        public Shield(GamePanel _MyPanel)
        {
            hitPoints = 3;
        }
        
        public int HitPoints
        {
            set { hitPoints = value; }
            get { return hitPoints; }
        }

        public bool ShieldActive
        {
            get { return shield; }
            set { shield = value; }
        }

        public static void disableShield()
        {
            shield = false;
        }

        public override void draw(Graphics g)
        {
            g.DrawEllipse(Pens.Black, -100f, 400f, 800f, 800f);
        }

        public override Rectangle getRect()
        {
            throw new NotImplementedException();
        }
    }
}

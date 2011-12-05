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
        Rectangle[] rects = new Rectangle[96];

        public Shield(GamePanel _MyPanel)
        {
            hitPoints = 3;
            shield = true;

            for (int i = 0; i < 96; i++)
            {
                rects[i] = new Rectangle((int)(300 + (400 * Math.Cos(Math.PI * 2 * i / 96))), (int)(800 + (400 * Math.Sin(Math.PI * 2 * i / 96))), 20, 20);
            }
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
            if (shield)
            {
                for (int i = 0; i < hitPoints; i++)
                {
                    g.DrawEllipse(Pens.Black, -100f - i, 400f - i, 800f + 2*i, 800f + 2*i);
                }
            }
        }

        public override Rectangle getRect()
        {
            return Rectangle.FromLTRB(-100, 400, 700, 800);          
        }

        public Rectangle[] getRects()
        {
            return rects;
        }
    }
}

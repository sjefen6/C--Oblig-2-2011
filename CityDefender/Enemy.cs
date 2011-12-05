using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    class Enemy : GameObject
    {
        private Image enemyImage;
        private double velocity;
        private static Random r = new Random((int)DateTime.Now.Ticks);
        //Låsobjekt
        private Object lobj = new Object();

        public Boolean Active { get; set; }

        //Konstruktør
        public Enemy()
        {
            XCoord = 1.0f + r.Next(600 - enemyImage.Width);
            YCoord = 1.0f;
            velocity = 1;

            Active = true;
            enemyImage = global::CityDefender.Properties.Resources.cat;
        }

        public override Rectangle getRect()
        {
            lock (lobj)
            {
                return new Rectangle((int)XCoord, (int)YCoord, enemyImage.Width, enemyImage.Height);
            }
        }

        public override void draw(System.Drawing.Graphics g)
        {
            if (Active)
            {
                //Beveger seg rett før den blir tegnet
                YCoord += (float)velocity;
                g.DrawImage(enemyImage, (int)XCoord, (int)YCoord);
            }
        }
    }
}

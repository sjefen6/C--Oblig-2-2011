using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    class Enemy : GameObject
    {
        private Image enemyImage = global::CityDefender.Properties.Resources.cat;
        private double velocity;
        private static Random r = new Random((int)DateTime.Now.Ticks);

        public Boolean Active { get; set; }

        public Enemy()
        {
            XCoord = 1.0f + r.Next(600);
            YCoord = 1.0f;

            velocity = 1;
            Active = true;
        }

        public Enemy(float startX, float startY, double startVelocity)
        {
            XCoord = startX;
            YCoord = startY;

            velocity = startVelocity;
        }

        public override Rectangle getRect()
        {
            return new Rectangle((int) XCoord,(int) YCoord, enemyImage.Width, enemyImage.Height);
        }

        public override void draw(System.Drawing.Graphics g)
        {
            if (Active)
            {
                YCoord += (float)velocity;
                g.DrawImage(enemyImage, (int)XCoord, (int)YCoord);
            }
        }


    }
}

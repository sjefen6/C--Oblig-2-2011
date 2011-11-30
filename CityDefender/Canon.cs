using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace CityDefender
{
    class Canon : GameObject
    {
        private double angle;
        private GamePanel _GamePanel;
        private bool shield;

        public Canon(GamePanel _GamePanel)
        {
            this._GamePanel = _GamePanel;
            //TODO: Get from _GamePanel shield status
            shield = true;
            angle = Math.PI * 3/2;
//            xCoord = panelSize().Width / 2;
//            yCoord = panelSize().Height / 6;
//            xCoord = 285f;
//            yCoord = 360f;

            xCoord = (float)(300 + (400 * Math.Cos(angle))) - 15f;
            yCoord = (float)(800 + (400 * Math.Sin(angle))) - 40f;

            //i = Image.FromFile("arrow.png");

            //p[0].X = (int)xCoord; p[0].Y = (int)yCoord - 10;
            //p[1].X = (int)xCoord - 5; p[1].Y = (int)yCoord;
            //p[2].X = (int)xCoord + 5; p[2].Y = (int)yCoord;

        }

        private Size panelSize()
        {
            return _GamePanel.ClientRectangle.Size;
        }

        public void moveLeft()
        {
            if (shield)
            {
                
            }
            else
            {
                xCoord--;
            }
        }

        public void moveRight()
        {
            if (shield)
            {
                angle = angle + Math.PI / 6;
                xCoord = (float)(300 + (400 * Math.Cos(angle))) - 15f;
                yCoord = (float)(800 + (400 * Math.Sin(angle))) - 40f;
            }
            else
            {
                xCoord++;
            }
        }

        public void shieldDisabled()
        {
            shield = false;
        }

        public override void draw(Graphics g)
        {
            g.DrawImage(Image.FromFile(@"C:\Users\Daniel\Documents\Skole\HiN\Programmering i C#\Oblig6\GitHubClone\C--Oblig-2-2011\CityDefender\arrow.png"), xCoord, yCoord, 30, 40);
        }
    }
}

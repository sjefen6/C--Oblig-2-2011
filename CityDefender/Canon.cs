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

            xCoord = (float)(300 + (400 * Math.Cos(angle))) - 15f;
            yCoord = (float)(800 + (400 * Math.Sin(angle))) - 40f;
        }

        private Size panelSize()
        {
            return _GamePanel.ClientRectangle.Size;
        }

        public void moveLeft()
        {
            if (shield)
            {
                if (angle > Math.PI * 4 / 3)
                {
                    angle = angle - Math.PI / 48;
                    xCoord = (float)(300 + (400 * Math.Cos(angle))) - 15f;
                    yCoord = (float)(800 + (400 * Math.Sin(angle))) - 40f;
                } 
            }
            else
            {
                if(xCoord > 0)
                    xCoord--;
            }
        }

        public void moveRight()
        {
            if (shield)
            {
                if (angle < Math.PI * 5 / 3)
                {
                    angle = angle + Math.PI / 48;
                    xCoord = (float)(300 + (400 * Math.Cos(angle))) - 15f;
                    yCoord = (float)(800 + (400 * Math.Sin(angle))) - 40f;
                }
            }
            else
            {
                if (xCoord < 600)
                xCoord++;
            }
        }

        public void shieldDisabled()
        {
            shield = false;
        }

        public override void draw(Graphics g)
        {
            g.DrawImage(Image.FromFile(@"C:\Users\Daniel\Documents\Skole\HiN\Programmering i C#\Oblig6\GitClone\C--Oblig-2-2011\CityDefender\arrow.png"), xCoord, yCoord, 30, 40);
        }
    }
}

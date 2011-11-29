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
        private float angle;
        private GamePanel _GamePanel;
        private bool shield;
        Point[] p = new Point[3];

        public Canon(GamePanel _GamePanel)
        {
            this._GamePanel = _GamePanel;
            //TODO: Get from _GamePanel shield status
            shield = true;
            xCoord = panelSize().Width / 2;
            yCoord = panelSize().Height / 6;

            p[0].X = (int)xCoord; p[0].Y = (int)yCoord - 10;
            p[1].X = (int)xCoord - 5; p[1].Y = (int)yCoord;
            p[2].X = (int)xCoord + 5; p[2].Y = (int)yCoord;

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
            //Graphics.FillPolygon(Brushes.Green, p);
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    class House : GameObject
    {
        private GamePanel _GamePanel;
        private int houseNr, totalHouseNr, etg;
        Random r = new Random();

        public House(GamePanel _GamePanel, int houseNr, int totalHouseNr)
        {
            this._GamePanel = _GamePanel;
            this.houseNr = houseNr;
            this.totalHouseNr = totalHouseNr;
            etg = 4 + r.Next(10);
            xCoord = (_GamePanel.ClientRectangle.Size.Width / totalHouseNr) * (houseNr + 1);
            yCoord = _GamePanel.ClientRectangle.Size.Height;
        }

        public override void draw(Graphics g)
        {
            Image newImage = Image.FromFile("etg.png");
            for(int i = 0; i <= etg; i++)
            {
                Point ulCorner = new Point(100, 100);
                g.DrawImage(newImage, ulCorner);
            }

            throw new NotImplementedException();
        }
    }
}

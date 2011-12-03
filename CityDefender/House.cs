using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

namespace CityDefender
{
    class House : GameObject
    {
        private GamePanel _GamePanel;
        public static bool r1count = false;
        private int houseNr, totalHouseNr, etg;
        Random r = new Random((int)DateTime.Now.Ticks);

        private int HOUSEHEIGHT = 10, HOUSEWIDTH = 34;

        public House(GamePanel _GamePanel, int houseNr, int totalHouseNr)
        {
            this._GamePanel = _GamePanel;
            this.houseNr = houseNr;
            this.totalHouseNr = totalHouseNr;
            etg = 4 + r.Next(10);

            //Bredde 600, høyde 538, får ikke dritten til å funke så hardkoder det...
            int houseSpaceing = 5;
            xCoord = (538 / 2) - ((houseSpaceing + HOUSEWIDTH) * totalHouseNr) / 2 + (houseNr * (HOUSEWIDTH + houseSpaceing));
            yCoord = 600;


            // This is some broken C# shit
            //xCoord = (_GamePanel.ClientRectangle.Size.Width / totalHouseNr) * (houseNr + 1);
            //yCoord = _GamePanel.ClientRectangle.Size.Height;
        }

        public override void draw(Graphics g)
        {
            Image newImage = global::CityDefender.Properties.Resources.etg; ;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            for (int i = 0; i <= etg; i++)
            {
                g.DrawImage(newImage, (int)xCoord, (int)yCoord - (HOUSEHEIGHT * (i + 1)), HOUSEWIDTH, HOUSEHEIGHT);
            }
            if (!r1count)
            {
                g.DrawString("xCoord " + xCoord + " yCoord " + yCoord, new Font("Arial", 16), new SolidBrush(Color.Black), (int)100, (int)100);
                r1count = true;
            }
            //throw new NotImplementedException();
        }
    }
}

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
        private String path = @"C:\Users\sjefen6\skole\datatek2\Programmering i C#\CityDefender_git\C--Oblig-2-2011\CityDefender\";
        private int houseNr, totalHouseNr, etg;
        Random r = new Random();

        private int HOUSEHEIGHT = 12, HOUSEWIDTH = 34;

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
            Image newImage = Image.FromFile(@"C:\Users\sjefen6\skole\datatek2\Programmering i C#\CityDefender_git\C--Oblig-2-2011\CityDefender\etg.png");
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            for(int i = 0; i <= etg; i++)
            {
                g.DrawImage(newImage, (int) xCoord, (int)(yCoord + (HOUSEHEIGHT * (i+1))), HOUSEWIDTH, HOUSEHEIGHT);
            }

            //throw new NotImplementedException();
        }
    }
}

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
        //Statiske instillinger for hvordan husene skal se ut
        private int HOUSEHEIGHT = 12, HOUSEWIDTH = 30, HOUSESPACING = 5;
        //Variabler som blir brukt
        private int houseNr, totalHouseNr, etg;
        private static Random r = new Random((int)DateTime.Now.Ticks);
        private Rectangle rect;
        private Image etgImage;

        public Boolean Active { set; get; }

        public House(int houseNr, int totalHouseNr)
        {
            this.houseNr = houseNr;
            this.totalHouseNr = totalHouseNr;
            Active = true;
            etgImage = global::CityDefender.Properties.Resources.etg;

            //Minimum 2 etasjer + tilfeldig antall etg opp til 6 (max 9 etg)
            etg = 3 + r.Next(6);

            //Bredde 600, høyde 538, desverre hardkodet...
            //Dette er en formel for å sentrere byen. Den finner mitten av panelet, og mitten av byen, og starter med hus 1 helt til venstre.
            xCoord = (600 / 2) - ((HOUSESPACING + HOUSEWIDTH) * totalHouseNr) / 2 + (houseNr * (HOUSEWIDTH + HOUSESPACING));
            yCoord = 538;

            rect = new Rectangle((int)xCoord, (int)yCoord - (HOUSEHEIGHT * (etg + 1)), HOUSEWIDTH, HOUSEHEIGHT * (etg + 1));
        }

        public override Rectangle getRect()
        {
            return rect;
        }

        public override void draw(Graphics g)
        {
            if (Active)
            {
                // Vi tegner 1 og 1 etasje...
                for (int i = 0; i <= etg; i++)
                {
                    g.DrawImage(etgImage, (int)xCoord, (int)yCoord - (HOUSEHEIGHT * (i + 1)), HOUSEWIDTH, HOUSEHEIGHT);
                }
            }
        }
    }
}

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
        //Debug kode
        //public static bool r1count = false;
        private int houseNr, totalHouseNr, etg;
        /*
         * Ikke vet jeg hvorfor, men random generatoren må tydligvis være static
         * Mins 2 timer med irritasjon før jeg oppdaget det...
         */
        private static Random r = new Random((int)DateTime.Now.Ticks);

        private int HOUSEHEIGHT = 12, HOUSEWIDTH = 30, HOUSESPACING = 5;
        private Rectangle rect;

        public Boolean Active { set; get; }

        public House(GamePanel _GamePanel, int houseNr, int totalHouseNr)
        {
            this._GamePanel = _GamePanel;
            this.houseNr = houseNr;
            this.totalHouseNr = totalHouseNr;
            Active = true;

            //Minimum 2 etasjer + tilfeldig antall etg opp til 6
            etg = 3 + r.Next(6);

            //Bredde 600, høyde 538, får ikke dritten til å funke så hardkoder det...
            //Dette er en formel for å sentrere byen. Den finner mitten av panelet, og mitten av byen, og starter med hus 1 helt til venstre.
            xCoord = (600 / 2) - ((HOUSESPACING + HOUSEWIDTH) * totalHouseNr) / 2 + (houseNr * (HOUSEWIDTH + HOUSESPACING));
            yCoord = 538;

            rect = new Rectangle((int)xCoord, (int)yCoord, HOUSEWIDTH, HOUSEHEIGHT * etg);
        }

        public override Rectangle getRect()
        {
            return rect;
        }

        public override void draw(Graphics g)
        {
            Image newImage = global::CityDefender.Properties.Resources.etg;
            if (Active)
            {
                for (int i = 0; i <= etg; i++)
                {
                    g.DrawImage(newImage, (int)xCoord, (int)yCoord - (HOUSEHEIGHT * (i + 1)), HOUSEWIDTH, HOUSEHEIGHT);
                }
            }
            
            //Debug kode...
            /*if (!r1count)
            {
                g.DrawString("etg: " + etg + " yCoord " + yCoord, new Font("Arial", 16), new SolidBrush(Color.Black), (int)100, (int)100);
                r1count = true;
            }*/
        }
    }
}

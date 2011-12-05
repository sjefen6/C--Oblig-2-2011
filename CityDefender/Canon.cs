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
        Image newImage;

        public Canon(GamePanel _GamePanel)
        {
            this._GamePanel = _GamePanel;
            shield = true;
            angle = Math.PI * 3/2;

            newImage = global::CityDefender.Properties.Resources.arrow;

            xCoord = (float)(300 + (400 * Math.Cos(angle))) - 15f;
            yCoord = (float)(800 + (400 * Math.Sin(angle))) - 40f;
        }

        /*
         * returnerer vinkel
         */
        public double Angle
        {
            get { return angle; }
        }
        /*
         * returnerer og setter om skjoldet er aktivt eller ikke
         */
        public Boolean ActiveShield
        {
            get { return shield; }
            set { shield = value; }
        }

        /*
         * Beveger kanonen mot venstre
         */
        public void moveLeft()
        {
            //Beveger kanonen langs skjoldet dersom skjoldet er aktivt
            if (shield)
            {
                if (angle > Math.PI * 4 / 3)
                {
                    angle = angle - Math.PI / 96;
                    xCoord = (float)(300 + (400 * Math.Cos(angle))) - 15f;
                    yCoord = (float)(800 + (400 * Math.Sin(angle))) - 40f;
                } 
            }
            //Ellers beveger kanonen seg langs bakken
            else
            {
                if(xCoord > -15)
                    xCoord -= 8;
            }
        }

        /*
         * Beveger kanonen mot høyre
         */
        public void moveRight()
        {
            //Beveger kanonen langs skjoldet dersom skjoldet er aktivt
            if (shield)
            {
                if (angle < Math.PI * 5 / 3)
                {
                    angle = angle + Math.PI / 96;
                    xCoord = (float)(300 + (400 * Math.Cos(angle))) - 15f;
                    yCoord = (float)(800 + (400 * Math.Sin(angle))) - 40f;
                }
            }
            //Ellers beveger kanonen seg langs bakken
            else
            {
                if (xCoord < 585)
                xCoord += 8;
            }
        }

        /*
         * Når skjoldet går ned settes den nye posisjonen til kanonen
         */
        public void shieldDisabled()
        {
            shield = false;
            xCoord = 285f;
            yCoord = 498f;
            angle = Math.PI * 3 / 2;
        }

        /*
         * Tegner kanonen
         */
        public override void draw(Graphics g)
        {
            if (!shield)
            {
                g.DrawImage(newImage, xCoord, yCoord, 30, 40);
            }
            else
            {
                g.DrawLine(Pens.Black, 300f, 800f, xCoord + 15f, yCoord);
            }
        }

        //Denne metoden er ikke i bruk for denne klassen
        public override Rectangle getRect()
        {
            throw new NotImplementedException();
        }
    }
}

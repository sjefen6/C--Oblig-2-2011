using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace CityDefender
{
    public partial class GamePanel : Panel
    {
        Canon canon;
        Shield shield;
        List<House> house = new List<House>();
        List<Shot> shots = new List<Shot>();

        int numberOfHouses = 10;

        public Boolean activeShots{ get; set; }
        public Boolean activeDrawing { get; set; }

        public GamePanel()
        {
            canon = new Canon(this);
            shield = new Shield(this);

            for (int i = 0; i < numberOfHouses; i++)
            {
                house.Add(new House(this, i, numberOfHouses));
            }

            activeDrawing = true;

            this.SetStyle(ControlStyles.DoubleBuffer |
                            ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint,
                            true);
            this.UpdateStyles();

            Thread drawingGame = new Thread(new ThreadStart(drawing));
            drawingGame.Start();
        }

        //
        // Avfryrer et nytt skudd fra kanonen
        //
        public void fireShot()
        {
            shots.Add(new Shot(this, canon.XCoord, canon.YCoord, canon.Angle));
            if (!activeShots)
            {
                activeShots = true;
                Thread movingShots = new Thread(new ThreadStart(moveShots));
                movingShots.Start();
            }
        }

        //
        // Kontrollene for å bevege kanonen til høyre og venstre
        //
        public void canonMoveRight() { canon.moveRight(); }
        public void canonMoveLeft() { canon.moveLeft(); }

        //
        // Beveger alle skuddene som er avfyrt og sletter de som er utenfor panelet
        //
        public void moveShots()
        {
            List<Shot> tempShot = new List<Shot>();
            while (activeShots)
            {  
                foreach (Shot s in shots)
                {
                    s.moveShot();

                    if (!s.Active)
                        tempShot.Add(s);
                }
                foreach (Shot s in tempShot)
                    shots.Remove(s);

                tempShot.Clear();
                Thread.Sleep(24);
            }
        }

        //
        // Fyrer av et paint event slik at panelet tegnes
        //
        public void drawing()
        {
            while (activeDrawing)
            {       
                Invalidate();
                Thread.Sleep(24);
            }
        }

        //
        // Tegner panelet når et paint event blir avfyrt
        // 
        protected override void OnPaint(PaintEventArgs e)
        {
                canon.draw(e.Graphics);
                shield.draw(e.Graphics);

                foreach (House h in house)
                {
                    h.draw(e.Graphics);
                }

                foreach (Shot s in shots)
                    s.draw(e.Graphics);
        }
    }
}

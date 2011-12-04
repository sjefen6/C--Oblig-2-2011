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
        private Canon canon;
        private Shield shield;
        private List<House> house = new List<House>();
        private List<Shot> shots = new List<Shot>();
        private List<Shot> tempShot = new List<Shot>();
        List<Enemy> enemies = new List<Enemy>();

        private int numberOfHouses = 10;
        int currentLevel = 1;
        int numberOfEnemies = 5;

        public Boolean activeShots{ get; set; }
        public Boolean activeDrawing { get; set; }
        public Boolean activeSpawner { get; set; }

        public GamePanel()
        {
            canon = new Canon(this);
            shield = new Shield(this);

            for (int i = 0; i < numberOfHouses; i++)
            {
                house.Add(new House(this, i, numberOfHouses));
            }


            this.SetStyle(ControlStyles.DoubleBuffer |
                            ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint,
                            true);
            this.UpdateStyles();

            /*
             * Drawer thred 
             */
            activeDrawing = true;

            Thread drawingGame = new Thread(new ThreadStart(drawing));
            drawingGame.Start();

            /*
             * Spawner thred
             */
            activeSpawner = true;

            Thread spawner = new Thread(new ThreadStart(addEnemy));
            spawner.Start();
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
        // På grunn av en beskyttelse måtte vi gjøre det på denne
        // måten.
        //
        public void canonMoveRight() { canon.moveRight(); }
        public void canonMoveLeft() { canon.moveLeft(); }

        //
        // Beveger alle skuddene som er avfyrt og sletter de som er utenfor panelet
        //
        public void moveShots()
        {
            while (activeShots)
            {  
                foreach (Shot s in shots)
                {
                    s.moveShot();

                    if (s.Active == false)
                        tempShot.Add(s);
                }
                if (tempShot.Count > 0)
                {
                    foreach (Shot s in tempShot)
                    {
                        shots.Remove(s);
                    }
                    tempShot.Clear();
                }
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

        public void addEnemy()
        {
            while (activeSpawner)
            {
                enemies.Add(new Enemy());
                Thread.Sleep(5000/currentLevel);
            }
        }

        //
        // Tegner panelet når et paint event blir avfyrt
        // 
        protected override void OnPaint(PaintEventArgs e)
        {
                shield.draw(e.Graphics);

                foreach (Enemy c in enemies)
                {
                    c.draw(e.Graphics);
                }

                foreach (House h in house)
                {
                    h.draw(e.Graphics);
                }

                foreach (Shot s in shots)
                {
                    s.draw(e.Graphics);
                }
                canon.draw(e.Graphics);
        }
    }
}

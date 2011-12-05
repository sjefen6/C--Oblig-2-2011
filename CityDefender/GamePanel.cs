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
        private List<Enemy> tempEnemies = new List<Enemy>();
        private List<Enemy> enemies = new List<Enemy>();

        private int numberOfHouses = 10;
        int currentLevel = 1;
        int numberOfEnemies = 5;

        public Boolean activeShots{ get; set; }
        public Boolean activeDrawing { get; set; }
        public Boolean activeSpawner { get; set; }
        public Boolean gameRunning { get; set; }
        public Boolean shieldActive { get; set; }

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
            shieldActive = true;

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
                collisions();
                if (tempShot.Count > 0)
                {
                    tempShot.Clear();
                }
                if (tempEnemies.Count > 0)
                {
                    tempEnemies.Clear();
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

        public void collisions()
        {
                //Sjekker skudd mot fiender
                foreach (Shot s in shots)
                {
                    foreach (Enemy e in enemies)
                    {
                       if (s.getRect().IntersectsWith(e.getRect()))
                       {
                           s.Active = false;
                           e.Active = false;
                           tempShot.Add(s);
                           tempEnemies.Add(e);
                       }
                    }
                }
                //Sjekker fiender mot skjold, hus og bakke
                foreach (Enemy e in enemies)
                {
                    if (shieldActive)
                    {
                        foreach (Rectangle r in shield.getRects())
                        {
                            if (r.IntersectsWith(e.getRect()))
                            {
                                shield.HitPoints = shield.HitPoints - 1;
                                e.Active = false;
                                tempEnemies.Add(e);

                                if (shield.HitPoints == 0)
                                {
                                    canon.shieldDisabled();
                                    shield.ShieldActive = false;
                                }
                            }
                        }
                        
                    }
                    if (!shieldActive)
                    { 
                        
                    }
                }

            // Rydder opp arrayene
                foreach (Shot s in tempShot)
                {
                    shots.Remove(s);
                }
                foreach (Enemy e in tempEnemies)
                {
                    enemies.Remove(e);
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

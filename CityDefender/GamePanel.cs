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

        private Highscore highscore = new Highscore();

        private Object lobj = new Object();
        private Scoreboard scoreboard;
        private String playerName;

        private int numberOfHouses = 10;

        public Boolean activeShots { get; set; }
        public Boolean activeDrawing { get; set; }
        public Boolean activeSpawner { get; set; }
        public Boolean shieldActive { get; set; }

        public GamePanel()
        {
            canon = new Canon(this);
            shield = new Shield(this);
            scoreboard = new Scoreboard(this);
            this.SetStyle(ControlStyles.DoubleBuffer |
                            ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint,
                            true);
            this.UpdateStyles();
        }

        //
        // Metode for å starte spillet.
        // 
        public void startGame(String n)
        {
            for (int i = 0; i < numberOfHouses; i++)
            {
                house.Add(new House(this, i, numberOfHouses));
            }
            /*
            * Drawer thred 
            */
            activeDrawing = true;
            shieldActive = true;
            activeShots = true;
            activeSpawner = true;

            canon = new Canon(this);
            shield = new Shield(this);
            scoreboard = new Scoreboard(this);

            scoreboard.score = 0;

            playerName = n;

            /*
             *  tråd for tegning av spillet                
             */
            Thread drawingGame = new Thread(new ThreadStart(drawing));
            drawingGame.Start();

            /*
             *   tråd for bevegelse av skudd
             */
            Thread movingShots = new Thread(new ThreadStart(moveShots));
            movingShots.Start();

            /*
             * Spawner thred
             */
            Thread spawner = new Thread(new ThreadStart(addEnemy));
            spawner.Start();
        }

        // 
        // Slutter spillet, slutter tråder og sletter innholdet i alle lister.
        // Legger også til highscore.
        //
        private void gameOver()
        {
            lock (lobj)
            {
                activeSpawner = false;
                activeShots = false;
                activeDrawing = false;
                shots.Clear();
                house.Clear();
                enemies.Clear();
                tempShot.Clear();
                tempEnemies.Clear();
                highscore.addScore(scoreboard.score, playerName);
            }
        }

        //
        // Avfryrer et nytt skudd fra kanonen
        //
        public void fireShot()
        {
            lock (lobj)
            {
                shots.Add(new Shot(this, canon.XCoord, canon.YCoord, canon.Angle));
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
        // Sjekker også posisjonen til alle objektene for kollisjoner
        //
        private void moveShots()
        {
            while (activeShots)
            {
                lock (lobj)
                {
                    foreach (Shot s in shots)
                    {
                        s.moveShot();

                        if (s.Active == false)
                        {
                            tempShot.Add(s);
                            scoreboard.score -= 2;
                        }

                    }
                }
                collisions();
                Thread.Sleep(24);
            }

        }

        //
        // Fyrer av et paint event slik at panelet tegnes
        //
        private void drawing()
        {
            while (activeDrawing)
            {
                Invalidate();
                Thread.Sleep(24);
            }
        }

        //
        // Rydder opp i arrayene og tempArrayene
        //
        private void cleanUp()
        {
            lock (lobj)
            {
                foreach (Shot s in tempShot)
                {
                    shots.Remove(s);
                }
            }
            lock (lobj)
            {
                foreach (Enemy e in tempEnemies)
                {
                    enemies.Remove(e);
                }
            }

            lock (lobj)
            {
                if (tempShot.Count > 0)
                {
                    tempShot.Clear();
                }
            }

            lock (lobj)
            {
                if (tempEnemies.Count > 0)
                {
                    tempEnemies.Clear();
                }
            }

        }

        /*
         * Metode som sjekker objektene i spillet for kollisjoner
         */
        private void collisions()
        {

            //Sjekker skudd mot fiender
            lock (lobj)
            {
                foreach (Shot s in shots)
                {
                    foreach (Enemy e in enemies)
                    {
                        if (s.getRect().IntersectsWith(e.getRect()))
                        {
                            tempShot.Add(s);
                            tempEnemies.Add(e);
                            scoreboard.score += 10;
                        }
                    }
                }
            }
            cleanUp();
            //Sjekker fiender mot skjold, hus og bakke
            lock (lobj)
            {
                try
                {
                    foreach (Enemy e in enemies)
                    {
                        //Dersom skjold aktivt
                        if (shieldActive)
                        {
                            //Sjekker "alle" posisjonene til skjoldet for kollisjon mot
                            //kattene. Dersom skjoldet tar 3 treff blir det ødelagt
                            foreach (Rectangle r in shield.getRects())
                            {
                                if (r.IntersectsWith(e.getRect()))
                                {
                                    shield.HitPoints = shield.HitPoints - 1;
                                    tempEnemies.Add(e);

                                    if (shield.HitPoints == 0)
                                    {
                                        canon.shieldDisabled();
                                        shield.ShieldActive = false;
                                        shieldActive = false;
                                    }
                                }
                            }
                        }
                        //Dersom skjoldet er ødelagt sjekker kattene mot husene
                        //og bakken
                        if (!shieldActive)
                        {
                            //Ødelegger hus som blir truffet av en katt.
                            foreach (House h in house)
                            {
                                if (h.Active)
                                {
                                    if (h.getRect().IntersectsWith(e.getRect()))
                                    {
                                        h.Active = false;
                                        e.Active = false;
                                    }
                                }
                            }

                            //GameOver dersom en katt treffer bakken.
                            if (e.YCoord > 539)
                            {
                                gameOver();
                                MessageBox.Show("Game over");
                            }

                        }

                    }
                }
                catch (InvalidOperationException) 
                {
                    //blah blah blah fuck dat excpetion
                }
            }
            cleanUp();
        }

        /*
         * Metode som spawner nye fiender, hyppighet varierer etter level.
         */
        private void addEnemy()
        {
            while (activeSpawner)
            {
                lock (lobj)
                {
                    enemies.Add(new Enemy());
                }
                Thread.Sleep(5000 / scoreboard.level);

            }
        }

        //
        // Tegner panelet når et paint event blir avfyrt
        // 
        protected override void OnPaint(PaintEventArgs e)
        {
            lock (lobj)
            {
                shield.draw(e.Graphics);
            }
            lock (lobj)
            {
                foreach (Enemy c in enemies)
                {
                    c.draw(e.Graphics);
                }
            }

            lock (lobj)
            {
                foreach (House h in house)
                {
                    h.draw(e.Graphics);
                }
            }

            lock (lobj)
            {
                foreach (Shot s in shots)
                {
                    s.draw(e.Graphics);
                }
            }
            lock (lobj)
            {
                canon.draw(e.Graphics);
            }
            lock (lobj)
            {
                scoreboard.draw(e.Graphics);
            }
        }
    }
}

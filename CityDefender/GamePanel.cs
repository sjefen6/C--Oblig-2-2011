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
        House house;
        List<Shot> shots = new List<Shot>();
        public Boolean activeShots{ get; set; }
        public Boolean activeDrawing { get; set; }

        public GamePanel()
        {
            canon = new Canon(this);
            shield = new Shield(this);
            house = new House(this, 10, 10);

            activeDrawing = true;

            this.SetStyle(ControlStyles.DoubleBuffer |
                            ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint,
                            true);
            this.UpdateStyles();

            Thread drawingGame = new Thread(new ThreadStart(drawing));
            drawingGame.Start();
        }

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

        public void canonMoveRight() { canon.moveRight(); }
        public void canonMoveLeft() { canon.moveLeft(); }

        public void moveShots()
        {
            while (activeShots)
            {
                foreach (Shot s in shots)
                {
                    s.moveShot();
                }
                Thread.Sleep(24);
            }
        }

        public void drawing()
        {
            while (activeDrawing)
                Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
                canon.draw(e.Graphics);
                shield.draw(e.Graphics);
                house.draw(e.Graphics);

                foreach (Shot s in shots)
                    s.draw(e.Graphics);
        }
    }
}

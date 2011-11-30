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

        public GamePanel()
        {
            canon = new Canon(this);
            shield = new Shield(this);
            house = new House(this, 10, 10);

            //this.SetStyle(ControlStyles.DoubleBuffer |
            //                ControlStyles.UserPaint |
            //                ControlStyles.AllPaintingInWmPaint,
            //                true);
            //this.UpdateStyles();
        }

        public void canonMoveRight()
        {canon.moveRight();}

        protected override void OnPaint(PaintEventArgs e)
        {
            canon.draw(e.Graphics);
            shield.draw(e.Graphics);
            house.draw(e.Graphics);
        }
    }
}

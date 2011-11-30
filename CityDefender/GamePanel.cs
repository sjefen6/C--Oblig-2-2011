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

        public GamePanel()
        {
            canon = new Canon(this);
            shield = new Shield(this);

            //this.SetStyle(ControlStyles.DoubleBuffer |
            //                ControlStyles.UserPaint |
            //                ControlStyles.AllPaintingInWmPaint,
            //                true);
            //this.UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            canon.draw(e.Graphics);
            shield.draw(e.Graphics);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CityDefender
{
    public partial class CityDefender : Form
    {

        public CityDefender()
        {
            InitializeComponent();
        }

        private void CityDefender_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    gamePanel1.canonMoveRight(); gamePanel1.Invalidate(); break;
                case Keys.Left:
                    gamePanel1.canonMoveLeft(); gamePanel1.Invalidate(); break;
                case Keys.Space:
                    gamePanel1.fireShot(); gamePanel1.Invalidate(); break;
            }
        }

        private void CityDefender_FormClosing(object sender, FormClosingEventArgs e)
        {
            gamePanel1.activeShots = false;
            gamePanel1.activeDrawing = false;
        }
    }
}

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
            if (e.KeyCode.Equals(Keys.Right))
                gamePanel1.canonMoveRight();
            if (e.KeyCode.Equals(Keys.Left))
                gamePanel1.canonMoveLeft();
            if (e.KeyCode.Equals(Keys.Space))
                gamePanel1.fireShot();                
        }

        private void CityDefender_FormClosing(object sender, FormClosingEventArgs e)
        {
            gamePanel1.activeShots = false;
            gamePanel1.activeDrawing = false;
        }
    }
}

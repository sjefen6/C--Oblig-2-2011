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
        Highscore hs = new Highscore();

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
            gamePanel1.gameOver();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("City Defender av: Lena, Daniel og Vegard");
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold ut så lenge som mulig.\n\nSkjoldet har 3 liv, bygninger 1 liv."
                            + "\nDu taper dersom en katt treffer bakken.");
        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            gamePanel1.startGame();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hs.openScore();
            MessageBox.Show(hs.ToString());
        }
    }
}

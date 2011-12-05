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

        /*
         * Lytter på keyevents
         */
        private void CityDefender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right))
                gamePanel1.canonMoveRight();
            if (e.KeyCode.Equals(Keys.Left))
                gamePanel1.canonMoveLeft();
            if (e.KeyCode.Equals(Keys.Space))
                gamePanel1.fireShot();                
        }

        /*
         *  Sørger for at alle trådene avslutter når spillet avsluttes
         */
        private void CityDefender_FormClosing(object sender, FormClosingEventArgs e)
        {
            gamePanel1.activeDrawing = false;
            gamePanel1.activeShots = false;
            gamePanel1.activeSpawner = false;
        }

        // About-boxen
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("City Defender av: Lena, Daniel og Vegard");
        }

        // Help-boxen
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold ut så lenge som mulig.\n\nSkjoldet har 3 liv, bygninger 1 liv."
                            + "\nDu taper dersom en katt treffer bakken.");
        }

        // New Game menyvalget
        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string playerName = Microsoft.VisualBasic.Interaction.InputBox("Enter Player Name", "Enter Player Name", "PlayerName", 0, 0);
            gamePanel1.startGame(playerName);
        }

        // Exit menyvalget
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // High Score menyvalget
        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hs.openScore();
            MessageBox.Show(hs.ToString());
        }
    }
}

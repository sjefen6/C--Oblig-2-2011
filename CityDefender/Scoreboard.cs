using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    class Scoreboard : GameObject
    {
        // Spillerens score
        public int score
        { get; set; }

        //Spillerens level, bestemmer spawnrate. er ikke helt heldig om den kommer under 1
        public int level { get{ return 1 + (score/200);}}

        //Konstruktør
        public Scoreboard(GamePanel _GamePanel)
        {
            xCoord = 538;
            yCoord = 600;
        }

        public override System.Drawing.Rectangle getRect()
        {
            throw new NotImplementedException();
        }

        public override void draw(System.Drawing.Graphics g)
        {
            g.DrawString("Score: " + score.ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), 10, 10);
            g.DrawString("Level: " + level.ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), 500, 10);
        }
    }
}

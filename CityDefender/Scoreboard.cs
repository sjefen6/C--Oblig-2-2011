using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    class Scoreboard : GameObject
    {
        int height, width;

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
            g.DrawString("lal", new Font("Arial", 16), new SolidBrush(Color.Black), xCoord - 30, yCoord - 100);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityDefender
{
    class highscore
    {
        public bool showAddBox, showHighscore;

        public highscore()
        {
            //load highscore file
            showAddBox = showHighscore = false;
        }

        public void add(int score)
        {
            showAddBox = true;
            showHighscore = false;
            //spørr etter navn og legg til i fil
        }

        public void showScoreboard()
        {
            showAddBox = true;
            showHighscore = false;
        }


        public void draw(System.Drawing.Graphics g)
        {
            if (showAddBox)
            {
                //jepp
            }
            else if (showHighscore)
            {
                //jepp
            }
            else
            {
                //nothing
            }
            throw new NotImplementedException();
        }
    }
}

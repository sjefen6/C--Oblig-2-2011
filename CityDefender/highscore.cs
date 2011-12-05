using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;


namespace CityDefender
{
    class Highscore
    {
        public bool showAddBox, showHighscore;
        private List<Score> scores;
        private String[] printingScore;

        public Highscore()
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

        public void openScore()
        {
            String tekst = File.ReadAllText(@"C:\Users\Daniel\Documents\Skole\HiN\Programmering i C#\Oblig6\GitClone\C--Oblig-2-2011\C--Oblig-2-2011\C--Oblig-2-2011\CityDefender\Resources\HighScores.txt");
            String[] s1;

            tekst = tekst.ToLower();

            Regex regex = new Regex("\\n");

            printingScore = regex.Split(tekst);

            foreach (String s in printingScore)
            { 
                Regex regex1 = new Regex(@"\W+");

                s1 = regex1.Split(s);
                int test = Convert.ToInt32(s1[0]);
                int test2 = Convert.ToInt32(s1[2]);

                if (s1 != null)
                    scores.Add(new Score(test, s1[1], test2));
            }
        }

        public override String ToString()
        {
            string resultat = "";
            foreach (Score s in scores)
            {
                resultat += s.ToString() + "\n";
            }
            return resultat;
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

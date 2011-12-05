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
        private List<Score> scores = new List<Score>();
        private String[] printingScore;

        public Highscore()
        {

        }

        public void addScore(int p, String n)
        { 
            scores.Add(new Score(n, p));
            scores.Sort();
        }

        private void saveScore()
        { 
            
        }

        public void openScore()
        {
            String tekst = File.ReadAllText(@"C:\Users\Daniel\Documents\Skole\HiN\Programmering i C#\Oblig6\GitClone\C--Oblig-2-2011\C--Oblig-2-2011\C--Oblig-2-2011\CityDefender\Resources\HighScores.txt");
            String[] s1;
            int temp;

            Regex regex = new Regex("\\n");
            Regex regex1 = new Regex(@"\W+");

            printingScore = regex.Split(tekst);

            foreach (String s in printingScore)
            { 
                s1 = regex1.Split(s);
                temp = Convert.ToInt32(s1[1]);

                scores.Add(new Score(s1[0], (int)temp));
            }
            scores.Sort();
        }

        public override String ToString()
        {
            string resultat = "";

            scores.Sort();

            for (int i = 0; i < 10; i++ )
            {
                resultat += scores[i].ToString() + "\n";
            }
            return resultat;
        }
    }
}

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
        private String homePath;

        public Highscore()
        {
            homePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            openScore();
        }

        public void addScore(int p, String n)
        {
            scores.Add(new Score(n, p));
            scores.Sort();
            saveScore();
        }

        private void saveScore()
        {
            StringBuilder str = new StringBuilder();
            System.IO.StreamWriter sw =
                new System.IO.StreamWriter(homePath+"\\HighScores.txt");

            foreach (Score s in scores)
            {
                str.AppendLine(s.ToString());
            }

            sw.WriteLine(str);
            sw.Close();

            //foreach (string substr in result)
            //    sw.WriteLine(substr);
            //sw.WriteLine("Det er " + count + " unike ord i fila.");
            //sw.Close();
        }

        public void openScore()
        {
            try
            {
                String tekst = File.ReadAllText(homePath+"\\HighScores.txt");
                String[] s1;
                int temp;

                Regex regex = new Regex("\\n");
                Regex regex1 = new Regex(@"\W+");

                printingScore = regex.Split(tekst);

                foreach (String s in printingScore)
                {
                    if (s != "" && s != "\r")
                    {
                        s1 = regex1.Split(s);
                        temp = Convert.ToInt16(s1[1]);

                        scores.Add(new Score(s1[0], (int)temp));
                    }
                }
                scores.Sort();
            }
            catch (FileNotFoundException) { }
        }

        public override String ToString()
        {
            string resultat = "";
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    resultat += scores[i].ToString() + "\n";
                }
            }
            catch (ArgumentOutOfRangeException) { }
            return resultat;
        }
    }
}

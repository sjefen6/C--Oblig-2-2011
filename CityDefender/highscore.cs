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

        /*
         * Legger til nye poeng og lagrer til fil
         */
        public void addScore(int p, String n)
        {
            scores.Add(new Score(n, p));
            scores.Sort();
            saveScore();
        }

        /*
         *  Lagrer highscore til fil, overskriver gammel fil.
         *  Lagres til brukerens hjemmemappe.
         */
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
        }

        /*
         * Åpner filen HighScores.txt og parser den, og legger verdiene til
         * i lista med Scores. Åpnes fra brukerens hjemmemappe.
         */
        public void openScore()
        {
            //For å unngå dobbel highscoreliste oppdateres lista
            //hvergang denne metoden kjøres.
            if (scores != null)
            {
                scores.Clear();
            }
            try
            {
                String tekst = File.ReadAllText(homePath+"\\HighScores.txt");
                String[] s1;
                int temp;

                
                Regex regex = new Regex("\\n");
                Regex regex1 = new Regex(@"\W+");

                //Skiller linjene fra hverandre
                printingScore = regex.Split(tekst);

                //Skiller Poeng og navn fra hverandre og 
                //legger til i listen.
                foreach (String s in printingScore)
                {
                    if (s != "" && s != "\r")
                    {
                        s1 = regex1.Split(s);
                        temp = Convert.ToInt16(s1[1]);

                        scores.Add(new Score(s1[0], (int)temp));
                    }
                }
                //Solterer listen etter høyest poengsum
                scores.Sort();
            }
            catch (FileNotFoundException) { }
        }

        /*
         * Skriver ut top 10 på lista.
         */ 
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

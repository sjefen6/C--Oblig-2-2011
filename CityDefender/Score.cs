using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityDefender
{
    class Score
    {
        private String Name { get; set; }
        private int Rank { get; set; }
        private int Points { get; set; }

        public Score(int r, String n, int s)
        {
            this.Rank = r;
            this.Name = n;
            this.Points = s;
        }

        public override String ToString()
        {
            return Rank + " - " + Name + ": " + Points;
            ;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Rank
    {
        public Rank(int aRank, String aName, int aValue)
        {
            Ranking = aRank;
            Name = aName;
            Value = aValue;
        }

        private int rank;

        public int Ranking
        {
            get { return rank; }
            set { rank = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}

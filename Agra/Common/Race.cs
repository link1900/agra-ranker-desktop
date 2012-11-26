using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common
{

    [Serializable]
    [DataContract]
    public class Race : IComparable<Race>
    {
        //Members
        protected string name;
        protected DateTime date;
        protected GroupRank groupRank;
        protected int raceLength;
        protected bool isNoRace;

        public Race(string name, DateTime date, GroupRank groupRank, int raceLength, bool isNoRace)
        {
            this.name = name;
            this.date = date;
            this.groupRank = groupRank;
            this.raceLength = raceLength;
            this.isNoRace = isNoRace;
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public GroupRank GroupRank
        {
            get { return groupRank; }
            set { groupRank = value; }
        }

        [DataMember]
        public int RaceLength
        {
            get { return raceLength; }
            set { raceLength = value; }
        }
        public bool IsNoRace{
            get {return isNoRace;}
            set { isNoRace = value; }
        }

        public string getRaceLengthAsString(){
            if (isDistance()){
                return "Distance";
            }
            return "Sprint";
        }

        public static int getBasicLengthForRaceLength(string aRaceLength){
            if (aRaceLength.Equals("Distance",StringComparison.CurrentCultureIgnoreCase)){
                return 750;
            }
            return 500;
        }

        public bool isDistance()
        {
            return this.RaceLength > 600;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Race other)
        {
            if (name.CompareTo(other.name) == 0)
                return date.CompareTo(other.date);
            else
                return name.CompareTo(other.name);
        }

        int IComparable<Race>.CompareTo(Race other)
        {
            return CompareTo(other);
        }
    }

}

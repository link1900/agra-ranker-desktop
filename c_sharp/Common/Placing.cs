using System;
using System.Collections;
using System.Runtime.Serialization;

namespace Common
{

    [Serializable]
    [DataContract]
    public class Placing : IComparable<Placing>
	{
        protected Greyhound greyhound;
        protected Race race;
		protected short place;


        public Placing(Greyhound aGreyhound, Race aRace, short place)
        {
            this.greyhound = aGreyhound;
            this.race = aRace;
            this.place = place;
            this.IsDisqualified = false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Placing)
            {
                Placing objG = obj as Placing;
                return objG.Greyhound.Equals(Greyhound) && objG.Place.Equals(Place) && objG.Race.Equals(Race);
            }
            return false;
        }
        [DataMember]
        public Greyhound Greyhound
        {
            get { return greyhound; }
        }
        [DataMember]
        public Race Race
        {
            get { return race; }
        }

        [DataMember]
		public short Place
		{
			get { return place; }
			set {  place = value; }
		}

        public bool IsDisqualified { get; set; }

        public int CompareTo(Placing other)
        {
            if (this.Greyhound.CompareTo(other.Greyhound) == 0)
                if (this.Race.CompareTo(other.Race) == 0)
                    return this.Place.CompareTo(other.Place);
                else
                    return this.Race.CompareTo(other.Race);
            else
                return this.Greyhound.CompareTo(other.Greyhound);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        int IComparable<Placing>.CompareTo(Placing other)
        {
            return CompareTo(other);
        }
    }
}

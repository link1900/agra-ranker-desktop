using System;
using System.Collections;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    [DataContract]
    public class GroupRank
    {
        protected int rank;
        protected string name;

        public GroupRank(int rank, string name)
        {
            this.rank = rank;
            this.name = name;
        }

        #region Public Properties
        [DataMember]
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}

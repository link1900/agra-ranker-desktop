
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common
{
	/// <summary>
	/// Instances of this class represent the properties and methods of a row in the table <b>Greyhound</b>.
	/// </summary>
    [Serializable]
    [DataContract]
    public class Greyhound : IComparable<Greyhound>
	{
		#region Members

		protected string name;

		//protected int greyhound_sire;
        protected Greyhound sire;
        protected Greyhound dam;

        //protected List<Placing> Placings;
		//protected int greyhound_dame;
		#endregion
		/// <summary> 
		/// Create a new object using the minimum required information (all not-null fields except 
		/// auto-generated primary keys). 
		/// </summary> 
		public Greyhound(string name)
		{
			this.name = name;
		}

		/// <summary> 
		/// Create a new object by specifying all fields (except the auto-generated primary key field). 
		/// </summary> 
        public Greyhound(string name, Greyhound greyhound_sire, Greyhound greyhound_dame)
		{
			this.name = name;
			this.sire = greyhound_sire;
			this.dam = greyhound_dame;
		}

        public override bool Equals(object obj)
        {
            if (obj is Greyhound)
            {
                Greyhound objG = obj as Greyhound;
                return objG.Name.Equals(name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

		#region Public Properties

		/// <summary>
		/// Property relating to database column name
		/// </summary>
        /// 
        [DataMember]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Property relating to database column greyhound_sire
		/// </summary>
        [DataMember]
		public Greyhound Sire
		{
			get { return sire; }
			set { sire = value; }
		}

		/// <summary>
		/// Property relating to database column greyhound_dame
		/// </summary>
        [DataMember]
        public Greyhound Dam
		{
			get { return dam; }
			set { dam = value; }
		}

        public override string ToString()
        {
            return Name;
        }

		#endregion

        #region IComparable<Greyhound> Members

        int IComparable<Greyhound>.CompareTo(Greyhound other)
        {
            return String.Compare(Name, other.Name, false);
        }

        public int CompareTo(Greyhound other)
        {
            return String.Compare(Name, other.Name, false);
        }

        #endregion
    }
}

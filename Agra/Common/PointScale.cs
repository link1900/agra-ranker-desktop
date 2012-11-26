using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    [DataContract]
    public abstract class PointScale
    {
        private int[][] pTable;

        [DataMember]
        public int[][] PTable
        {
            get { return pTable; }
            set { pTable = value; }
        }
        private string scaleName;

        [DataMember]
        public string ScaleName
        {
            get { return scaleName; }
            set { scaleName = value; }
        }

        public abstract int PointsForPlace(Placing aPlacing);

        public List<PointPlace> getPointPlaces()
        {
            List<PointPlace> pointPlace = new List<PointPlace>();
            for (int y = 0; y < PTable.Length; y++)
            {
                for (int i = 0; i < PTable[y].Length; i++)
                {
                    pointPlace.Add(new PointPlace((i+1).ToString(), PTable[y][i].ToString(), (y+1).ToString()));
                }
            }
            return pointPlace;
        }
    }
}

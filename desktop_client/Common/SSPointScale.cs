using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class SSPointScale : PointScale
    {
        private int[][] stayTable;

        public int[][] StayTable
        {
            get { return stayTable; }
            set { stayTable = value; }
        }
        public SSPointScale()
        {
            ScaleName = "Sprint and Stay";
            PTable = new int[3][];
            
            int[] g1 = { 70, 35, 20, 15, 10, 8, 7, 6 };
            int[] g2 = { 40, 25, 15, 10, 8, 7, 6, 5 };
            int[] g3 = { 25, 16, 12, 8, 6, 5, 4, 3 };

            int[][] multiDimensionalArray2 = {new int[] { 70, 35, 20, 15, 10, 8, 7, 6 }, new int[]{ 40, 25, 15, 10, 8, 7, 6, 5 },
             new int[]{ 25, 16, 12, 8, 6, 5, 4, 3 }};
            PTable = multiDimensionalArray2;

            int[][] multiDimensionalArray3 = {new int[]{ 50, 25, 16, 12, 08, 6, 4, 2 },
                                             new int[]{ 30, 20, 12, 08, 6, 4, 2, 1 },
                                            new int[] { 20, 14, 10, 6, 4, 3, 2, 1 }};

            StayTable = multiDimensionalArray3;
        }

        public override int PointsForPlace(Placing aPlacing)
        {
            int groupRank = Convert.ToInt32(aPlacing.Race.GroupRank.Rank);
            if (aPlacing.Race.isDistance())
                return StayTable[groupRank - 1][aPlacing.Place - 1];
            else
                return PTable[groupRank - 1][aPlacing.Place - 1];
        }
    }
}

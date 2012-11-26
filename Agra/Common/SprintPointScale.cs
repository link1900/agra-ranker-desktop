using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class SprintPointScale : PointScale
    {
        public SprintPointScale()
        {
            ScaleName = "Sprint";
            PTable = new int[3][];
            
            int[] g1 = { 70, 35, 20, 15, 10, 8, 7, 6 };
            int[] g2 = { 40, 25, 15, 10, 8, 7, 6, 5 };
            int[] g3 = { 25, 16, 12, 8, 6, 5, 4, 3 };
            //int[,] g4=  {g1,g2,g3};

            //PTable = {{ 70, 35, 20, 15, 10, 8, 7, 6 }, { 40, 25, 15, 10, 8, 7, 6, 5 },
             //{ 25, 16, 12, 8, 6, 5, 4, 3 }};

            int[][] multiDimensionalArray2 = {new int[]{ 70, 35, 20, 15, 10, 8, 7, 6 }, new int[]{ 40, 25, 15, 10, 8, 7, 6, 5 },
             new int[]{ 25, 16, 12, 8, 6, 5, 4, 3 }};
            PTable = multiDimensionalArray2;
            //PTable

            //PTable.SetValue(g1, 0);
            //PTable.SetValue(g2, 1);
            //PTable.SetValue(g3, 2);

        }

        public override int PointsForPlace(Placing aPlacing)
        {
            int groupRank = Convert.ToInt32(aPlacing.Race.GroupRank.Rank);
            return PTable[groupRank -1][aPlacing.Place -1]; 

        }
    }
}

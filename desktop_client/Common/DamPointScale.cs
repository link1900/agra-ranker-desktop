using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class DamPointScale : PointScale
    {

        public DamPointScale()
        {
            ScaleName = "Dam";

            int[][] multiDimensionalArray4 = {new int[]{ 6, 4, 3, 1, 1, 1, 1, 1 },
                                             new int[]{ 4, 3, 2, 1, 1, 1, 1, 1 },
                                             new int[]{ 4, 3, 2, 1, 1, 1, 1, 1 }};
            PTable = multiDimensionalArray4;

        }

        public override int PointsForPlace(Placing aPlacing)
        {
            int groupRank = Convert.ToInt32(aPlacing.Race.GroupRank.Rank);
            return PTable[groupRank - 1][aPlacing.Place - 1];
        }
    }
}

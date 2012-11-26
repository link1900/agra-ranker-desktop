using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class PointPlace
    {
        public PointPlace(String place, String point, String gLevel){
            placing = place;
            points = point;
            groupLevel = gLevel;
        }
        protected String placing;
        protected String points;
        protected String groupLevel;
        public String Placing { get { return placing; } set { placing = value; } }
        public String Points { get { return points; } set { points = value; } }
        public String GroupLevel { get { return groupLevel; } set { groupLevel = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Linq;

namespace Common
{
    [Serializable]
    [DataContract]
    public class AgraDB
    {
        [DataMember]
        public List<Greyhound> Greyhounds;
        [DataMember]
        public List<Race> Races;
        [DataMember]
        public List<Placing> Placings;
        [DataMember]
        public List<PointScale> PointScales;
        [DataMember]
        public List<GroupRank> GroupRanks;
        [DataMember]
        public List<string> RaceLengths;

        public AgraDB()
        {
            Greyhounds = new List<Greyhound>();
            Races = new List<Race>();
            Placings = new List<Placing>();
            PointScales = new List<PointScale>();
            GroupRanks = new List<GroupRank>();
            RaceLengths = new List<string>();
        }
        #region Greyhound
    public Greyhound AddGreyhound(String g)
        {
            g = g.Trim().ToUpperInvariant().Replace("\"","").Replace(",","");
            if (g == null || String.IsNullOrWhiteSpace(g)){
                return null;
            }
            Greyhound temp = GetGreyhound(g);
            if (temp == null)
            {
                temp = new Greyhound(g);
                Greyhounds.Add(temp);
            }
            return temp;
        }

        public Greyhound GetGreyhound(string gName)
        {
            GreyhoundComparer gc = new GreyhoundComparer();
            Greyhounds.Sort(gc);
            int result = Greyhounds.BinarySearch(new Greyhound(gName), gc);
            if (result >= 0)
                return Greyhounds[result];
            else
                return null;
        }

        public bool RemoveGreyhound(Greyhound g)
        {
            if (Greyhounds.Contains(g))
            {
                return Greyhounds.Remove(g);
            }
            return false;
        }

        public List<Placing> PlacingsFor(Greyhound g)
        {
            List<Placing> gPlacings = new List<Placing>();
            foreach (Placing p in Placings)
            {
                if (p.Greyhound.Equals(g))
                {
                    gPlacings.Add(p);
                }
            }
            return gPlacings;
        }

        public List<Placing> PlacingsFor(Race r)
        {
            List<Placing> rPlacings = new List<Placing>();
            foreach (Placing p in Placings)
            {
                if (p.Race.Equals(r))
                {
                    rPlacings.Add(p);
                }
            }
            return rPlacings;
        }

        public List<Race> RacesFor(Greyhound g)
        {
            List<Race> gRaces = new List<Race>();
            foreach (Placing p in PlacingsFor(g))
            {
                gRaces.Add(p.Race);
            }
            return gRaces;
        }

        public List<Greyhound> ChildrenOf(Greyhound parent)
        {
            List<Greyhound> children = new List<Greyhound>();
            if (parent != null && parent.Name.Length > 0)
            {
                foreach (Greyhound g in Greyhounds)
                {
                    if (g.Sire == parent)
                    {
                        children.Add(g);
                    }
                    if (g.Dam == parent)
                    {
                        children.Add(g);
                    }
                }
            }
            return children;
        }

        public bool deleteAllGreyhounds(){
            Placings = new List<Placing>();
            Greyhounds = new List<Greyhound>();
             return true;
        }

        public bool deleteAllRaces(){
            Placings = new List<Placing>();
            Races = new List<Race>();
            return true;
        }

        public bool Delete(Greyhound g)
        {
            //first remove all breeding refences

            foreach (Greyhound gs in Greyhounds){
                if (gs.Sire != null && gs.Sire.Equals(g) )
                    gs.Sire = null;
            }

            foreach (Greyhound gd in Greyhounds){
                if (gd.Dam != null && gd.Dam.Equals(g))
                    gd.Dam = null;
            }
            

            //then remove all its placings
            foreach (Placing p in Placings){
                if (p.Greyhound == g)
                    Placings.Remove(p);
            }

            //lastly remove the greyhound from the g list
            return Greyhounds.Remove(g);
        }


        public class GreyhoundComparer : IComparer<Greyhound>
        {
            int IComparer<Greyhound>.Compare(Greyhound x, Greyhound y)
            {
                return String.Compare(x.Name,y.Name,false);
            }
            //Comparer<String>.Default
            //// Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            //int IComparer<Greyhound>.Compare(Greyhound x, Greyhound y)
            //{
            //    return ((new CaseInsensitiveComparer()).Compare(y.Name, x.Name));
            //}

        }

        //public String GreyhoundData(Greyhound selectedGreyhound)
        //{
        //    if (selectedGreyhound != null)
        //    {
        //        StringBuilder sb = new StringBuilder(selectedGreyhound.Name);

        //        sb.AppendLine("Total Points: " + PointsFor(new SSPointScale(), selectedGreyhound, AgraDBController.defaultSunsetSetting).ToString());

        //        sb.AppendLine("Current Points: " + SunsetPently(selectedGreyhound).ToString());


        //        if (selectedGreyhound.Dam != null)
        //            sb.AppendLine("Sire: " + selectedGreyhound.Dam.Name);
        //        if (selectedGreyhound.Sire != null)
        //            sb.AppendLine("Dam: " + selectedGreyhound.Sire.Name);

        //        List<Race> races = RacesFor(selectedGreyhound);
        //        if (races.Count > 0)
        //        {
        //            sb.AppendLine("Races Entered: ");
        //            sb.Append(races.Count.ToString());
        //            foreach (Race r in races)
        //                sb.AppendLine(r.ToString());
        //        }

        //        List<Greyhound> children = ChildrenOf(selectedGreyhound);
        //        if (children.Count > 0)
        //        {
        //            sb.AppendLine("Pup's");
        //            foreach (Greyhound child in children)
        //                sb.AppendLine(child.ToString());
        //        }
        //        return sb.ToString();
        //    }
        //    else
        //        return "";
        //}
    #endregion

        #region Race
        public Race AddRace(string name, DateTime date, GroupRank groupRank, int raceLength, bool isNoRace)
        {
            Race tempRace = new Race(name, date, groupRank, raceLength, isNoRace);
            Races.Add(tempRace);
            if (Races.Contains(tempRace))
                return tempRace;
            else
                return null;
        }

        private static bool RaceName(Race Find)
        {
            return Find.Name.Equals("a");
        }


        public Race GetRace(string gName, DateTime gDate)
        {
            return Races.Find(
                delegate(Race searchItem)
                {
                //this is an anonymous delegate, that
                return searchItem.Name.Equals(gName) && searchItem.Date.Equals(gDate);
                }
            );


            //GreyhoundComparer gc = new GreyhoundComparer();
            //Greyhounds.Sort(gc);
            
            
            //int result = Greyhounds.BinarySearch(new Greyhound(gName), gc);
            //if (result >= 0)
            //    return Greyhounds[result];
            //else
            //    return null;
        }

        

        public bool DeleteRace(Race aRace)
        {
            //first remove the placings of that race
            List<Placing> removeUs = new List<Placing>();
            foreach (Placing p in Placings)
                if (p.Race == aRace)
                    removeUs.Add(p);
            foreach (Placing pRemove in removeUs)
                Placings.Remove(pRemove);
            
            //then remove the race itself
            return Races.Remove(aRace);
        }

        public Placing AddPlacing(Greyhound g, Race r, short thePlace)
        {
            Placing temp = GetPlacing(g,r,thePlace);
            if (temp == null)
            {
                temp = new Placing(g,r,thePlace);
                Placings.Add(temp);
            }
            return temp;
        }

        public bool DeletePlacing(Placing toDelete)
        {
            return Placings.Remove(toDelete);
        }

        public Placing GetPlacing(Greyhound g, Race r, short placing)
        {
            Placings.Sort();
            int result = Placings.BinarySearch(new Placing(g, r, placing));
            if (result >= 0)
                return Placings[result];
            else
                return null;
        }

        public bool containsPlacing(List<Placing> placings, Placing placing)
        {
            foreach (Placing p in placings)
                if (p.Equals(placing))
                    return true;
            return false;
        }
        //public String FindFavGroup(List<Race> races, Greyhound g)
        //{
            
        //    foreach (Race r in races)
        //    {
        //        r.
        //    }
        //}
        #endregion

        #region Group Ranks, Race Types, Point Scales

        public void AddGroupRank(byte rank, string name)
        {
            GroupRank tempGR = new GroupRank(rank, name);
            GroupRanks.Add(tempGR);
        }

        public GroupRank GetGroupRank(string typeName)
        {
            typeName = typeName.Trim();
            foreach (GroupRank ty in GroupRanks)
            {
                if (ty.Name.ToUpper().Equals(typeName.ToUpper()))
                    return ty;
            }
            return null;
        }

        public void AddPointScale(PointScale ps)
        {
            PointScales.Add(ps);
        }

        //public Race_Type GetRaceType(string typeName)
        //{
        //    typeName = typeName.Trim();
        //    foreach(Race_Type ty in Race_Types)
        //    {
        //        if(ty.Length.ToUpper().Equals(typeName.ToUpper()))
        //            return ty;
        //    }
        //    return null;
        //}

        public void AddRaceType(string length)
        {
            RaceLengths.Add(length);
        }
        #endregion

        #region Ranking

        public List<Rank> RankStandard()
        {
            PointScale sps = new SSPointScale();
            return RankComplete(sps, 100, true);
        }

        public List<Rank> RankingsForSireViaChildren(PointScale pointScale)
        {
            List<Rank> rankings = new List<Rank>();
            foreach (Greyhound currentGreyhound in Greyhounds)
            {
                int totalPointsForGreyhound = 0;
                if (IsSire(currentGreyhound))
                {
                    foreach (Greyhound currentChild in ChildrenOf(currentGreyhound))
                    {
                        foreach (Placing p in PlacingsFor(currentChild))
                        {
                            totalPointsForGreyhound += pointScale.PointsForPlace(p);
                        }
                    }
                    if (totalPointsForGreyhound > 0)
                        rankings.Add(new Rank(0, currentGreyhound.Name, totalPointsForGreyhound));
                }
            }

            //Sort the rankings and return them
            return SortAndRank(rankings, 0);
        }

        public List<Rank> RankingsForSireViaChildren(PointScale pointScale, DateTime sd, DateTime ed)
        {
            List<Rank> rankings = new List<Rank>();
            foreach (Greyhound currentGreyhound in Greyhounds)
            {
                int totalPointsForGreyhound = 0;
                if (IsSire(currentGreyhound))
                {
                    totalPointsForGreyhound = PointsForChildren(pointScale, currentGreyhound, sd, ed);
                    if (totalPointsForGreyhound > 0)
                        rankings.Add(new Rank(0, currentGreyhound.Name, totalPointsForGreyhound));
                }
            }

            //Sort the rankings and return them
            return SortAndRank(rankings, 0);
        }

        public List<Rank> RankingsForDamViaChildren(PointScale pointScale, DateTime sd, DateTime ed)
        {
            List<Rank> rankings = new List<Rank>();
            foreach (Greyhound currentGreyhound in Greyhounds)
            {
                int totalPointsForGreyhound = 0;
                if (IsDame(currentGreyhound))
                {
                    totalPointsForGreyhound = PointsForChildren(pointScale, currentGreyhound, sd, ed);
                    if (totalPointsForGreyhound > 0)
                        rankings.Add(new Rank(0, currentGreyhound.Name, totalPointsForGreyhound));
                }
            }

            //Sort the rankings and return them
            return SortAndRank(rankings, 0);
        }

        public List<Rank> RankingsForDamViaChildren(PointScale pointScale)
        {
            List<Rank> rankings = new List<Rank>();
            foreach (Greyhound currentGreyhound in Greyhounds)
            {
                int totalPointsForGreyhound = 0;
                if (IsDame(currentGreyhound))
                {
                    foreach (Greyhound currentChild in ChildrenOf(currentGreyhound))
                    {
                        foreach (Placing p in PlacingsFor(currentChild))
                        {
                            totalPointsForGreyhound += pointScale.PointsForPlace(p);
                        }
                    }
                    if (totalPointsForGreyhound > 0)
                        rankings.Add(new Rank(0, currentGreyhound.Name, totalPointsForGreyhound));
                }
            }

            //Sort the rankings and return them
            return SortAndRank(rankings, 0);
        }

        public bool IsSire(Greyhound g)
        {
             List<Greyhound> currentGreyhoundChildren = ChildrenOf(g);
             if (currentGreyhoundChildren.Count > 0)
             {
                 if (currentGreyhoundChildren[0].Sire != null && currentGreyhoundChildren[0].Sire.Equals(g))
                     return true;
             }
             return false;
        }

        public bool IsDame(Greyhound g)
        {
            List<Greyhound> currentGreyhoundChildren = ChildrenOf(g);
            if (currentGreyhoundChildren.Count > 0)
            {
                if (currentGreyhoundChildren[0].Dam != null && currentGreyhoundChildren[0].Dam.Equals(g))
                    return true;
            }
            return false;
        }

        public List<Rank> RankComplete(PointScale pointScale, int rankTo, bool sunset)
        {
            List<Rank> rankings = new List<Rank>();
            int greyPoints = 0;
            foreach (Greyhound currentGreyhound in Greyhounds)
            {
                greyPoints = PointsFor(pointScale, currentGreyhound, sunset);
                if (greyPoints > 0)
                    rankings.Add(new Rank(0, currentGreyhound.Name, greyPoints ));
            }
            rankings.Sort(ComparePoints);
            rankings.Reverse();
            if (rankTo < rankings.Count)
                rankings.RemoveRange(rankTo + 1, rankings.Count - (rankTo + 1));

            rankings = ApplyRank(rankings);
            return rankings;
        }

        public List<Rank> RankComplete(PointScale pointScale, int rankTo, bool sunset, DateTime startDate, DateTime endDate)
        {
            List<Rank> rankings = new List<Rank>();
            int greyPoints = 0;
            foreach (Greyhound currentGreyhound in Greyhounds)
            {
                greyPoints = PointsFor(pointScale, currentGreyhound, sunset, startDate, endDate);
                if (greyPoints > 0)
                    rankings.Add(new Rank(0, currentGreyhound.Name, greyPoints));
            }
            //rankings.Sort(ComparePoints);
            //rankings.Reverse();
            IEnumerable<Rank> query = from r in rankings orderby r.Value descending, r.Name ascending select r;
            rankings = query.ToList<Rank>();
            if (rankTo < rankings.Count)
                rankings.RemoveRange(rankTo + 1, rankings.Count - (rankTo + 1));

            rankings = ApplyRank(rankings);
            return rankings;
        }

        public int PointsFor(PointScale pointScale, Greyhound currentGreyhound, bool sunset)
        {
            return PointsFor(pointScale, currentGreyhound, sunset, DateTime.MinValue, DateTime.MaxValue);
        }

        public Dictionary<Placing, int> PointsFor(PointScale pointScale, List<Placing> places)
        {
            Dictionary<Placing, int> placesAndPoints = new Dictionary<Placing, int>();
            foreach (Placing p in places)
            {
                if (!p.Race.IsNoRace){
                    placesAndPoints.Add(p,pointScale.PointsForPlace(p));
                }else{
                    placesAndPoints.Add(p, 0);
                }
            }
            return placesAndPoints;
        }

        public int PointsFor(PointScale pointScale, Greyhound currentGreyhound, bool sunset, DateTime startDate, DateTime endDate)
        {
            int totalPointsForGreyhound = 0;
            foreach (Placing p in PlacingsFor(currentGreyhound))
            {
                if (p.Race.Date >= startDate && p.Race.Date <= endDate && !p.Race.IsNoRace)
                    totalPointsForGreyhound += pointScale.PointsForPlace(p);
            }
            if (sunset)
                totalPointsForGreyhound -= SunsetPently(LastRaced(currentGreyhound));
            return totalPointsForGreyhound;
        }

        private int PointsForChildren(PointScale pointScale, Greyhound currentGreyhound, DateTime startDate, DateTime endDate)
        {
            int totalPointsForGreyhound = 0;
            foreach (Greyhound currentChild in ChildrenOf(currentGreyhound))
            {
                totalPointsForGreyhound += PointsFor(pointScale, currentChild, false, startDate, endDate);
            }
            return totalPointsForGreyhound;
        }

        private List<Rank> SortAndRank(List<Rank> rankings, int rankTo)
        {
            if (rankTo <= 0)
                rankTo = rankings.Count;

            rankings.Sort(ComparePoints);
            rankings.Reverse();
            if (rankTo < rankings.Count)
                rankings.RemoveRange(rankTo + 1, rankings.Count - (rankTo + 1));

            rankings = ApplyRank(rankings);
            return rankings;
        }

        public DateTime LastRaced(Greyhound aGreyhound)
        {
            List<Race> races = new List<Race>();
            foreach (Race r in RacesFor(aGreyhound))
                races.Add(r);
            if (races.Count > 0)
            {
                races.Sort(CompareRaceByDates);
                races.Reverse();
                return races[0].Date;
            }
            return DateTime.MinValue;
        }

        public DateTime LastRaced(List<Race> theRaces)
        {
            if (theRaces.Count > 0)
            {
                theRaces.Sort(CompareRaceByDates);
                theRaces.Reverse();
                return theRaces[0].Date;
            }
            return DateTime.Now;
        }

        private static int CompareRaceByDates(Race x, Race y)
        {
            if (x == null)
                if (y == null)
                    return 0;
                else
                    return -1;
            else
                if (y == null)
                    return 1;
                else
                    return x.Date.CompareTo(y.Date);
        }


        private Rank FindRank(List<Rank> ranks, String GreyhoundName)
        {
            foreach (Rank r in ranks)
            {
                if (r.Name.Equals(GreyhoundName))
                    return r;
            }
            return null;
        }

        public int SunsetPently(Greyhound gHound)
        {
            return SunsetPently(LastRaced(gHound));
        }

        private int SunsetPently(DateTime dateLastRaced)
        {
            if (dateLastRaced != null && dateLastRaced > DateTime.MinValue)
            {
                TimeSpan todayDiff = DateTime.Now - dateLastRaced;
                if (todayDiff.Milliseconds > 0)
                {
                    double monthsOff = todayDiff.TotalDays / 30;
                    monthsOff -= 4;
                    monthsOff = Math.Round(monthsOff, 0);
                    if (monthsOff <= 0)
                        return 0;

                    double sunsetPently = monthsOff * 10;
                    int roundedPently = Convert.ToInt32(Math.Round(sunsetPently, 0));
                    if (roundedPently > 1200)
                        return 1200;
                    else
                        return roundedPently;
                }
            }
            return 0;
        }

        protected List<Rank> ApplyRank(List<Rank> rankings)
        {

            for (int i = 0; i < rankings.Count; i++)
            {
                if (i > 0)
                    if (rankings[i].Value == rankings[i - 1].Value)
                        rankings[i].Ranking = rankings[i - 1].Ranking;// rankNumSeq[i] = rankNumSeq[i - 1];
                    else
                        rankings[i].Ranking = i + 1;
                else
                    rankings[i].Ranking = 1;
            }
            return rankings;
        }

        private int CompareNames(Rank x, Rank y)
        {
            if (x == null)
                if (y == null)
                    return 0;
                else
                    return -1;
            else
                if (y == null)
                    return 1;
                else
                {
                    int retval = x.Name.CompareTo(y.Name);
                    return retval;
                }
        }

        public static int CompareGreyhoundNames(Greyhound x, Greyhound y)
        {
            if (x == null)
                if (y == null)
                    return 0;
                else
                    return -1;
            else
                if (y == null)
                    return 1;
                else
                {
                    int retval = x.Name.CompareTo(y.Name);
                    return retval;
                }
        }

        private int ComparePoints(Rank x, Rank y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //

                    int retval = x.Value.CompareTo(y.Value);

                    //if values are the same, then finally sort by name
                    if (retval == 0){
                        retval = x.Name.CompareTo(y.Name);
                        
                    }

                    return retval;
                }
            }
        }
        #endregion

        #region Search
        public List<Greyhound> Winners(DateTime startDate, DateTime endDate)
        {
            List<Greyhound> found = new List<Greyhound>();
            foreach (Greyhound g in Greyhounds)
            {
                foreach(Placing p in PlacingsFor(g))
                {
                    if (p.Place == 1 && p.Race.Date >= startDate && p.Race.Date <= endDate)
                       found.Add(g);

                }
            }
            return found;
        }

        public List<Greyhound> GreyhoundSearch(String find)
        {
            List<Greyhound> found = new List<Greyhound>();
            foreach (Greyhound g in Greyhounds)
            {
                if (g.Name.Contains(find.ToUpper()))
                    found.Add(g);

            }
            return found;
        }

        public List<Race> RaceSearch(String find)
        {
            List<Race> found = new List<Race>();

            foreach (Race r in Races)
            {
                if (r.Name.Contains(find.ToUpper()))
                    found.Add(r);
            }
            return found;
        }

        #endregion
    }
}

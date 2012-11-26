using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Common;
using System.Windows.Forms;

namespace agra_gui
{
    public class AgraDBController
    {
        public static AgraDB agraDb;

        public static Hashtable forms = new Hashtable();
        public static bool defaultSunsetSetting = false;

        public static void BootApp()
        {
            Settings.loadSettings();
            LoadDatabase();
            AgraDBController.loadGUI();
        }

        public static void LoadDatabase()
        {
            AgraDBController.deserialize();
            AgraDBController.SortAll();
        }

        #region gui
        public static void loadGUI()
        {
            createForms();
        }

        public static void createForms()
        {
            forms.Add("addHound", new frmAddGreyhound());
            forms.Add("addRace", new frmAddRace());
            forms.Add("options", new frmOptions());
            forms.Add("database", new frmDataView());
            forms.Add("breeding", new frmBreeding());
            forms.Add("breedrank", new frmBreedRanking());
            forms.Add("textinput", new frmTextInput());
            forms.Add("gInfo", new frmGreyhoundInfo());
            forms.Add("about", new AboutBox1());
            forms.Add("stats", new frmStats());
        }

        public static Form getForm(String name)
        {
            if (forms.Contains(name))
            {
                Form foo = (Form)forms[name];
                return foo;
            }
            return null;
        }

        public static void navTo(Form caller, String name)
        {
            if (forms.Contains(name))
            {
                Form foo = (Form)forms[name];
                if (!foo.IsDisposed)
                {
                    foo.Location = caller.Location;
                    foo.ShowDialog(caller);
                }
            }
        }
        #endregion

        #region Saving and Loading via Serialization
        public static void serialize()
        {
            serializeBinary();
        }

        private static void serializeBinary()
        {
            FileStream fs = new FileStream(Settings.databaseFileName, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, agraDb);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public static void deserialize()
        {
            deserializeBinary();
        }

        private static void deserializeBinary()
        {
            if (File.Exists(Settings.databaseFileName))
            {
                try
                {
                    FileStream fs = new FileStream(Settings.databaseFileName, FileMode.Open);
                    BinaryFormatter formatter = new BinaryFormatter();
                    agraDb = (AgraDB)formatter.Deserialize(fs);
                    fs.Close();
                }
                catch (Exception e)
                {
                    Logging.log("Found database file but failed to deserialize. Following Exception Encountered: " + e.Message);
                    backupDatabase();
                    agraDb = new AgraDB();
                    DefaultPointSetup();
                }
            }
            else
            {
                Logging.log(String.Format("Cannot find database file {0}", Settings.databaseFileName));
                createNewDatabase();
            }
        }

        public static void createNewDatabase()
        {
            Logging.log(String.Format("Creating a new database file at location {0} with default rules", Settings.databaseFileName));
            agraDb = new AgraDB();
            DefaultPointSetup();
        }

        public static void checkForBackup()
        {
            if (agraDb != null && agraDb.lastBackup.AddMonths(1) < DateTime.Now)
            {
                backupDatabase();
            }
        }

        public static void backupDatabase()
        {
            String from = Settings.databaseFileName;
            String to = Settings.databaseFileName + DateTime.Now.ToFileTime().ToString();
            Logging.log(String.Format("Backingup File from {0} to {1}", from, to));
            File.Copy(from, to);
        }

        #endregion

        #region Adding
        public static Greyhound AddOrUpdateGreyhound(String gName)
        {
            return agraDb.AddGreyhound(gName);
        }

        //public static Race AddOrUpdateRace(string rName, DateTime date, GroupRank groupRank, Race_Type raceLength)
        //{
        //    Race find = Race.Retrieve(rName);
        //    if (find != null && find.Name.Equals(rName, StringComparison.OrdinalIgnoreCase))
        //        return find;
        //    else
        //    {
        //        Race raceToAdd = new Race(rName, date, groupRank, raceLength);
        //        raceToAdd.Persist();
        //        return Race.Retrieve(raceToAdd.Id);
        //    }
        //}


        //public static void AddRace(string name, DateTime date, GroupRank groupRank, Race_Type raceLength)
        //{
        //    Race raceToAdd = new Race(name, date, groupRank, raceLength);
        //    raceToAdd.Persist();

        //}


        //public static void AddRaceAndPlacing(String name, DateTime date, GroupRank groupRank,
        //    Race_Type raceLength, string grey, short place)
        //{
        //    Race race = AddOrUpdateRace(name, date, groupRank, raceLength);
        //    Greyhound newGreyhound = AddOrUpdateGreyhound(grey);
        //    AddPlacing(newGreyhound, race, place);
        //}

        public static bool AddRaceAndPlacings(String name, DateTime date, GroupRank groupRank,
            int raceLength, bool isNoRace, string[] greys, short[] places)
        {
            Race raceToAdd = agraDb.AddRace(name, date, groupRank, raceLength, isNoRace);
            if (greys.Length == places.Length)
            {
                for (int i = 0; i < greys.Length; i++)
                {
                    if (!String.IsNullOrEmpty(greys[i]))
                    {
                        Greyhound newGreyhound = AddOrUpdateGreyhound(greys[i]);
                        agraDb.AddPlacing(newGreyhound, raceToAdd, places[i]);
                    }
                }
            }
            return raceToAdd != null;
        }

        public static bool UpdateRaceAndPlacings(String currentName, DateTime currentDate, String newName, DateTime newDate, GroupRank groupRank,
            int raceLength, bool isNoRace, string[] greys, short[] places)
        {
            Race raceToUpdate = agraDb.GetRace(currentName, currentDate);
            raceToUpdate.Name = newName;
            raceToUpdate.Date = newDate;
            raceToUpdate.GroupRank = groupRank;
            raceToUpdate.RaceLength = raceLength;
            raceToUpdate.IsNoRace = isNoRace;

            //purge the placings in lue for the new ones
            foreach (Placing p in agraDb.PlacingsFor(raceToUpdate))
            {
                agraDb.DeletePlacing(p);
            }

            if (greys.Length == places.Length)
            {
                for (int i = 0; i < greys.Length; i++)
                {
                    if (!String.IsNullOrEmpty(greys[i]))
                    {
                        Greyhound newGreyhound = AddOrUpdateGreyhound(greys[i]);

                        agraDb.AddPlacing(newGreyhound, raceToUpdate, places[i]);
                    }
                }
            }
            return raceToUpdate != null;
        }

        public static bool AddOrUpdateRaceAndPlacings(String currentName, DateTime currentDate, GroupRank groupRank,
            int raceLength, bool isNoRace, string[] greys, short[] places)
        {
            Race raceToUpdate = agraDb.GetRace(currentName, currentDate);
            if (raceToUpdate == null)
            {
                return AddRaceAndPlacings(currentName, currentDate, groupRank, raceLength, isNoRace, greys, places);
            }
            else
            {
                return UpdateRaceAndPlacings(currentName, currentDate, currentName, currentDate, groupRank, raceLength, isNoRace, greys, places);
            }

        }

        //public static String test()
        //{
        //    StringBuilder report = new StringBuilder();

        //    //report.AppendLine(agraDb.GetRaceType("Group 1").ToString());
        //    report.AppendLine(agraDb.GetRaceType("Distance").ToString());
        //    report.AppendLine(agraDb.GetRaceType("Sprint").ToString());
        //    report.AppendLine(agraDb.GetRaceType("sprint").ToString());
        //    report.AppendLine(agraDb.GetRaceType("   sprint  ").ToString());

        //    // report.AppendLine(agraDb.GetGroupRank("Stay").ToString());
        //    report.AppendLine(agraDb.GetGroupRank("Group 1").ToString());
        //    report.AppendLine(agraDb.GetGroupRank("Group 2").ToString());
        //    report.AppendLine(agraDb.GetGroupRank("Group 3").ToString());
        //    report.AppendLine(agraDb.GetGroupRank(" group 1 ").ToString());

        //    return report.ToString();

        //}

        //public static bool AddRaceAndPlacings(String name, String date, String groupRank,
        //    String raceLength, string[] greys, short[] places)
        //{
        //        //DateTime theDate = DateTime.Parse(date);
        //        //GroupRank theGroupRank = agraDb.GetGroupRank(groupRank);
        //        ////string theRaceType = agraDb.GetRaceType(raceLength);

        //        //if (theGroupRank != null && theRaceType != null && theDate != null)
        //        //{
        //        //    return AddRaceAndPlacings(name, theDate, theGroupRank, theRaceType, greys, places);
        //        //}
        //        //else
        //            return false;
        //}

        public static void AddRaceAndPlacing(String name, DateTime date, GroupRank groupRank,
            string raceLength, string grey, short place)
        {
            //Race isThere = agraDb.GetRace(name, date);
            //Race raceToAdd;
            //if (isThere != null)
            //    raceToAdd = isThere;
            //else
            //    raceToAdd = agraDb.AddRace(name, date, groupRank, raceLength);

            //Greyhound newGreyhound = AddOrUpdateGreyhound(grey);
            //agraDb.AddPlacing(newGreyhound, raceToAdd, place);
            //if (greys.Length == places.Length)
            //{
            //    for (int i = 0; i < greys.Length; i++)
            //    {
            //        Greyhound newGreyhound = AddOrUpdateGreyhound(greys[i]);
            //        agraDb.AddPlacing(newGreyhound, raceToAdd, places[i]);
            //    }
            //}
        }

        public static bool deleteAllGreyhounds()
        {
            return agraDb.deleteAllGreyhounds();
        }

        public static bool deleteAllRaces()
        {
            return agraDb.deleteAllRaces();
        }

        #endregion

        #region DB Setup

        public static void DefaultPointSetup()
        {
            agraDb.AddGroupRank(1, "Group 1");
            agraDb.AddGroupRank(2, "Group 2");
            agraDb.AddGroupRank(3, "Group 3");

            PointScale ps = new SprintPointScale();
            PointScale sps = new SSPointScale();
            BreedingPointScale bps = new BreedingPointScale();

            agraDb.AddPointScale(ps);
            agraDb.AddPointScale(sps);
            agraDb.AddPointScale(bps);

            agraDb.AddRaceType("Sprint");
            agraDb.AddRaceType("Distance");
        }
        #endregion

        #region standard and simply Retival

        public static List<Greyhound> ListAllGreyhounds()
        {
            agraDb.Greyhounds.Sort(new AgraDB.GreyhoundComparer());
            return agraDb.Greyhounds;
        }

        public static void setGreyhounds(List<Greyhound> gs)
        {
            agraDb.Greyhounds = gs;
        }

        public static void setRaces(List<Race> rs)
        {
            agraDb.Races = rs;
        }

        public static List<Greyhound> ListAllGreyhounds(DateTime sd, DateTime ed)
        {
            List<Greyhound> gs = new List<Greyhound>();
            foreach (Greyhound g in agraDb.Greyhounds)
            {
                DateTime lastRaced = agraDb.LastRaced(g);
                if (lastRaced >= sd && lastRaced <= ed)
                    gs.Add(g);
            }
            return gs;
        }

        internal static List<Greyhound> ListAllGreyhoundsWithPlacings()
        {
            List<Greyhound> gWithPlacing = new List<Greyhound>();
            foreach (Greyhound g in agraDb.Greyhounds)
            {
                if (agraDb.PlacingsFor(g).Count > 0)
                    gWithPlacing.Add(g);
            }
            return gWithPlacing;
        }

        internal static List<Greyhound> ListAllGreyhoundsWithPlacings(DateTime sd, DateTime ed)
        {
            List<Greyhound> gWithPlacing = new List<Greyhound>();
            foreach (Greyhound g in agraDb.Greyhounds)
            {
                if (agraDb.PlacingsFor(g).Count > 0)
                {
                    DateTime lastRaced = agraDb.LastRaced(g);
                    if (lastRaced >= sd && lastRaced <= ed)
                        gWithPlacing.Add(g);
                }
            }
            return gWithPlacing;
        }

        public static List<Greyhound> ListAllSires()
        {
            List<Greyhound> gs = new List<Greyhound>(agraDb.Greyhounds.Count);
            foreach (Greyhound g in agraDb.Greyhounds)
            {
                if (agraDb.IsSire(g))
                    gs.Add(g);
            }
            return gs;
        }

        public static List<Greyhound> ListAllDams()
        {
            List<Greyhound> gs = new List<Greyhound>(agraDb.Greyhounds.Count);
            foreach (Greyhound g in agraDb.Greyhounds)
            {
                if (agraDb.IsDame(g))
                    gs.Add(g);
            }
            return gs;
        }

        public static IList ListAllGroupRanks()
        {
            return agraDb.GroupRanks;
        }

        public static List<String> groupRankDisplay()
        {
            List<String> s = new List<string>();
            s.Add("Select Group Level");
            foreach (GroupRank g in agraDb.GroupRanks)
            {
                s.Add(g.Name);
            }
            return s;
        }

        public static List<String> raceLengthDisplay()
        {
            List<String> s = new List<string>();
            s.Add("Select Race Length");
            foreach (String g in agraDb.RaceLengths)
            {
                s.Add(g);
            }
            return s;
        }

        public static List<Race> ListAllRaces()
        {
            return agraDb.Races;
        }

        public static List<Race> ListAllRaces(DateTime sd, DateTime ed)
        {
            List<Race> gs = new List<Race>();
            foreach (Race g in agraDb.Races)
            {
                DateTime lastRaced = g.Date;
                if (lastRaced >= sd && lastRaced <= ed)
                    gs.Add(g);
            }
            return gs;
        }

        /*
         * This lists all races that have at least one placing
         */
        public static List<RacePlaceDisplay> ListAllRacePlace(List<Race> raceList)
        {
            List<RacePlaceDisplay> racess = new List<RacePlaceDisplay>();
            foreach (Race r in raceList)
            {
                racess.Add(new RacePlaceDisplay(r, agraDb.PlacingsFor(r)));
            }
            return racess;
        }

        public static int PlacingComparison(Placing x, Placing y)
        {
            return x.Place.CompareTo(y.Place);
        }

        public static List<PlacingWithPoint> GivePlacingsPoints()
        {
            List<PlacingWithPoint> pwp = new List<PlacingWithPoint>();
            //GivePlacingsPoints();
            return pwp;
        }

        public static List<PlacingWithPoint> GivePlacingsPoints(List<Placing> places, PointScale ps)
        {
            List<PlacingWithPoint> pwp = new List<PlacingWithPoint>();
            Dictionary<Placing, int> temp = agraDb.PointsFor(ps, places);
            foreach (Placing p in temp.Keys)
            {
                pwp.Add(new PlacingWithPoint(p, temp[p].ToString()));
            }
            return pwp;
        }

        public class PlacingWithPoint
        {
            public PlacingWithPoint(Placing p, string points)
            {
                thePlace = p;
                point = points;
            }
            public Placing thePlace;
            string point;

            public Greyhound Greyhound { get { return thePlace.Greyhound; } }

            public Race Race { get { return thePlace.Race; } }

            public String Distance { get { return thePlace.Race.RaceLength.ToString(); } }

            public short Place
            {
                get { return thePlace.Place; }
                set { thePlace.Place = value; }
            }

            public string Points { get { return point; } }
        }

        public static List<Placing> ListAllPlacings()
        {
            return agraDb.Placings;
        }

        public static List<Placing> ListPlacingsForRace(Race race)
        {
            return agraDb.PlacingsFor(race);
        }

        public static List<string> ListAllRaceLengths()
        {
            return agraDb.RaceLengths;
        }



        public class RacePlaceDisplay
        {
            private string[] thePlacings;
            private string[] thePlacingPos;
            public Race theRace;

            /*
             *Takes a new race and a set of placings and orders the placing into race order
             * Placings that do not refer the race are ignored and only 8 placings are used from the list
             */
            public RacePlaceDisplay(Race r, List<Placing> placings)
            {
                theRace = r;
                thePlacings = new string[8];
                thePlacingPos = new string[8];
                placings.Sort(PlacingComparison);
                int i = 0;
                foreach (Placing p in placings)
                {
                    if (p.Race.Equals(theRace) && i < 8)
                    {
                        thePlacings[i] = p.Greyhound.Name;
                        thePlacingPos[i] = p.Place + "";
                        i++;
                    }
                }
            }
            public string Name { get { return theRace.Name; } }
            public DateTime Date { get { return theRace.Date; } }
            public GroupRank Group { get { return theRace.GroupRank; } }
            public string Length { get { return theRace.getRaceLengthAsString(); } }
            public string OnePlace { get { return thePlacingPos[0]; } }
            public string One { get { return thePlacings[0]; } }
            public string TwoPlace { get { return thePlacingPos[1]; } }
            public string Two { get { return thePlacings[1]; } }
            public string ThreePlace { get { return thePlacingPos[2]; } }
            public string Three { get { return thePlacings[2]; } }
            public string FourPlace { get { return thePlacingPos[3]; } }
            public string Four { get { return thePlacings[3]; } }
            public string FivePlace { get { return thePlacingPos[4]; } }
            public string Five { get { return thePlacings[4]; } }
            public string SixPlace { get { return thePlacingPos[5]; } }
            public string Six { get { return thePlacings[5]; } }
            public string SevenPlace { get { return thePlacingPos[6]; } }
            public string Seven { get { return thePlacings[6]; } }
            public string EightPlace { get { return thePlacingPos[7]; } }
            public string Eight { get { return thePlacings[7]; } }
        }

        public class RaceDisplay
        {
            public String Namea;
            public DateTime Datea;
            public String Groupa;
            public String Lengtha;
            public RaceDisplay(String n, DateTime date, string g, string l)
            {
                Namea = n;
                Datea = date;
                Groupa = g;
                Lengtha = l;
            }

            public string Name
            {
                get { return Namea; }
            }
            public DateTime Date
            {
                get { return Datea; }
            }
            public string Group
            {
                get { return Groupa; }
            }
            public string Length
            {
                get { return Lengtha; }
            }
        }

        #endregion

        #region Breeding
        //public static Greyhound AddOrUpdateGreyhoundWithBreeding(String gName, String gSire, String gDam)
        //{
        //    Greyhound newGreyhound = AddOrUpdateGreyhound(gName);
        //    Greyhound newSire = AddOrUpdateGreyhound(gSire);
        //    Greyhound newDam = AddOrUpdateGreyhound(gDam);

        //    newGreyhound.Greyhound_sire = newSire.Id;
        //    newGreyhound.Greyhound_dame = newDam.Id;

        //    return newGreyhound;            
        //}
        #endregion

        #region Rankings
        public static IList RankingSprintScale(bool sunset)
        {
            PointScale ps = new SprintPointScale();
            return agraDb.RankComplete(ps, 100, sunset);
        }

        public static List<Rank> Ranking()
        {
            return agraDb.RankStandard();
        }

        public static List<Rank> SireRanking()
        {
            return agraDb.RankingsForSireViaChildren(new SSPointScale());
        }

        public static List<Rank> DamRanking()
        {
            return agraDb.RankingsForDamViaChildren(new DamPointScale());
        }

        public static List<Rank> Ranking(bool sunset)
        {
            PointScale sps = new SSPointScale();
            return agraDb.RankComplete(sps, 100, sunset);
        }

        public static List<Rank> Ranking(RankType rankType, bool sunset, DateTime sd, DateTime ed)
        {
            if (rankType == RankType.Dam)
            {
                return agraDb.RankingsForDamViaChildren(new DamPointScale(), sd, ed);
            }
            if (rankType == RankType.Sire)
            {
                return agraDb.RankingsForSireViaChildren(new SprintPointScale(), sd, ed);
            }
            if (rankType == RankType.Sprint)
            {
                return agraDb.RankComplete(new SprintPointScale(), 100, sunset, sd, ed);
            }

            return agraDb.RankComplete(new SSPointScale(), 100, sunset, sd, ed);
        }

        public static List<Rank> Ranking(bool sunset, DateTime sd, DateTime ed)
        {
            PointScale sps = new SSPointScale();
            return agraDb.RankComplete(sps, 100, sunset, sd, ed);
        }

        public static IList RankingSprintScale(bool sunset, DateTime sd, DateTime ed)
        {
            return agraDb.RankComplete(new SprintPointScale(), 100, true, sd, ed);
        }

        public static List<Rank> SireRanking(DateTime sd, DateTime ed)
        {
            return agraDb.RankingsForSireViaChildren(new SSPointScale(), sd, ed);
        }

        public static List<Rank> DamRanking(DateTime sd, DateTime ed)
        {
            return agraDb.RankingsForDamViaChildren(new DamPointScale(), sd, ed);
        }

        //public static IList RankingsBreeding()
        //{
        //    Ranker r = new Ranker();
        //    PointScale ps = new SprintPointScale();
        //    return Ranker.Rank(ListAllGreyhounds(), ps, 100, false);
        //}
        #endregion

        #region Data Mining
        public static String MetaInfo()
        {
            return "";
        }

        public static int RaceRankCount(string o)
        {
            return agraDb.Races.FindAll(
                delegate(Race r) { return r.GroupRank.Name.Equals(o); }).Count;
        }

        public static int RaceRankTypeCount(string GroupRank, string Length)
        {
            return 0;
            //return agraDb.Races.FindAll(
            //delegate(Race r) { return r.GroupRank.Name.Equals(GroupRank) && r.Race_Length.Length.Equals(Length); }).Count;
        }

        public static int GreyhoundDistCount(string dist)
        {
            int count = 0;
            if (dist.Equals("Sprint") || dist.Equals("Distance"))
            {
                foreach (Greyhound g in agraDb.Greyhounds)
                {
                    if (GreyhoundDist(g).Equals(dist))
                        count++;
                }
            }
            return count;
        }

        public static string GreyhoundDist(Greyhound g)
        {
            int sprint = 0;
            int dist = 0;
            if (agraDb.RacesFor(g).Count > 0)
            {
                foreach (Race r in agraDb.RacesFor(g))
                {
                    if (r.isDistance())
                    {
                        dist++;
                    }
                    else
                    {
                        sprint++;
                    }
                }
                if (sprint == dist)
                    return "Both";
                if (sprint > dist)
                    return "Sprint";
                else
                    return "Distance";
            }
            return "None";
        }

        public static int RaceTypeCount(string o)
        {
            return 0;
            //return agraDb.Races.FindAll(
            //    delegate(Race r) { return r.Race_Length.Length.Equals(o); }).Count;
        }
        #endregion

        #region Complex Search and Retival
        public static Greyhound findGreyhound(string greyhoundName)
        {
            return agraDb.GetGreyhound(greyhoundName);
        }
        

        internal static void SortAll()
        {
            agraDb.Greyhounds.Sort(AgraDB.CompareGreyhoundNames);
        }


        public static List<PointPlace> ListAllPoints()
        {
            return agraDb.PointScales[0].getPointPlaces();
        }
        #endregion
    }
}

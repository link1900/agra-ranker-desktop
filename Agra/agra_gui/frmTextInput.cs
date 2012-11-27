using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Common;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace agra_gui
{
    public partial class frmTextInput : Form
    {
        public frmTextInput()
        {
            InitializeComponent();
        }

        private void btnGreyhoundImport_Click(object sender, EventArgs e)
        {
            greyhoundImport();
        }

        //private void superPhase(string line, string format)
        //{
        //    if (format.StartsWith("RUN:"))
        //    {
        //        string body = format.Substring(format.IndexOf(':'));
        //        string[] bodyparts = body.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                

        //    }
        //}

        //private void btnPhaseRace_Click(object sender, EventArgs e)
        //{
        //    if (txtReader.Text.Length > 0 && txtReader.Lines.Length > 0)
        //    {
        //        foreach (String s in txtReader.Lines)
        //        {
        //            //s = s.Trim();
        //            if (!String.IsNullOrEmpty(s) || s.StartsWith("//"))
        //            {
        //                String[] items = s.Split(new char[] { ',' }, 6);
        //                if (items.Length == 6)
        //                {
        //                    /*item[0] = race name
        //                     * item[1] = date
        //                     * item[2] = group rank
        //                     * item[3] = race length
        //                     * item[4] = placing
        //                     * item[5] = greyhoun d
        //                     * */

        //                    AgraDBController.AddRaceAndPlacing(items[0], DateTime.Parse(items[1]), 
        //                        AgraDBController.agraDb.GetGroupRank(items[2]),
        //                        items[3], items[5], Convert.ToInt16(items[4]));


        //                }
        //            }
        //        }
        //        txtReader.Text = "";
        //    }
        //}

        //private void btnRacePhase_Click(object sender, EventArgs e)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    int startCount=  AgraDBController.agraDb.Races.Count;
        //    int tick = 0;
        //    int err =0;
        //    List<String> cleared = new List<String>();
        //    if (txtRReader.Text.Length > 0 && txtRReader.Lines.Length > 0)
        //    {
        //        foreach (String s in txtRReader.Lines)
        //        {
        //            if (!String.IsNullOrEmpty(s) && !s.TrimStart().StartsWith("//"))
        //            {
        //                /*item[0] = race name
        //                 * item[1] = group rank
        //                 * item[2] = race length
        //                 * item[3] = date
        //                 * ab = placing
        //                 * item[4 to 11] = greyhounds
        //                 * 12 items total
        //                 * RUN: name, group, length, date, 1,2,3,4,5,6,7,8
        //                 * */

        //                String[] items = s.Split(new char[] { ',' }, 12);
        //                if (items.Length == 12 || items.Length > 5)
        //                {
        //                    int greyAmount = items.Length - 4;
        //                    if (greyAmount > 0)
        //                    {
        //                        string[] greys = new string[greyAmount];

        //                        for (int i = 0; i < greys.Length; i++)
        //                        {
        //                            greys[i] = items[i+4];
        //                        }


        //                        //Array.Copy(items, 5, greys, 0, greyAmount);
        //                        short[] ab = new short[]{1,2,3,4,5,6,7,8};
        //                        if (greys.Length > 0 && greys.Length < 9)
        //                        {
                                    
        //                            try
        //                            {
        //                                bool temp = AgraDBController.AddRaceAndPlacings(items[0], //race name
        //                                    items[3], //race date
        //                                    items[1], //group rank
        //                                    items[2], //race legnth
        //                                    greys, //greys 1 to 8
        //                                    ab);
        //                                if (temp)
        //                                    cleared.Add(s);
        //                            }
        //                            catch (Exception ea)
        //                            {
        //                                err++;
        //                                if (err < 10)
        //                                {
        //                                    sb.AppendLine(ea.Message);
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //AgraDBController.agraDb.AddRace(items[0], //race name
        //                        //items[3], //race date
        //                        //items[1], //group rank
        //                        //items[2]); //race legnth
        //                    }
        //                }
        //            }
        //            //Is a line
        //            tick++;
        //        }
        //        //lines all done
        //        if (err > 0)
        //            sb.AppendLine("There was " + err.ToString() + " errors or skiped lines");
        //        sb.AppendLine((AgraDBController.agraDb.Races.Count - startCount).ToString() + " Races where added out of a possible " + tick.ToString());
        //    }

        //    List<String> totala = new List<string>(txtRReader.Lines);
        //    List<String> final = new List<string>(txtRReader.Lines);
        //    foreach (string s in totala)
        //    {
        //        if (cleared.Contains(s))
        //            final.Remove(s);

        //    }
        //    txtRReader.Text = "";
        //    foreach (string s in final)
        //    {
        //        txtRReader.Text += "\r" + s;
        //    }
        //    MessageBox.Show(this, "Report: \r" + sb.ToString(), "Report", MessageBoxButtons.OK);

        //}

        private void buttonExportGreyhound_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "GreyhoundExport";
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)
            {
                greyhoundExport();
            }
            
        }

        private void databaseImportJSON(){
        }

        private void databaseExportJSON(){

        }

        private void greyhoundExport(){
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            int gcount = 0;
            progressBar1.Maximum = AgraDBController.ListAllGreyhounds().Count;
            StringBuilder sb = new StringBuilder();
            StringBuilder report = new StringBuilder();
            foreach (Greyhound g in AgraDBController.ListAllGreyhounds())
            {
                if (g != null && g.Name != null)
                {
                    sb.Append(g.Name);
                    gcount++;
                    sb.Append(",");
                    if (g.Sire != null)
                        sb.Append(g.Sire.Name);
                    sb.Append(",");
                    if (g.Dam != null)
                        sb.Append(g.Dam.Name);
                }
                sb.AppendLine("");
                progressBar1.PerformStep();
            }
            report.Append("Exported " + gcount + " Greyhound(s)");
            if (gcount > 0)
            {
                FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(sb.ToString());
                sw.Close();
                file.Close();
            }
            MessageBox.Show(this, "Report: \r" + report.ToString(), "Report", MessageBoxButtons.OK);
            progressBar1.Value = 0;
        }

        private void raceExport(){
            saveFileDialog1.FileName = "RaceExport";
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)
            {
                int gcount = 0;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                progressBar1.Maximum = AgraDBController.ListAllRacePlace(AgraDBController.ListAllRaces()).Count;
                StringBuilder sb = new StringBuilder();
                StringBuilder report = new StringBuilder();
                sb.AppendLine("Name"+","+"Date"+","+"Group"+","+"Length"+","+"One"+","+"OnePlace"+","+"Two"+","+"TwoPlace"+","+"Three"+","
                    +"ThreePlace"+","+"Four"+","+"FourPlace"+","+"Five"+","+"FivePlace"+","+"Six"+","+"SixPlace"+","+"Seven"+","+"SevenPlace"+","+"Eight"+","+"EightPlace");
                foreach (agra_gui.AgraDBController.RacePlaceDisplay r in AgraDBController.ListAllRacePlace(AgraDBController.ListAllRaces()))
                {//Phase: "race name, race date, group rank, race place, greyhound"
                    sb.AppendLine(r.Name + "," + r.Date + "," + r.Group + "," + r.Length + "," +
                        r.One + "," + r.OnePlace + ","
                        + r.Two + "," + r.TwoPlace + ","
                        + r.Three + "," + r.ThreePlace + ","
                        + r.Four + "," + r.FourPlace + ","
                        + r.Five + "," + r.FivePlace + ","
                        + r.Six + "," + r.SixPlace + ","
                        + r.Seven + "," + r.SevenPlace + ","
                        + r.Eight + "," + r.EightPlace );
                    gcount++;
                    progressBar1.PerformStep();

                }
                report.Append("Exported " + gcount + " Race(s)");
                FileHelper.saveText(saveFileDialog1.FileName, sb.ToString());
                MessageBox.Show(this, "Report: \r" + report.ToString(), "Report", MessageBoxButtons.OK);
                progressBar1.Value = 0;
            }
        }

        private void greyhoundImport(){
            openFileDialog1.Filter = "CSV Files|*.csv";
            openFileDialog1.FileName = "";
            // Check if the user selected a file from the OpenFileDialog.
            String fileText = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream file = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(file);
                fileText = sr.ReadToEnd();
                sr.Close();
                file.Close();
            }
            String[] fileLines = fileText.Split(new string[] { Environment.NewLine },StringSplitOptions.RemoveEmptyEntries);
            StringBuilder report = new StringBuilder();
            int gcount = 0;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            progressBar1.Maximum = fileLines.Length;
            foreach (String s in fileLines)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    String[] items = s.Split(new char[] { ',' }, 3, StringSplitOptions.None);
                    Greyhound g = null;
                    if (items.Length > 0 && items[0] != null && items[0].Length > 0)
                    {
                        items[0] = items[0].ToUpper().Trim().Replace("\"", "");
                        g = AgraDBController.AddOrUpdateGreyhound(items[0]);
                        gcount++;
                    }
                    if (items.Length > 1 && g != null && items[1] != null && items[1].Length > 0)
                    {
                        items[1] = items[1].ToUpper().Trim().Replace("\"", "");
                        g.Sire = AgraDBController.AddOrUpdateGreyhound(items[1]);
                        gcount++;
                    }
                    if (items.Length > 2 && g != null && items[2] != null && items[2].Length > 0)
                    {
                        items[2] = items[2].ToUpper().Trim().Replace("\"", "");
                        g.Dam = AgraDBController.AddOrUpdateGreyhound(items[2]);
                        gcount++;
                    }
                    progressBar1.PerformStep();
                }
            }
            report.Append("Imported " + gcount + " Greyhound(s)");
            MessageBox.Show(this, "Report: \r" + report.ToString(), "Report", MessageBoxButtons.OK);
            progressBar1.Value = 0;
        }

        private void raceImport(){
            openFileDialog1.Filter = "CSV Files|*.csv";
            openFileDialog1.FileName = "";
            // Check if the user selected a file from the OpenFileDialog.
            String fileText = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileText = FileHelper.readText(openFileDialog1.FileName);
            }
            String[] fileLinesArray = fileText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            progressBar1.Maximum = fileLinesArray.Length;
            StringBuilder report = new StringBuilder();
            int startCount = AgraDBController.agraDb.Races.Count;
            int lineCount = 0;
            int err = 0;
            int raceadded = 0;
            List<String> cleared = new List<String>();
            List<String> fileLines = new List<string>(fileLinesArray);
            if (fileLines.Count > 0){
                //read first row to get the header
                progressBar1.PerformStep();
                String firstLine = fileLines[0];
                fileLines.RemoveAt(0);
                String[] items = firstLine.Split(new char[] { ',' }, StringSplitOptions.None);
                List<Dictionary<string, string>> data = convertDic(items, fileLines);
                //convert each line into a array of dictorys
                //'Name','Date','Group','Length','One','OnePlace','Two','TwoPlace','Three','ThreePlace','Four','FourPlace','Five','FivePlace','Six','SixPlace','Seven','SevenPlace','Eight','EightPlace'
                foreach (Dictionary<string, string> row in data){
                    progressBar1.PerformStep();
                    lineCount++;
                    try{
                        //add all greyhounds
                        List<String> greys = new List<String>();
                        foreach (String s in new String[] { "One", "Two", "Three", "Four","Five","Six","Seven","Eight"}){
                            if (!String.IsNullOrWhiteSpace(row[s])){
                                greys.Add(row[s].Replace(",", "").Replace("\"", "").ToUpper().Trim());
                            }
                        }

                        //setup placings
                        List<short> placings = new List<short>();
                        foreach (String s in new String[] { "OnePlace", "TwoPlace", "ThreePlace", "FourPlace", "FivePlace", "SixPlace", "SevenPlace", "EightPlace" })
                        {
                            if (!String.IsNullOrWhiteSpace(row[s])){
                                placings.Add(short.Parse(row[s]));
                            }
                        }

                        //setup race
                        String raceName = null;
                        DateTime raceDate = DateTime.MinValue;
                        GroupRank groupRank = null;
                        String raceLength = null;
                        int raceLengthvalue = 0;

                        if (!String.IsNullOrWhiteSpace(row["Name"])){
                            raceName = row["Name"];
                        }
                        if (!String.IsNullOrWhiteSpace(row["Date"])){
                            raceDate = DateTime.Parse(row["Date"]);
                        }
                        if (!String.IsNullOrWhiteSpace(row["Group"])){
                            groupRank = AgraDBController.agraDb.GetGroupRank(row["Group"]);
                        }
                        if (!String.IsNullOrWhiteSpace(row["Length"])){
                            raceLength = row["Length"];
                            raceLengthvalue = Race.getBasicLengthForRaceLength(raceLength);
                        }
                        if (raceName != null && raceDate != DateTime.MinValue && groupRank != null && raceLength != null)
                        {
                            bool added = AgraDBController.AddOrUpdateRaceAndPlacings(raceName, //race name
                                raceDate, //race date
                                groupRank, //group rank
                                raceLengthvalue, //race legnth
                                false,
                                greys.ToArray(), //greys 1 to 8
                                placings.ToArray());
                            if (added) raceadded++;
                            
                        }
                    }catch (Exception ea){
                        err++;
                        if (err < 10) {
                            report.AppendLine("Error at line " + lineCount +" : "  + ea.Message);
                        }
                    }

                }
                //lines all done
                if (err > 0){
                    report.AppendLine("There was " + err.ToString() + " errors or skiped lines");
                }
                report.AppendLine(raceadded + " Races where added out of a possible " + lineCount.ToString());
            }
            MessageBox.Show(this, "Report: \r" + report.ToString(), "Report", MessageBoxButtons.OK);
        }

        private List<Dictionary<string,string>> convertDic(String[] headerLine, List<String> lines){
            List<Dictionary<string,string>> data = new List<Dictionary<string,string>>();
            foreach (String line in lines){
                String[] cells = line.Split(new char[] { ',' }, StringSplitOptions.None);
                Dictionary<string,string> temp = new Dictionary<string,string>();
                int i = 0;
                foreach (String cell in cells){
                    temp.Add(headerLine[i],cell);
                    i++;
                }
                data.Add(temp);
            }
            return data;
        }

        private void createRace(){
        }

        private void createGreys(){
        }

        private void buttonExportRaces_Click(object sender, EventArgs e)
        {
            raceExport();
        }

        private void buttonRaceImport_Click(object sender, EventArgs e)
        {
            raceImport();
        }

        private void btnExportGreyJSON_Click(object sender, EventArgs e)
        {
            greyExportJSON();
        }

        private void greyExportJSON()
        {
            saveFileDialog1.FileName = "GreyhoundExport";
            saveFileDialog1.Filter = "json files (*.json)|*.json";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)
            {
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                int gcount = 0;
                progressBar1.Maximum = AgraDBController.ListAllGreyhounds().Count;
                StringBuilder sb = new StringBuilder();
                StringBuilder report = new StringBuilder();
                gcount= AgraDBController.ListAllGreyhounds().Count;
                report.Append("Exported " + gcount + " Greyhound(s)");
                String data = serializeJson(AgraDBController.ListAllGreyhounds());
                if (gcount > 0)
                {
                    FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(file);
                    sw.Write(data);
                    sw.Close();
                    file.Close();
                }
                MessageBox.Show(this, "Report: \r" + report.ToString(), "Report", MessageBoxButtons.OK);
                progressBar1.Value = 0;
            }
        }

        private void greyhoundImportJSON()
        {
            openFileDialog1.Filter = "JSON Files|*.json";
            openFileDialog1.FileName = "";
            String fileText = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream file = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(file);
                fileText = sr.ReadToEnd();
                sr.Close();
                file.Close();
            }
            if (!String.IsNullOrWhiteSpace(fileText))
            {
                List<Greyhound> gs = deserializeJson<List<Greyhound>>(fileText);
                AgraDBController.setGreyhounds(gs);
            }
            int gcount = AgraDBController.ListAllGreyhounds().Count;
            StringBuilder report = new StringBuilder();
            report.Append("Imported " + gcount + " Greyhound(s)");
            MessageBox.Show(this, "Report: \r" + report.ToString(), "Report", MessageBoxButtons.OK);
        }

        public static string serializeJson<T>(T obj)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.Default.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }

        public static T deserializeJson<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            return obj;
        }

        private void importDatabaseJSON(){
        }

        private void exportDatabaseJSON(){
        }

        private void button1_Click(object sender, EventArgs e)
        {
            greyhoundImportJSON();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportDatabaseJSON();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            importDatabaseJSON();
        }

        private void frmTextInput_Load(object sender, EventArgs e)
        {

        }
    }
}
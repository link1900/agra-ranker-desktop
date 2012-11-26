using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace agra_gui
{
    class Settings
    {
        public static String settingFileName = "settings.ini";
        public static String databaseFileName = "AgraDB.dat";
        public static String logFileName = "log.txt";

        public static void loadSettings(){
            //var data = new Dictionary<string, string>();
            //foreach (var row in File.ReadAllLines(settingFileName))
            //{
            //    var rowParts = row.Split('=');
            //    string left = rowParts.ElementAtOrDefault(0);
            //    string right = rowParts.ElementAtOrDefault(1);
            //    data.Add(left, right);
            //    Console.WriteLine(left + " " + right);
            //}
        }

        public void saveSettings(){
        }

    }
}

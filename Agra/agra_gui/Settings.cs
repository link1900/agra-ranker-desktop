using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace agra_gui
{
    class Settings
    {
        public static String settingFileLocation = "settings.ini";
        public static String databaseFileLocation = "agraDB.dat";
        public static String databaseFileLocation = "logs.txt";
        public void loadSettings(){
            Dictionary<string, string> data = new Dictionary<string, string>();
            //foreach (var row in File.ReadAllLines(settingFileLocation))
            //    data.Add(row.Split('=')[0], string.join("=", row.Split('=').Skip(1).ToArray()));
        }

        public void saveSettings(){
        }

    }
}

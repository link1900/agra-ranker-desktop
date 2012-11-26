using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace agra_gui
{
    class Logging
    {
        public static void log(String text)
        {
            try
            {
                //Opens a new file stream which allows asynchronous reading and writing
                using (StreamWriter sw = new StreamWriter(new FileStream(Settings.logFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
                {
                    //Writes the method name with the exception and writes the exception underneath
                    sw.WriteLine(String.Format("{0} ({1}) - {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), text.ToString()));
                }
            }
            catch (IOException)
            {
                if (!File.Exists(Settings.logFileName))
                {
                    File.Create(Settings.logFileName);
                }
            }
        }
    }
}

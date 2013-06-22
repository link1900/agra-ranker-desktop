using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Common
{
    public class FileHelper
    {
        public static void saveText(String fileName, String text){
            if (text.Length > 0)
            {
                FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(text);
                sw.Close();
                file.Close();
            }
        }

        public static String readText(String fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            String fileText = sr.ReadToEnd();
            sr.Close();
            file.Close();
            return fileText;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APBD2
{
    public class Errors
    {
        public static StreamWriter file;

        public Errors(String s, String path)
        {
            var now = DateTime.Now;
            file = new StreamWriter(path, true);
            file.WriteLine(now.ToString() + " - " + s);
            file.Close();
        }
    }
}

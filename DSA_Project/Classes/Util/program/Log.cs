using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace DSA_Project
{
    [ExcludeFromCodeCoverage]
    public static class Log
    {
        private static void writeMessage(String line)
        {
            String localDate        = DateTime.Now.ToShortDateString();
            String localDateTime    = DateTime.Now.ToString();

            localDate = localDate.Replace(".", "");

            String LogFile = Directory.GetCurrentDirectory();
            LogFile = Path.Combine(LogFile, "Log");
            LogFile = Path.Combine(LogFile, localDate + ".txt");

            createLogFile(LogFile);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@LogFile, true))
            {
                file.WriteLine(localDateTime + " " +line);
            }
        }

        private static void createLogFile(String LogFile)
        {
            String localDateTime = DateTime.Now.ToString();

            if (!File.Exists(LogFile))
            {   
                String[] lines = { localDateTime + " Created" };
                System.IO.File.WriteAllLines(@LogFile, lines);
            }
        }

        public static void writeLogLine(String line)
        {
            writeMessage(line);
        }
        public static void throwError(Exception e)
        {
            String exception = e.GetType().ToString();

            writeMessage(exception + ", " + e.Message);
        }
    }
}

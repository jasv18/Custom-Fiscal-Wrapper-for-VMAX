using System.IO;
using System;

namespace csharpvmaxapp
{
    internal class Logger
    {
        private const string LOG_FILE = @"log.txt";
        private static readonly DateTime localDate = DateTime.Now;
        public static void Error(int id, string message)
        {
            using (StreamWriter sw = new StreamWriter(LOG_FILE, true))
            {
                sw.WriteLine("{0} - Error no: {1} - Error description: {2}", localDate.ToString(), id.ToString(), message.ToUpper());
                sw.Flush();
            }
        }
        public static void Info(string message)
        {
            using (StreamWriter sw = new StreamWriter(LOG_FILE, true))
            {
                sw.WriteLine("{0} - Info: {1}", localDate.ToString(), message.ToUpper());
                sw.Flush();
            }
        }
    }
}
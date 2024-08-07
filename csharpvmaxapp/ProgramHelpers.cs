using System.IO;
using System;

namespace csharpvmaxapp
{
    internal static class ProgramHelpers
    {
        internal const string PORT = "COM1";
        internal const string PATH_CONFIG = @".\\config.ini";

        internal static string ReadingConfigFile()
        {
            try
            {
                if (!File.Exists(PATH_CONFIG))
                {
                    Logger.Error(7, "config file does not exists");
                    Environment.Exit(7);
                }
            }
            catch
            {
                Logger.Error(8, "error verifing config file");
                Environment.Exit(8);
            }
            string portToUse = string.Empty;
            try
            {
                StreamReader sr = new StreamReader(PATH_CONFIG);
                string readedLine = sr.ReadLine();

                while (readedLine != null)
                {
                    string line = readedLine.Trim();
                    if (line.Length != 0)
                    {
                        string[] partOfLine = line.Split(':');
                        if (partOfLine[0].Trim().ToUpper() == "PORT" && partOfLine[1].Trim().Length != 0)
                        {
                            portToUse = partOfLine[1].Trim().Replace(" " , string.Empty).ToUpper();
                        }
                    }
                    readedLine = sr.ReadLine();
                }
            }
            catch
            {
                Logger.Error(1, "config reading error");
                Environment.Exit(1);
            }
            return string.IsNullOrEmpty(portToUse) ? PORT : portToUse;
        }

        internal static void ValidateArgs(string[] args)
        {
            if (args.Length == 0)
            {
                Logger.Error(4, "no arguments");
                Environment.Exit(4);
            }
            else
            {
                string filePath = $@".\\{args[0]}";
                try
                {
                    if (!File.Exists(filePath))
                    {
                        Logger.Error(6, "file does not exists");
                        Environment.Exit(6);
                    }
                }
                catch
                {
                    Logger.Error(5, "error verifing file");
                    Environment.Exit(5);
                }
            }
        }

        internal static void ValidatePort(string port)
        {
            try
            {
                VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();
                uint response = objVmax.AbrirPuerto(port);

                if (response == 0)
                {
                    _ = objVmax.Cancelar();
                    _ = objVmax.CerrarPuerto();
                }
                else
                {
                    Logger.Error(2, "port unavailable");
                    Environment.Exit(2);
                }

            }
            catch
            {
                Logger.Error(3, "error opening port");
                Environment.Exit(3);
            }
        }
    }
}
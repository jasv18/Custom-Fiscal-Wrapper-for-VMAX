using System;
using System.IO;

namespace csharpvmaxapp
{
    class Program
    {
        static void Main(string[] args)
        {            
            ProgramHelpers.ValidateArgs(args);
            var vfile = args[0];            
            var port = ProgramHelpers.ReadingConfigFile();
            var nameReponseFile = "";
            var codFacturaInt = "";
            if (args.Length > 1)
            {
                nameReponseFile = args[1];
                if (File.Exists(nameReponseFile))
                {
                    File.Delete(nameReponseFile);
                }
            }
            if (args.Length > 2)
            {
                codFacturaInt = args[2];
            }
                ProgramHelpers.ValidatePort(port);
            FileManager.Manage(file: vfile,
                               port: port,
                               nameResponseFile: nameReponseFile,
                               codFacturaInt: codFacturaInt);
            Logger.Info("No error");
            Environment.Exit(0);
        }
    }
}


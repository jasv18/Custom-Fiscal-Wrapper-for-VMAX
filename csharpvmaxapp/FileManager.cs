using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace csharpvmaxapp
{
    public static class Extensions
    {
        public static string FilterStr(this string str, List<string> charsToRemove)
        {
            foreach (string c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }
            return str;
        }
    }
    internal class FileManager
    {
        private const char Separator1 = '\\';
        private const char Separator2 = '\t';
        private static readonly List<string> charsToRemove = new List<string>() { "(", ")", "[", "]", "{", "}", "@", "^", "/", "*", "-", "_", "%", "<", ">", "=", "#" };

        public static void Manage(string file, string port, string nameResponseFile = "", string codFacturaInt = "")
        {
            var filePath = $@".\\{file}";
            var responseFilePath = "";
            List<string> lines = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                string readedLine = sr.ReadLine();                
                while (readedLine != null)
                {
                    string item = readedLine.ToString();
                    lines.Add(item);
                    readedLine = sr.ReadLine();
                }
            }
            catch
            {
                Logger.Error(1, "config reading error");
                Environment.Exit(1);
            }
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();
            try
            {
                uint ret = 0;
                ret = objVmax.AbrirPuerto(port);
                _ = objVmax.ObtenerEstado();
                if (ret == 0)
                {
                    uint? numfactura = null;
                    string[] item = null;
                    string[] parameters = null;
                    foreach (var line in lines)
                    {
                        ret = 0;
                        item = line.Split(Separator1);
                        parameters = item[1].Split(Separator2);
                        switch (item[0].ToUpper())
                        {
                            case "ABRIRCF":
                                ret = objVmax.AbrirCF(parameters[0].ToString(), parameters[1].ToString(), parameters[2].ToString(), parameters[3].ToString(), parameters[4].ToString(), parameters[5].ToString(), parameters[6].ToString(), int.Parse(parameters[7]));                          
                                if (ret == 0)
                                {
                                    uint uinumFac = objVmax.RetornoAbrirFactura.uiNumeroFactura;
                                    if (uinumFac != 0)
                                    {
                                        numfactura = uinumFac;
                                    }                                    
                                }
                                break;
                            case "TEXTONOFISCAL":
                                ret = objVmax.TextoNoFiscal(parameters[0]);
                                break;
                            case "ITEM":                                
                                int carro = int.Parse(parameters[5]);
                                string sDescripcion = parameters[0].FilterStr(charsToRemove);
                                int carroT = carro - 1;
                                sDescripcion = sDescripcion.Length > carroT ? sDescripcion.Substring(0, carroT) : sDescripcion;
                                ret = objVmax.Item(sDescripcion, parameters[1], parameters[2], parameters[3], parameters[4], int.Parse(parameters[5]));
                                break;
                            case "SUBTOTAL":
                                ret = objVmax.Subtotal();
                                break;
                            case "SUBTOTALT":
                                ret = objVmax.SubtotalT(parameters[0].ToString());
                                break;
                            case "PAGOCF":
                                ret = objVmax.PagoCF(parameters[0], parameters[1], int.Parse(parameters[2]));
                                break;
                            case "CERRAR":
                                ret = objVmax.Cerrar();
                                if (ret == 0 && codFacturaInt.Length != 0 && nameResponseFile.Trim().Length != 0 && numfactura != null)
                                {
                                    responseFilePath = $@".\\{nameResponseFile}";
                                    string[] textToWrite = new string[2];
                                    textToWrite[0] = codFacturaInt;
                                    textToWrite[1] = numfactura.ToString();
                                    StreamWriter sw = new StreamWriter(responseFilePath);
                                    string valueToWrite = string.Join("\t", textToWrite).TrimEnd();
                                    sw.Write(valueToWrite);
                                    sw.Flush();
                                }
                                break;
                            case "REPORTEX":
                                ret = objVmax.ReporteX();
                                break;
                            case "REPORTEZ":
                                ret = objVmax.ReporteZ();
                                break;
                            case "REIMPRIMIRDOCUMENTO":
                                ret = objVmax.ReimprimirDocumento(parameters[0].ToString(), parameters[1].ToString());
                                break;
                            default:
                                break;
                        }
                        if (ret != 0)
                        {
                            break;
                        }
                    }
                    if (ret != 0)
                    {
                        _ = objVmax.Cancelar();
                        _ = objVmax.CerrarPuerto();
                        string itemString = string.Join("\n", item);
                        string parametersString = string.Join("\n", parameters);
                        Logger.Error(11, $"printer error return.\nItem:\n{itemString}\nParameters:\n{parametersString}\nRetorno:{ret}");
                        // Logger.Error(11, "printer error return");
                        Environment.Exit(11);
                    }
                    ret = objVmax.CerrarPuerto();
                }
                else
                {
                    Logger.Error(10, "printer port open error");
                    Environment.Exit(10);
                }
            }
            catch
            {
                _ = objVmax.Cancelar();
                _ = objVmax.CerrarPuerto();
                Logger.Error(9, "bad execution");
                Environment.Exit(9);
            }
        }
    }
}

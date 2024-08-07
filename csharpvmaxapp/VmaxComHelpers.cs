using System.Threading;
using System;

namespace csharpvmaxapp
{
    internal class VmaxComHelpers
    {
        public static void DocumentoNofiscal(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;

            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.AbrirDNF();
            ret = objVmax.TextoNoFiscal("Prueba de documento no fiscal");
            ret = objVmax.TextoNoFiscal("Prueba de documento no fiscal");
            ret = objVmax.CerrarDNF();
            ret = objVmax.CerrarPuerto();

        }
        public static void Reporte(string tipo, string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;

            ret = objVmax.AbrirPuerto(puerto);

            if (tipo == "X")
                ret = objVmax.ReporteX();
            else
                ret = objVmax.ReporteZ();

            ret = objVmax.CerrarPuerto();
        }
        public static void Factura(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;
            uint numfactura = 0;
            uint numultimafactcancelada = 0;

            ret = objVmax.AbrirPuerto(puerto);

            //Vender 1 item con impuestos de tipo Exento:

            ret = objVmax.AbrirCF("test 1", "test 2", "1", "", "", "", "", 40);

            numfactura = objVmax.RetornoAbrirFactura.uiNumeroFactura;
            numultimafactcancelada = objVmax.RetornoAbrirFactura.uiUltNumeroCancelado;

            ret = objVmax.TextoNoFiscal("*          C29 0029704984 T000010544          *");
            ret = objVmax.TextoNoFiscal("Cliente  : MIRIAN BAUTISTA              ");
            ret = objVmax.TextoNoFiscal("CI/RIF   : V12229865                    ");
            ret = objVmax.TextoNoFiscal("Direccion: VALENCIA                     ");
            ret = objVmax.TextoNoFiscal("Telefono :                              ");
            ret = objVmax.TextoNoFiscal("------------------------------------------------");
            ret = objVmax.TextoNoFiscal("OMEGA 3 1000 MG X 100 CAP ALFA VITAMINS         ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00007364                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "3431", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("ASIA ASPIRINA 81 MG X 100 TAB                   ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00024439                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "2727", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("SOLUCION INY RINGER LACTATO 50P0ML BOT           ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00000505                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "1284", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("AL-FLEXIL GLUCO+CHONDRO X 120CAP ALFA VI        ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00007358                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "5840", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("NUTRAGUM KIDS VITAMINA C X 90 GOMAS             ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00020007                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "4069", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("ACIDO FOLICO 10 MG X 30 TAB   0                  ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00004569                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "855", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("IVERMECTINA 6MG X 16 TAB FC PH<SYN>ARMA                  ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00018294                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "1748", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("VITAMINA C 500 MG X12 T. MAS NJA SANTE                  ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00006457                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "683", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("AZITROMICINA 500 MG X 6 TAB R                   ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00004918                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "1284", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("ESOMEPRAZOL 40@MG X 30 TAB     0                  ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00000492                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "1606", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("CEFTRIAXONA 1G X F.AMP                          ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00000557                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "429", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("BROMHEXINA 4 MG/5ML X 120 SOL P SANTE                  ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00006387                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "975", "0", "1", 40);
            ret = objVmax.TextoNoFiscal("DYNAMICS PUERTO OBTURADOR ESTERIL               ");
            ret = objVmax.TextoNoFiscal("Codigo: 0C00001874                              ");
            ret = objVmax.Item(objVmax.RetornoAbrirFactura.uiNumeroFactura + "", "1000", "45", "0", "1", 40);
            ret = objVmax.Subtotal();
            ret = objVmax.PagoCF(objVmax.RetornoSubtotal.llSubtotal.ToString(), "EFECTIVO", 1);
            ret = objVmax.TextoNoFiscal("     Trans. Aut. Por: JESUS ARAUJO");
            ret = objVmax.TextoNoFiscal("Cod Vendedor: 000000000001              ");
            ret = objVmax.TextoNoFiscal("Nombre Vendedor: , SIN VENDEDOR         ");
            ret = objVmax.TextoNoFiscal("                                        ");
            ret = objVmax.Cerrar();
        }

        public static void Factura_Descuento(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;
            uint numfactura = 0;
            uint numultimafactcancelada = 0;

            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.AbrirCF("Elepos Electrónica y Puntos de Venta", "J309860895", "1", "294", "12345", "", "", 40);

            numfactura = objVmax.RetornoAbrirFactura.uiNumeroFactura;
            numultimafactcancelada = objVmax.RetornoAbrirFactura.uiUltNumeroCancelado;

            ret = objVmax.Item("Item de Prueba", "2000", "1800", "0", "1", 40);
            ret = objVmax.Item("Item de Prueba", "1000", "3200", "2", "1", 40);
            ret = objVmax.Item("Item de Prueba", "1000", "2500", "3", "1", 40);
            ret = objVmax.Item("Item de Prueba", "1000", "7600", "3", "1", 40);
            ret = objVmax.DescuentoCF("Descuento global   ", "500", "1000", "2500", "900");
            ret = objVmax.Subtotal();
            ret = objVmax.PagoCF("45200", "Tarjetas             ", 1);
            ret = objVmax.Cerrar();
            ret = objVmax.CerrarPuerto();

        }
        public static void Factura_Anulacion_Descuento_Item(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;
            uint numfactura = 0;
            uint numultimafactcancelada = 0;

            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.AbrirCF("Elepos Electrónica y Puntos de Venta", "J309860895", "1", "294", "12345", "", "", 40);

            numfactura = objVmax.RetornoAbrirFactura.uiNumeroFactura;
            numultimafactcancelada = objVmax.RetornoAbrirFactura.uiUltNumeroCancelado;

            ret = objVmax.Item("Articulo 1", "3000", "1800", "0", "1", 40);
            ret = objVmax.Item("Articulo 2", "3000", "3200", "2", "1", 40);
            ret = objVmax.Item("Articulo 3", "1000", "2500", "3", "1", 40);
            ret = objVmax.Item("Articulo 4", "1000", "7600", "3", "1", 40);
            ret = objVmax.ItemDesc("Descuento de Articulo 1       ", "1000", "1800", "0", "0", 40);
            ret = objVmax.ItemDesc("Descuento de Articulo 2       ", "1000", "1000", "2", "0", 40);
            ret = objVmax.Item("Devolucion de Articulo 3       ", "1000", "2500", "3", "0", 40);
            ret = objVmax.Subtotal();
            ret = objVmax.PagoCF("45200", "Tarjetas             ", 1);
            ret = objVmax.Cerrar();
            ret = objVmax.CerrarPuerto();

        }
        public static void Nota_De_Credito(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;

            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.AbrirCF("Elepos Electrónica y Puntos de Venta", "J309860895", "2", "000000001", "VMX1500001", "110815", "1030", 40);
            ret = objVmax.Item("Item de Prueba Exento", "1000", "999999999", "0", "1", 40);
            ret = objVmax.Item("Item de Prueba General", "1000", "999999999", "1", "1", 40);
            ret = objVmax.Item("Item de Prueba Reducido", "1000", "999999999", "2", "1", 40);
            ret = objVmax.Item("Item de Prueba Adicional", "1000", "999999999", "3", "1", 40);
            ret = objVmax.Item("Item de Prueba Percibido", "1000", "999999999", "4", "1", 40);
            ret = objVmax.Item("Item de Prueba", "10000", "1000", "3", "1", 40);
            ret = objVmax.Subtotal();
            ret = objVmax.Cerrar();
            ret = objVmax.CerrarPuerto();
        }

        public static void ReportesElectronicos(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            int respuesta;

            System.Console.WriteLine("Indique el reporte electronico que desea obtener: ");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine("1. Reporte Informativo");
            System.Console.WriteLine("2. Reporte de memoria fiscal");
            System.Console.WriteLine("3. Reporte de contadores");
            respuesta = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("");

            switch (respuesta)
            {

                case 1:
                    datosfiscales(puerto);
                    Console.Clear();
                    break;

                case 2:
                    memoriafiscal(puerto);
                    Console.Clear();
                    break;
                case 3:
                    reporteContadores(puerto);
                    Console.Clear();
                    break;
            }
        }
        public static void datosfiscales(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();
            uint ret = 0;
            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.ObtenerReporteInformativo();
            ret = objVmax.AbrirDNF();
            ret = objVmax.TextoNoFiscal("Descriptor del Organismo de hacienda: " + objVmax.RetornoMI.sDescriptorOrganismoHacienda.ToString());
            ret = objVmax.TextoNoFiscal("Rif: " + objVmax.RetornoMI.sRif);
            ret = objVmax.TextoNoFiscal("Tasa 1: " + objVmax.RetornoMI.sTasa_1);
            ret = objVmax.TextoNoFiscal("Tasa 2: " + objVmax.RetornoMI.sTasa_2);
            ret = objVmax.TextoNoFiscal("Tasa 3: " + objVmax.RetornoMI.sTasa_3);
            ret = objVmax.TextoNoFiscal("Numero de decimales: " + objVmax.RetornoMI.sNumDecimales);
            ret = objVmax.TextoNoFiscal("Descriptor de la moneda: " + objVmax.RetornoMI.sDescMoneda);
            ret = objVmax.TextoNoFiscal("Abreviación de la moneda " + objVmax.RetornoMI.sAbreviacionMoneda);
            ret = objVmax.TextoNoFiscal("Metodo de impuesto: " + objVmax.RetornoMI.sMetodoImpuesto);
            ret = objVmax.TextoNoFiscal("Serial: " + objVmax.RetornoMI.sSerial);
            ret = objVmax.TextoNoFiscal("Fecha: " + objVmax.RetornoMI.sFecha);
            ret = objVmax.TextoNoFiscal("Hora: " + objVmax.RetornoMI.sHora);
            ret = objVmax.CerrarDNF();
            ret = objVmax.CerrarPuerto();
        }
        public static void memoriafiscal(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();
            uint ret = 0;
            string numZ;

            ret = objVmax.AbrirPuerto(puerto);

            System.Console.WriteLine("Si desea un numero de reporte especifico escribalo, de lo ");
            System.Console.WriteLine("contrario solo presione ENTER: ");
            numZ = (System.Console.ReadLine());

            if (numZ == "")
            {

                ret = objVmax.ObtenerReporteMf("");
                ret = objVmax.AbrirDNF();


                ret = objVmax.TextoNoFiscal("Numero del ultimo Z: " + objVmax.RetornoMF.uiUltNumZ);
                ret = objVmax.TextoNoFiscal("Fecha y hora del ultimo Z: " + objVmax.RetornoMF.sFechaHoraUltNumZ);
                ret = objVmax.TextoNoFiscal("Venta exenta: " + objVmax.RetornoMF.uiTotVenta_E);
                ret = objVmax.TextoNoFiscal("Venta impuesto G: " + objVmax.RetornoMF.uiTotVenta_G);
                ret = objVmax.TextoNoFiscal("Venta impuesto R: " + objVmax.RetornoMF.uiTotVenta_R);
                ret = objVmax.TextoNoFiscal("Venta impuesto A: " + objVmax.RetornoMF.uiTotVenta_A);
                ret = objVmax.TextoNoFiscal("Devolucion exenta " + objVmax.RetornoMF.uiTotDev_E);
                ret = objVmax.TextoNoFiscal("Devolucion impuesto G: " + objVmax.RetornoMF.uiTotDev_G);
                ret = objVmax.TextoNoFiscal("Devolucion impuesto R: " + objVmax.RetornoMF.uiTotDev_R);
                ret = objVmax.TextoNoFiscal("Devolucion impuesto A: " + objVmax.RetornoMF.uiTotDev_A);
                ret = objVmax.TextoNoFiscal("Descuento exenta: " + objVmax.RetornoMF.uiTotDes_E);
                ret = objVmax.TextoNoFiscal("Descuento impuesto G: " + objVmax.RetornoMF.uiTotDes_G);
                ret = objVmax.TextoNoFiscal("Descuento impuesto R: " + objVmax.RetornoMF.uiTotDes_R);
                ret = objVmax.TextoNoFiscal("Descuento impuesto A: " + objVmax.RetornoMF.uiTotDes_A);
                ret = objVmax.TextoNoFiscal("Alicuota G: " + objVmax.RetornoMF.uiAlicuota_G);
                ret = objVmax.TextoNoFiscal("Alicuota R: " + objVmax.RetornoMF.uiAlicuota_R);
                ret = objVmax.TextoNoFiscal("Alicuota A: " + objVmax.RetornoMF.uiAlicuota_A);
                ret = objVmax.TextoNoFiscal("Facturas emitidas: " + objVmax.RetornoMF.uiTotalFacturasEmitidas);
                ret = objVmax.TextoNoFiscal("Fecha y hora de la ultima factura: " + objVmax.RetornoMF.sFechaHoraUltFactura);
                ret = objVmax.TextoNoFiscal("Facturas diarias: " + objVmax.RetornoMF.uiTotalFacturasDiarias);
                ret = objVmax.TextoNoFiscal("Notas de credito diarias: " + objVmax.RetornoMF.uiTotalNCDiarias);
                ret = objVmax.TextoNoFiscal("Numero de decimales: " + objVmax.RetornoMF.uiNumDecimales);
                ret = objVmax.TextoNoFiscal("Abreviatura de moneda: " + objVmax.RetornoMF.sAbreviacionMoneda);
                ret = objVmax.TextoNoFiscal("Serial de la impresora fiscal: " + objVmax.RetornoMF.sSerial);
                ret = objVmax.TextoNoFiscal("Fecha y hora actual " + objVmax.RetornoMF.sFechaHoraActual);
                ret = objVmax.TextoNoFiscal("Monto Percibido en facturas " + objVmax.RetornoMF.uiTotPercibidoFc);
                ret = objVmax.TextoNoFiscal("Monto Percibido en Notas de credito " + objVmax.RetornoMF.uiTotPercibidoNc);
                ret = objVmax.TextoNoFiscal("Monto Pagado en Dolares: " + objVmax.RetornoMF.uiPagoDivisas);

                ret = objVmax.CerrarDNF();

            }
            else
            {
                ret = objVmax.ObtenerReporteMf("77" +
                    "");
                ret = objVmax.AbrirDNF();


                ret = objVmax.TextoNoFiscal("Numero del ultimo Z: " + objVmax.RetornoMF.uiUltNumZ);
                ret = objVmax.TextoNoFiscal("Fecha y hora del ultimo Z: " + objVmax.RetornoMF.sFechaHoraUltNumZ);
                ret = objVmax.TextoNoFiscal("Venta exenta: " + objVmax.RetornoMF.uiTotVenta_E);
                ret = objVmax.TextoNoFiscal("Venta impuesto G: " + objVmax.RetornoMF.uiTotVenta_G);
                ret = objVmax.TextoNoFiscal("Venta impuesto R: " + objVmax.RetornoMF.uiTotVenta_R);
                ret = objVmax.TextoNoFiscal("Venta impuesto A: " + objVmax.RetornoMF.uiTotVenta_A);
                ret = objVmax.TextoNoFiscal("Devolucion exenta " + objVmax.RetornoMF.uiTotDev_E);
                ret = objVmax.TextoNoFiscal("Devolucion impuesto G: " + objVmax.RetornoMF.uiTotDev_G);
                ret = objVmax.TextoNoFiscal("Devolucion impuesto R: " + objVmax.RetornoMF.uiTotDev_R);
                ret = objVmax.TextoNoFiscal("Devolucion impuesto A: " + objVmax.RetornoMF.uiTotDev_A);
                ret = objVmax.TextoNoFiscal("Descuento exenta: " + objVmax.RetornoMF.uiTotDes_E);
                ret = objVmax.TextoNoFiscal("Descuento impuesto G: " + objVmax.RetornoMF.uiTotDes_G);
                ret = objVmax.TextoNoFiscal("Descuento impuesto R: " + objVmax.RetornoMF.uiTotDes_R);
                ret = objVmax.TextoNoFiscal("Descuento impuesto A: " + objVmax.RetornoMF.uiTotDes_A);
                ret = objVmax.TextoNoFiscal("Alicuota G: " + objVmax.RetornoMF.uiAlicuota_G);
                ret = objVmax.TextoNoFiscal("Alicuota R: " + objVmax.RetornoMF.uiAlicuota_R);
                ret = objVmax.TextoNoFiscal("Alicuota A: " + objVmax.RetornoMF.uiAlicuota_A);
                ret = objVmax.TextoNoFiscal("Facturas emitidas: " + objVmax.RetornoMF.uiTotalFacturasEmitidas);
                ret = objVmax.TextoNoFiscal("Fecha y hora de la ultima factura: " + objVmax.RetornoMF.sFechaHoraUltFactura);
                ret = objVmax.TextoNoFiscal("Facturas diarias: " + objVmax.RetornoMF.uiTotalFacturasDiarias);
                ret = objVmax.TextoNoFiscal("Notas de credito diarias: " + objVmax.RetornoMF.uiTotalNCDiarias);
                ret = objVmax.TextoNoFiscal("Numero de decimales: " + objVmax.RetornoMF.uiNumDecimales);
                ret = objVmax.TextoNoFiscal("Abreviatura de moneda: " + objVmax.RetornoMF.sAbreviacionMoneda);
                ret = objVmax.TextoNoFiscal("Serial de la impresora fiscal: " + objVmax.RetornoMF.sSerial);
                ret = objVmax.TextoNoFiscal("Fecha y hora actual " + objVmax.RetornoMF.sFechaHoraActual);
                ret = objVmax.TextoNoFiscal("Monto Percibido en facturas " + objVmax.RetornoMF.uiTotPercibidoFc);
                ret = objVmax.TextoNoFiscal("Monto Percibido en Notas de credito " + objVmax.RetornoMF.uiTotPercibidoNc);
                ret = objVmax.TextoNoFiscal("Monto Pagado en Dolares: " + objVmax.RetornoMF.uiPagoDivisas);
                ret = objVmax.CerrarDNF();
                ret = objVmax.CerrarPuerto();
            }
        }
        public static void reporteContadores(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;

            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.ObtenerContadores();
            ret = objVmax.AbrirDNF();
            ret = objVmax.TextoNoFiscal("Ultima factura Abierta: " + objVmax.RetornoContadores.uiUltFacturaAbierta);
            ret = objVmax.TextoNoFiscal("Ultima factura Anulada: " + objVmax.RetornoContadores.uiUltFacturaAnulada);
            ret = objVmax.TextoNoFiscal("Ultima Nota de credito Abierta: " + objVmax.RetornoContadores.uiUltNCAbierta);
            ret = objVmax.TextoNoFiscal("Ultima Nota de credito Anulada: " + objVmax.RetornoContadores.uiUltNCAnulada);
            ret = objVmax.CerrarDNF();
            ret = objVmax.CerrarPuerto();
        }
        public static void ReportesMemoria(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            int respuesta;

            System.Console.WriteLine("Indique el reporte de memoria que desea obtener: ");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine("1. Reporte Memoria Fiscal por Fecha");
            System.Console.WriteLine("2. Reporte de Memoria Fiscal por Reporte Z");
            respuesta = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("");

            switch (respuesta)
            {

                case 1:
                    MfFecha(puerto);
                    Console.Clear();
                    break;

                case 2:
                    MfReporteZ(puerto);
                    Console.Clear();
                    break;
            }
        }
        public static void MfFecha(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();
            uint ret = 0;
            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.ReporteMfFecha("01022022", "12022022");
            ret = objVmax.CerrarPuerto();
        }
        public static void MfReporteZ(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();
            uint ret = 0;
            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.ReporteMfNumZ("00000001", "00000001");
            ret = objVmax.CerrarPuerto();
        }
        public static void CopiaDocumentos(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;
            string resp;

            System.Console.WriteLine("Indique el numero de factura a obtener: ");
            System.Console.WriteLine("");
            resp = (System.Console.ReadLine());
            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.ReimprimirDocumento("0", resp);

            System.Console.WriteLine("Indique el numero de nota de credito a obtener: ");
            System.Console.WriteLine("");
            resp = (System.Console.ReadLine());
            ret = objVmax.ReimprimirDocumento("1", resp);

            System.Console.WriteLine("Indique el numero de reporte Z a obtener: ");
            System.Console.WriteLine("");
            resp = (System.Console.ReadLine());
            ret = objVmax.ReimprimirDocumento("2", resp);

            System.Console.WriteLine("Indique el numero del documento no fiscal a obtener: ");
            System.Console.WriteLine("");
            resp = (System.Console.ReadLine());
            ret = objVmax.ReimprimirDocumento("3", resp);

        }
        public static void InformacionDispositivo(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;

            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.ObtenerInfoVcom();
            ret = objVmax.AbrirDNF();
            ret = objVmax.TextoNoFiscal("Modelo del modulo: " + objVmax.RetornoObtenerInfoVcom.sModelo);
            ret = objVmax.TextoNoFiscal("");
            ret = objVmax.TextoNoFiscal("Version: " + objVmax.RetornoObtenerInfoVcom.sVersion);
            ret = objVmax.TextoNoFiscal("");
            ret = objVmax.TextoNoFiscal("Numero de serie: " + objVmax.RetornoObtenerInfoVcom.sTerminalId);
            ret = objVmax.TextoNoFiscal("");
            ret = objVmax.TextoNoFiscal("Direccion MAC: " + objVmax.RetornoObtenerInfoVcom.sMacAddr);
            ret = objVmax.TextoNoFiscal("");
            ret = objVmax.CerrarDNF();
            ret = objVmax.CerrarPuerto();

        }
        public static void InformacionRed(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;

            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.ObtenerInfoRed();
            ret = objVmax.AbrirDNF();
            ret = objVmax.TextoNoFiscal("Direccón IP: " + objVmax.RetornoObtenerInfoRed.sIpAddress);
            ret = objVmax.TextoNoFiscal("");
            ret = objVmax.TextoNoFiscal("Nombre de la Red: " + objVmax.RetornoObtenerInfoRed.sSsid);
            ret = objVmax.TextoNoFiscal("");
            ret = objVmax.TextoNoFiscal("Intensidad de la senal: " + objVmax.RetornoObtenerInfoRed.sSignalQty);
            ret = objVmax.TextoNoFiscal("");
            ret = objVmax.CerrarDNF();
            ret = objVmax.CerrarPuerto();

        }
        public static void EstableceRedWifi(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;

            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.EstablecerRedInalambrica("EPS_T", "elepos03#vmax");
            if (ret == 0)
            {
                System.Console.WriteLine("Red wifi configurada de forma exitosa");
                Thread.Sleep(5000);
            }
            else
            {
                System.Console.WriteLine("No ha sido configurada la red Wifi");
                Thread.Sleep(5000);
            }
            ret = objVmax.CerrarPuerto();
        }

        public static void ObtenerEstadoConexion(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();

            uint ret = 0;
            ret = objVmax.AbrirPuerto(puerto);
            ret = objVmax.ObtenerEstadoConexion();
            System.Console.WriteLine("El estado de conexión es el siguiente: " + objVmax.RetornoObtenerEstadoConexion.sEstado);
            Thread.Sleep(5000);
            ret = objVmax.CerrarPuerto();
        }
        public static void ActualizarFechayHora(string puerto)
        {
            VmaxComVe.VmaxComClass objVmax = new VmaxComVe.VmaxComClass();
            uint ret = 0;

            string fecha;
            string hora;

            ret = objVmax.AbrirPuerto(puerto);
            System.Console.WriteLine("Introduzca la fecha en el formato DDMMAAAA: ");
            fecha = (System.Console.ReadLine());
            System.Console.WriteLine("Introduzca la hora en el fomato HHMM: ");
            hora = (System.Console.ReadLine());
            ret = objVmax.ConfigurarFechaHora(fecha, hora);
            ret = objVmax.CerrarPuerto();
            System.Console.WriteLine("");
            System.Console.WriteLine("El comando se ejecuto satisfactoriamente");
            System.Console.WriteLine("");
            System.Console.WriteLine("En caso de no actualizar la fecha y hora debe imprimir un");
            System.Console.WriteLine("reporte Z e intentarlo nuevamente");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
        }
    }
}

using ClosedXML.Excel;
using Web_Centi_Payments_Reports.Components.Entities;
using System.IO;
using System.Collections.Generic;

namespace Web_Centi_Payments_Reports.Components.XLS
{
    public class ClienteXLS
    {
        public byte[] Edition(List<ClienteInfo> data)
        {
            var wb = new XLWorkbook();
            wb.Properties.Author = "the Author";
            wb.Properties.Title = "the Title";
            wb.Properties.Subject = "the Subject";
            wb.Properties.Category = "the Category";
            wb.Properties.Keywords = "the Keywords";
            wb.Properties.Comments = "the Comments";
            wb.Properties.Status = "the Status";
            wb.Properties.LastModifiedBy = "the Last Modified By";
            wb.Properties.Company = "the Company";
            wb.Properties.Manager = "the Manager";

            var ws = wb.Worksheets.Add("Clientes");

            ws.Cell(1, 1).Value = "ID OPERACION";
            ws.Cell(1, 2).Value = "CIC";
            ws.Cell(1, 3).Value = "NRO. CUENTA REPEXT";
            ws.Cell(1, 4).Value = "MONEDA";
            ws.Cell(1, 5).Value = "MONTO";
            ws.Cell(1, 6).Value = "MONTO PROCESADO";
            ws.Cell(1, 7).Value = "MONTO RESTANTE";
            ws.Cell(1, 8).Value = "PENDIENTE";
            ws.Cell(1, 9).Value = "GLOSA";
            ws.Cell(1, 10).Value = "NRO. CREDITO";
            ws.Cell(1, 11).Value = "FECHA DE PAGO";
            ws.Cell(1, 12).Value = "APLICATIVO";
            ws.Cell(1, 13).Value = "ESTADO OPERACION";
            ws.Cell(1, 14).Value = "CODIGO SITUACION";
            ws.Cell(1, 15).Value = "DIAS MORA";

            for (int row = 0; row < data.Count; row++)
            {
                ws.Cell(row + 2, 1).Value =  data[row]._IdOperacion;
                ws.Cell(row + 2, 2).Value =  data[row]._Cic;
                ws.Cell(row + 2, 3).Value =  data[row]._NroCredito;
                ws.Cell(row + 2, 4).Value =  data[row]._Moneda;
                ws.Cell(row + 2, 5).Value =  data[row]._Monto;
                ws.Cell(row + 2, 6).Value =  data[row]._MontoProcesado;
                ws.Cell(row + 2, 7).Value =  data[row]._MontoRestante;
                ws.Cell(row + 2, 8).Value =  data[row]._Pendiente;
                ws.Cell(row + 2, 9).Value =  data[row]._Glosa;
                ws.Cell(row + 2, 10).Value = data[row]._CuentaRepext;
                ws.Cell(row + 2, 11).Value = data[row]._FechaReg;
                ws.Cell(row + 2, 12).Value = data[row]._TipoOperacion;
                ws.Cell(row + 2, 13).Value = data[row]._EstadoOperacion;
                ws.Cell(row + 2, 14).Value = data[row]._CodigoSituacion;
                ws.Cell(row + 2, 15).Value = data[row]._DiasMora;
            }

            using var XLSStream = new MemoryStream();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        }
    }
}

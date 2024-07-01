using DinkToPdf.Contracts;
using DinkToPdf;
using System.IO;
using Web_Centi_Payments_Reports.Components.Entities;

namespace Web_Centi_Payments_Reports.Components.Services
{
    public interface IPdfService
    {
        byte[] GeneratePdf(string htmlContent);
        Task<Stream> GenerarReporte(List<ClienteInfo> clientes);
    }

    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }
        public async Task<Stream> GenerarReporte(List<ClienteInfo> clientes)
        {
            // Aquí puedes usar una biblioteca como iTextSharp o PdfSharp para generar el PDF
            // Este es solo un ejemplo básico

            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.WriteLine("Reporte de Clientes");
            writer.WriteLine("-------------------");

            foreach (var cliente in clientes)
            {
                writer.WriteLine($"CIC: {cliente._IdOperacion}");
                writer.WriteLine($"NRO. CUENTA_ALS: {cliente._Cic}");
                writer.WriteLine($"SALDO: {cliente._NroCredito}");
                writer.WriteLine($"NRO. CUENTA_DEBITO: {cliente._Moneda}");
                writer.WriteLine($"SUCURSAL: {cliente._Monto}");
                writer.WriteLine($"MONEDA: {cliente._MontoProcesado}");
                writer.WriteLine($"TIPO PRODUCTO: {cliente._MontoRestante}");
                writer.WriteLine($"SITUACION: {cliente._Pendiente}");
                writer.WriteLine($"NOMBRE SITUACION: {cliente._Glosa}");
                writer.WriteLine($"MONTO DEL DEBITO: {cliente._CuentaRepext}");
                writer.WriteLine($"FECHA: {cliente._FechaReg}");
                writer.WriteLine($"ID_CUENTA: {cliente._TipoOperacion}");
                writer.WriteLine($"MONTO: {cliente._EstadoOperacion}");
                writer.WriteLine($"GLOSA: {cliente._CodigoSituacion}");
                writer.WriteLine($"ID_OPERAION: {cliente._DiasMora}");
                writer.WriteLine();
            }

            writer.Flush();
            memoryStream.Position = 0;

            return memoryStream;
        }
        public byte[] GeneratePdf(string htmlContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait
            },
                Objects = {
                new ObjectSettings() {
                    HtmlContent = htmlContent
                }
            }
            };
            return _converter.Convert(doc);
        }
    }
}
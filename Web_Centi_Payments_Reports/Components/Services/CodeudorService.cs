using Web_Centi_Payments_Reports.Components.Entities;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace Web_Centi_Payments_Reports.Components.Services
{
    public class CodeudorService : ICodeudorService
    {
        private readonly HttpClient _http;

        public CodeudorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CodeudorInfo>> Lista()
        {
            try
            {
                var response = await _http.GetAsync("/api/v1/CentinelaCobroEnLinea/ReporteCentinelaCodeudor");
                //var result = await _http.GetFromJsonAsync<List<CodeudorInfo>>("/api/v1/CentinelaCobroEnLinea/ReporteCentinelaCodeudor");

                var jsonString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    try
                    {
                        var result = JsonSerializer.Deserialize<List<CodeudorInfo>>(jsonString, options);

                        return result;
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine($"Error de deserialización JSON: {jsonEx.Message}");
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine($"Error HTTP: {response.StatusCode}");
                    throw new HttpRequestException($"Error HTTP: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al obtener los datos de la API: {ex.Message}");
                throw;
            }

        }

        public async Task<List<CodeudorInfo>> Listas()
        {
            var sampleData = new List<CodeudorInfo>
            {
                new CodeudorInfo
                {
                    CIC = "123",
                    CUENTA_ALS = "456",
                    SALDO = 1000.0m,
                    CUENTA_DEBITO = "789",
                    MONEDA = "BOB",
                    MONTO = 1000.0m,
                    GLOSA = "Glosa1",
                    FECHA_REGISTRO = new DateTime(2022, 1, 1),
                    COD_EXTORNO = "Ext1",
                    ID_OPERACION = "Op1",
                    APLICATIVO = "App1",
                    NOMBRE = "Name1",
                    idc_codeudor = "ID123"
                },
                new CodeudorInfo
                {
                    CIC = "456",
                    CUENTA_ALS = "789",
                    SALDO = 1500.0m,
                    CUENTA_DEBITO = "101",
                    MONEDA = "USD",
                    MONTO = 1500.0m,
                    GLOSA = "Glosa2",
                    FECHA_REGISTRO = new DateTime(2022, 2, 1),
                    COD_EXTORNO = "Ext2",
                    ID_OPERACION = "Op2",
                    APLICATIVO = "App2",
                    NOMBRE = "Name2",
                    idc_codeudor = "ID456"
                }
            };
            await Task.Delay(100);

            return sampleData;
        }

        public async Task<List<CodeudorInfo>> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync <List<CodeudorInfo>>($"api/Cliente/Buscar/{id}");
            return result;
        }

    }
}

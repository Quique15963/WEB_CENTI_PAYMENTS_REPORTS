using Web_Centi_Payments_Reports.Components.Entities;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace Web_Centi_Payments_Reports.Components.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _http;

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ClienteInfo>> Lista()
        {
            try
            {
                var response = await _http.GetAsync("/api/v1/CentinelaCobroEnLinea/ReporteCentinela");
                var jsonString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    try
                    {
                        var result = JsonSerializer.Deserialize<List<ClienteInfo>>(jsonString, options);
                        
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
        public async Task<int> Count()
        {
            try
            {
                var response = await _http.GetAsync("/api/v1/CentinelaCobroEnLinea/ReporteCentinela");
                var jsonString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    try
                    {
                        var result = JsonSerializer.Deserialize<List<ClienteInfo>>(jsonString, options);
                        return result?.Count ?? 0;
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
        public async Task<List<ClienteInfo>> GetPage(int pageNumber, int pageSize)
        {
            try
            {
                var response = await _http.GetAsync("/api/v1/CentinelaCobroEnLinea/ReporteCentinela");
                var jsonString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    var result = JsonSerializer.Deserialize<List<ClienteInfo>>(jsonString, options);

                    var startIndex = (pageNumber - 1) * pageSize;
                    var endIndex = Math.Min(startIndex + pageSize, result.Count);
                    return result.GetRange(startIndex, endIndex - startIndex);
                }
                else
                {
                    Console.WriteLine($"Error HTTP: {response.StatusCode}");
                    throw new HttpRequestException($"Error HTTP: {response.StatusCode}");
                }
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Error de deserialización JSON: {jsonEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al obtener los datos de la API: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ClienteInfo>> Buscar(DateTime fechaHoy)
        {
            var result = await _http.GetFromJsonAsync <List<ClienteInfo>>($"/api/v1/CentinelaCobroEnLinea/ReporteCentinela/Buscar/{fechaHoy}");
            return result;
        }

    }
}

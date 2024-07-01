using Web_Centi_Payments_Reports.Components.Entities;

namespace Web_Centi_Payments_Reports.Components.Services
{
    public interface IClienteService
    {
        Task<List<ClienteInfo>> Lista();
        Task<int> Count();
        Task<List<ClienteInfo>> GetPage(int pageNumber, int pageSize);
        Task<List<ClienteInfo>> Buscar(DateTime fechaHoy);

    }
}
using Web_Centi_Payments_Reports.Components.Entities;

namespace Web_Centi_Payments_Reports.Components.Services
{
    public interface ICodeudorService
    {
        Task<List<CodeudorInfo>> Lista();
        Task<List<CodeudorInfo>> Listas();
        Task<List<CodeudorInfo>> Buscar(int id);
    }
}

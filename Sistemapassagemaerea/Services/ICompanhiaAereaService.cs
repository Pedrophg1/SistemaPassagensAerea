using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Services
{
    public interface ICompanhiaAereaService
    {
        Task<IEnumerable<Companhia_Aerea>> GetAllCompanhiasAsync();
        Task<Companhia_Aerea> GetCompanhiaByCodigoAsync(string codigo);
        Task AddCompanhiaAsync(Companhia_Aerea companhia);
        Task UpdateCompanhiaAsync(Companhia_Aerea companhia);
        Task DeleteCompanhiaAsync(string codigo);
    }

}

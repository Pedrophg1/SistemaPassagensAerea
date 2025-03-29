using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Services
{
    public interface IPassagemAereaService
    {
        Task<IEnumerable<PassagemAerea>> GetAllPassagensAsync();
        Task AddPassagemAereaAsync(PassagemAerea passagemAerea);
        Task DeletePassagemAereaAsync(string cpfPassageiro, string codigoCompanhiaAerea);
    }

}

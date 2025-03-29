using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Repositories
{
    public interface IPassagemAereaRepository
    {
        Task<IEnumerable<PassagemAerea>> GetAllPassagensAsync();
        Task AddPassagemAereaAsync(PassagemAerea passagemAerea);
        Task DeletePassagemAereaAsync(string cpfPassageiro, string codigoCompanhiaAerea);
    }

}

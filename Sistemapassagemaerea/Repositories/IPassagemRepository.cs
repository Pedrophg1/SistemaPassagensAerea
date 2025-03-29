using Sistemapassagemaerea.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Repositories
{
    public interface IPassagemRepository
    {
        Task<IEnumerable<PassagemAerea>> GetAllPassagensAsync();
        Task<PassagemAerea> GetPassagemByIdAsync(string cpfPassageiro, string codigoCompanhiaAerea);
        Task AddPassagemAsync(PassagemAerea passagemAerea);
        Task UpdatePassagemAsync(PassagemAerea passagemAerea);
        Task DeletePassagemAsync(string cpfPassageiro, string codigoCompanhiaAerea);
    }
}

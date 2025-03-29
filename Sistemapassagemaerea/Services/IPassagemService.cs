using System.Collections.Generic;
using System.Threading.Tasks;
using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Services
{
    public interface IPassagemService
    {
        Task<IEnumerable<PassagemAerea>> GetAllPassagensAsync();
        Task<PassagemAerea> GetPassagemByIdAsync(string cpfPassageiro, string codigoCompanhiaAerea);
        Task AddPassagemAsync(PassagemAerea passagemAerea);
        Task UpdatePassagemAsync(PassagemAerea passagemAerea);
        Task DeletePassagemAsync(string cpfPassageiro, string codigoCompanhiaAerea);
    }
}

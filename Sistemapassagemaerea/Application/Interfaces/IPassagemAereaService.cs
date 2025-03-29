using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Application.Interfaces
{
    public interface IPassagemAereaService
    {
        Task<IEnumerable<PassagemAerea>> GetAllPassagensAsync();
        Task AddPassagemAereaAsync(PassagemAerea passagemAerea);
        Task DeletePassagemAereaAsync(string cpfPassageiro, string codigoCompanhiaAerea);
    }

}

using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Services
{
    public interface IClienteService
    {
        Task<Cliente> GetClienteByCpfAsync(string cpf);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(string cpf);
        Task<IEnumerable<Cliente>> GetAllClientesAsync();


    }

}

using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteByCpfAsync(string cpf);
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(string cpf);
       
    }
}

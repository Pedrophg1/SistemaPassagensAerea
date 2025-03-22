using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Repositories;

namespace Sistemapassagemaerea.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> GetClienteByCpfAsync(string cpf)
        {
            var cliente = await _clienteRepository.GetClienteByCpfAsync(cpf);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado.");
            }
            return cliente;
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            // Exemplo de validação antes de adicionar um cliente
            if (await _clienteRepository.GetClienteByCpfAsync(cliente.CpfCliente) != null)
            {
                throw new InvalidOperationException("Cliente já cadastrado.");
            }

            await _clienteRepository.AddClienteAsync(cliente);
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            var clientes = await _clienteRepository.GetAllClientesAsync();
            return clientes;
        }


        public async Task UpdateClienteAsync(Cliente cliente)
        {
            // Validação de regras de negócio, por exemplo, CPF não pode ser nulo
            if (string.IsNullOrEmpty(cliente.CpfCliente))
            {
                throw new ArgumentException("CPF do cliente não pode ser vazio.");
            }

            await _clienteRepository.UpdateClienteAsync(cliente);
        }
       

        public async Task DeleteClienteAsync(string cpf)
        {
            // Validações antes de excluir, como verificar se o cliente realmente existe
            var cliente = await _clienteRepository.GetClienteByCpfAsync(cpf);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado para exclusão.");
            }

            await _clienteRepository.DeleteClienteAsync(cpf);
        }

       
    }

}

using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> GetClienteByCpfAsync(string cpf)
        {
            return await _context.Clientes
                                 .FirstOrDefaultAsync(c => c.CpfCliente == cpf);
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(string cpf)
        {
            var cliente = await _context.Clientes.FindAsync(cpf);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        
    }
}

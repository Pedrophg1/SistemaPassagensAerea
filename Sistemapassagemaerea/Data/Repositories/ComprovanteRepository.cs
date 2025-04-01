using Sistemapassagemaerea.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Data
{
    public class ComprovanteRepository
    {
        private readonly ApplicationDbContext _context;

        public ComprovanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddComprovanteAsync(Comprovante comprovante)
        {
            await _context.Comprovantes.AddAsync(comprovante);
            await _context.SaveChangesAsync();
        }
    }
}
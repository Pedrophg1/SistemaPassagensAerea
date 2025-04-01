using System.Net.Sockets;
using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Data.Repositories
{
    public class ComprovanteRepository
    {
        private readonly ApplicationDbContext _context;

        public ComprovanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}

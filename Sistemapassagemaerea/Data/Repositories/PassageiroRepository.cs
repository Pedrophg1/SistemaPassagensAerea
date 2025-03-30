using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Domain;
using Sistemapassagemaerea.Domain.Interfaces;

namespace Sistemapassagemaerea.Data.Repositories
{
    public class PassageiroRepository(ApplicationDbContext context) : IPassageiroRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Passageiro>> GetAllAsync()
        {
            return await _context.Passageiros.Include(x => x.PassagensAereas)
                .ToListAsync();
        }

        public async Task<Passageiro?> GetByIdAsync(int id)
        {
            return await _context.Passageiros.Include(x => x.PassagensAereas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Passageiro passageiro)
        {
            await _context.Passageiros.AddAsync(passageiro);
        }

        public void Update(Passageiro passageiro)
        {
            _context.Passageiros.Update(passageiro);
        }

        public void Delete(Passageiro passageiro)
        {
            _context.Passageiros.Remove(passageiro);
        }
       

    }

}

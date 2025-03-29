using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Repositories
{
    public class PassageiroRepository : IPassageiroRepository
    {
        private readonly ApplicationDbContext _context;

        public PassageiroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Passageiro>> GetAllPassageirosAsync()
        {
            return await _context.Passageiros.ToListAsync();
        }

        public async Task<Passageiro> GetPassageiroByCpfAsync(string cpf)
        {
            return await _context.Passageiros.FirstOrDefaultAsync(p => p.CpfPassageiro == cpf);
        }

        public async Task AddPassageiroAsync(Passageiro passageiro)
        {
            await _context.Passageiros.AddAsync(passageiro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassageiroAsync(Passageiro passageiro)
        {
            _context.Passageiros.Update(passageiro);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePassageiroAsync(string cpf)
        {
            var passageiro = await GetPassageiroByCpfAsync(cpf);
            if (passageiro != null)
            {
                _context.Passageiros.Remove(passageiro);
                await _context.SaveChangesAsync();
            }
        }
    }

}

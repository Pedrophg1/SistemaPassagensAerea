using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Models;

namespace Sistemapassagemaerea.Repositories
{
    public class PassagemAereaRepository : IPassagemAereaRepository
    {
        private readonly ApplicationDbContext _context;

        public PassagemAereaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PassagemAerea>> GetAllPassagensAsync()
        {
            return await _context.PassagensAereas
                                 .Include(pa => pa.Passageiro)
                                 .Include(pa => pa.CompanhiaAerea)
                                 .ToListAsync();
        }

        public async Task AddPassagemAereaAsync(PassagemAerea passagemAerea)
        {
            await _context.PassagensAereas.AddAsync(passagemAerea);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePassagemAereaAsync(string cpfPassageiro, string codigoCompanhiaAerea)
        {
            var passagemAerea = await _context.PassagensAereas
                .FirstOrDefaultAsync(pa => pa.CpfPassageiro == cpfPassageiro && pa.CodIATA == codigoCompanhiaAerea);

            if (passagemAerea != null)
            {
                _context.PassagensAereas.Remove(passagemAerea);
                await _context.SaveChangesAsync();
            }
        }
    }

}

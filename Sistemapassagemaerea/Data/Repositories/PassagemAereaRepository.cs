using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Domain;
using Sistemapassagemaerea.Domain.Interfaces;

namespace Sistemapassagemaerea.Data.Repositories
{
    public class PassagemAereaRepository : IPassagemAereaRepository
    {
        private readonly ApplicationDbContext _context;

        public PassagemAereaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PassagemAerea>> GetAllAsync()
        {
            return await _context.PassagensAereas
                                 .Include(pa => pa.Passageiro)
                                 .Include(pa => pa.CompanhiaAerea)
                                 .ToListAsync();
        }

        public async Task<PassagemAerea?> GetByIdAsync(int id)
        {
            return await _context.PassagensAereas
                                 .Include(pa => pa.Passageiro)
                                 .Include(pa => pa.CompanhiaAerea)
                                 .FirstOrDefaultAsync(pa => pa.Id == id);
        }

        public async Task AddAsync(PassagemAerea passagemAerea)
        {
            await _context.PassagensAereas.AddAsync(passagemAerea);
           
        }
        public void Update(PassagemAerea passagemAerea)
        {
            _context.PassagensAereas.Update(passagemAerea);
        }

        //public async Task Delete(int id)
        //{
        //    var passagemAerea = await _context.PassagensAereas
        //        .FirstOrDefaultAsync(pa => pa.Id == id);

        //    if (passagemAerea != null)
        //    {
        //        _context.PassagensAereas.Remove(passagemAerea);
               
        //    }
        //}
        public void Delete(PassagemAerea passagemAerea)
        {
            _context.PassagensAereas.Remove(passagemAerea);
        }

    }
}

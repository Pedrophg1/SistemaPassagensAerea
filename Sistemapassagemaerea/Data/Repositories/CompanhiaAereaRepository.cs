using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Domain;
using Sistemapassagemaerea.Domain.Interfaces;

public class CompanhiaAereaRepository(ApplicationDbContext context) : ICompanhiaAereaRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<CompanhiaAerea>> GetAllAsync()
    {
        return await _context.CompanhiasAereas
            .Include(x => x.PassagensAereas)
            .ToArrayAsync();
    }

    public async Task<CompanhiaAerea?> GetByIdAsync(int id)
    {
        return await _context.CompanhiasAereas.Include(x => x.PassagensAereas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(CompanhiaAerea companhia)
    {
        await _context.CompanhiasAereas.AddAsync(companhia);
    }

    public void Update(CompanhiaAerea companhia)
    {
        _context.CompanhiasAereas.Update(companhia);
    }

    public void Delete(CompanhiaAerea companhia)
    {
        _context.CompanhiasAereas.Remove(companhia);
    }
}

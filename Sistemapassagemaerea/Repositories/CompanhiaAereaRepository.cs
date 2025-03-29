using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Repositories;

public class CompanhiaAereaRepository : ICompanhiaAereaRepository
{
    private readonly ApplicationDbContext _context;

    public CompanhiaAereaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Companhia_Aerea>> GetAllCompanhiasAsync()
    {
        return await _context.Companhia_Aereas.ToListAsync();
    }

    public async Task<Companhia_Aerea> GetCompanhiaByCodigoAsync(string codigo)
    {
        return await _context.Companhia_Aereas.FirstOrDefaultAsync(c => c.CodIATA == codigo);
    }

    public async Task AddCompanhiaAsync(Companhia_Aerea companhia)
    {
        await _context.Companhia_Aereas.AddAsync(companhia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCompanhiaAsync(Companhia_Aerea companhia)
    {
        _context.Companhia_Aereas.Update(companhia);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCompanhiaAsync(string codigo)
    {
        var companhia = await GetCompanhiaByCodigoAsync(codigo);
        if (companhia != null)
        {
            _context.Companhia_Aereas.Remove(companhia);
            await _context.SaveChangesAsync();
        }
    }
}

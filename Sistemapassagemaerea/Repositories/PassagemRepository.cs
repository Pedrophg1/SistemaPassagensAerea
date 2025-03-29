using Microsoft.EntityFrameworkCore;

using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Repositories;

public class PassagemRepository : IPassagemRepository
{
    private readonly ApplicationDbContext _context;

    public PassagemRepository(ApplicationDbContext context)
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

    public async Task<PassagemAerea> GetPassagemByIdAsync(string cpfPassageiro, string codigoCompanhiaAerea)
    {
        return await _context.PassagensAereas
                             .Include(pa => pa.Passageiro)
                             .Include(pa => pa.CompanhiaAerea)
                             .FirstOrDefaultAsync(pa => pa.CpfPassageiro == cpfPassageiro && pa.CodigoCompanhiaAerea == codigoCompanhiaAerea);
    }

    public async Task AddPassagemAsync(PassagemAerea passagemAerea)
    {
        await _context.PassagensAereas.AddAsync(passagemAerea);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePassagemAsync(PassagemAerea passagemAerea)
    {
        _context.PassagensAereas.Update(passagemAerea);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePassagemAsync(string cpfPassageiro, string codigoCompanhiaAerea)
    {
        var passagemAerea = await GetPassagemByIdAsync(cpfPassageiro, codigoCompanhiaAerea);
        if (passagemAerea != null)
        {
            _context.PassagensAereas.Remove(passagemAerea);
            await _context.SaveChangesAsync();
        }
    }
}

using Sistemapassagemaerea.Domain.Interfaces;

namespace Sistemapassagemaerea.Data;

public class UnityOfWork(ApplicationDbContext context) : IUnityOfWork
{
    private readonly ApplicationDbContext _context = context;
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public void Dispose() { }
}

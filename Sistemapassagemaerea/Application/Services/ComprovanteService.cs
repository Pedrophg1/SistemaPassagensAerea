using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Domain;

public class ComprovanteService
{
    private readonly ApplicationDbContext _context;

    public ComprovanteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> GerarComprovanteAsync(Passageiro passageiro, PassagemAerea passagem)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                // Adiciona o passageiro ao contexto
                _context.Passageiros.Add(passageiro);
                await _context.SaveChangesAsync();

                // Associa o passageiro à passagem aérea
                passagem.IdPassageiro = passageiro.Id;
                _context.PassagensAereas.Add(passagem);
                await _context.SaveChangesAsync();

                // Confirma a transação
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                // Reverte a transação em caso de erro
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
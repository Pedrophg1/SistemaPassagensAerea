using Sistemapassagemaerea.Data;
using Sistemapassagemaerea.Domain;
using Microsoft.EntityFrameworkCore;

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
                _context.Passageiros.Add(passageiro);
                await _context.SaveChangesAsync();

                
                _context.PassagensAereas.Add(passagem);
                await _context.SaveChangesAsync();

                var comprovante = new Comprovante
                {
                    CodigoPassagem = passagem.CodigoPassagem,
                    DataHoraCompra = passagem.DataHoraCompra,
                    ValorPassagem = passagem.ValorPassagem,
                    CpfPassageiro = passageiro.Cpf
                };

                _context.Comprovantes.Add(comprovante);
                await _context.SaveChangesAsync();


                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
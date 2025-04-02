using Sistemapassagemaerea.Domain;
using Sistemapassagemaerea.Data;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sistemapassagemaerea.Application.Services
{
    public class ComprovanteService
    {
        private readonly ApplicationDbContext _context;
        private readonly ComprovanteRepository _repository;

        public ComprovanteService(ApplicationDbContext context, ComprovanteRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<bool> GerarComprovanteAsync(Comprovante comprovante)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                bool passagemJaUtilizada = await _context.Comprovantes.AnyAsync(c => c.CodigoPassagem == comprovante.CodigoPassagem);
                if (passagemJaUtilizada)
                    throw new Exception("Esta passagem já foi utilizada para gerar um comprovante.");

                await _repository.AddComprovanteAsync(comprovante);
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
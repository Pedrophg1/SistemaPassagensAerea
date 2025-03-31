using Sistemapassagemaerea.Data.Mongodb.Entities;

namespace Sistemapassagemaerea.Domain.Interfaces
{
    public interface IPassagemAereaMongoRepository
    {
        Task<IEnumerable<PassagemAereaMongo>> GetAllAsync();
        Task<PassagemAereaMongo?> GetByIdAsync(int id);
        Task AddAsync(PassagemAereaMongo passagemAerea);
        Task UpdateAsync(PassagemAereaMongo passagemAerea);
        Task DeleteAsync(int id);
    }
}
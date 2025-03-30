using Sistemapassagemaerea.Data.Mongodb.Entities;

namespace Sistemapassagemaerea.Domain.Interfaces
{
    public interface ICompanhiaAereaMongoRepository
    {
        Task<IEnumerable<CompanhiaAereaMongo>> GetAllAsync();
        Task<CompanhiaAereaMongo?> GetByIdAsync(int id);
        Task AddAsync(CompanhiaAereaMongo companhia);
        Task UpdateAsync(CompanhiaAereaMongo companhia);
        Task DeleteAsync(int id);
    }
}

using Sistemapassagemaerea.Data.Mongodb.Entities;

namespace Sistemapassagemaerea.Domain.Interfaces
{
    public interface IPassageiroMongoRepository
    {
        Task<IEnumerable<PassageiroMongo>> GetAllAsync();
        Task<PassageiroMongo?> GetByIdAsync(int id);
        Task AddAsync(PassageiroMongo passageiro);
        Task UpdateAsync(PassageiroMongo passageiro);
        Task DeleteAsync(int id);
    }
}
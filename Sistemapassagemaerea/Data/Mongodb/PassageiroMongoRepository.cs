using MongoDB.Driver;
using Sistemapassagemaerea.Data.Mongodb.Entities;
using Sistemapassagemaerea.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Data.Mongodb.Repositories
{
    public class PassageiroMongoRepository : IPassageiroMongoRepository
    {
        private readonly IMongoCollection<PassageiroMongo> _passageiros;

        public PassageiroMongoRepository(MongoDbService mongoDbService)
        {
            _passageiros = mongoDbService.Passageiros;
        }

        public async Task<IEnumerable<PassageiroMongo>> GetAllAsync()
        {
            return await _passageiros.Find(passageiro => true).ToListAsync();
        }

        public async Task<PassageiroMongo?> GetByIdAsync(int id)
        {
            return await _passageiros.Find(passageiro => passageiro.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(PassageiroMongo passageiro)
        {
            await _passageiros.InsertOneAsync(passageiro);
        }

        public async Task UpdateAsync(PassageiroMongo passageiro)
        {
            await _passageiros.ReplaceOneAsync(p => p.Id == passageiro.Id, passageiro);
        }

        public async Task DeleteAsync(int id)
        {
            await _passageiros.DeleteOneAsync(p => p.Id == id);
        }
    }

}

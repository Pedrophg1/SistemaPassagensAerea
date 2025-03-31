using MongoDB.Driver;
using Sistemapassagemaerea.Data.Mongodb.Entities;
using Sistemapassagemaerea.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Data.Mongodb.Repositories
{
    public class CompanhiaAereaMongoRepository : ICompanhiaAereaMongoRepository
    {
        private readonly IMongoCollection<CompanhiaAereaMongo> _companhiasAereas;

        public CompanhiaAereaMongoRepository(MongoDbService mongoDbService)
        {
            _companhiasAereas = mongoDbService.CompanhiasAereas;
        }

        public async Task<IEnumerable<CompanhiaAereaMongo>> GetAllAsync()
        {
            return await _companhiasAereas.Find(companhia => true).ToListAsync();
        }

        public async Task<CompanhiaAereaMongo?> GetByIdAsync(int id)
        {
            return await _companhiasAereas.Find(companhia => companhia.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(CompanhiaAereaMongo companhia)
        {
            await _companhiasAereas.InsertOneAsync(companhia);
        }

        public async Task UpdateAsync(CompanhiaAereaMongo companhia)
        {
            await _companhiasAereas.ReplaceOneAsync(c => c.Id == companhia.Id, companhia);
        }

        public async Task DeleteAsync(int id)
        {
            await _companhiasAereas.DeleteOneAsync(c => c.Id == id);
        }
    }

}
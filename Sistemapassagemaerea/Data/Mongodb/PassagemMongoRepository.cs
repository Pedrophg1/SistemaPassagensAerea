using MongoDB.Driver;
using Sistemapassagemaerea.Data.Mongodb.Entities;
using Sistemapassagemaerea.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Data.Mongodb.Repositories
{
    public class PassagemAereaMongoRepository : IPassagemAereaMongoRepository
    {
        private readonly IMongoCollection<PassagemAereaMongo> _passagensAereas;

        public PassagemAereaMongoRepository(MongoDbService mongoDbService)
        {
            _passagensAereas = mongoDbService.PassagensAereas;
        }

        public async Task<IEnumerable<PassagemAereaMongo>> GetAllAsync()
        {
            return await _passagensAereas.Find(passagem => true).ToListAsync();
        }

        public async Task<PassagemAereaMongo?> GetByIdAsync(int id)
        {
            return await _passagensAereas.Find(passagem => passagem.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(PassagemAereaMongo passagemAerea)
        {
            await _passagensAereas.InsertOneAsync(passagemAerea);
        }

        public async Task UpdateAsync(PassagemAereaMongo passagemAerea)
        {
            await _passagensAereas.ReplaceOneAsync(p => p.Id == passagemAerea.Id, passagemAerea);
        }

        public async Task DeleteAsync(int id)
        {
            await _passagensAereas.DeleteOneAsync(p => p.Id == id);
        }
    }

}
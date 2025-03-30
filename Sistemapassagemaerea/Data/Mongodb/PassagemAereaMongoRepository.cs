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
        private readonly IMongoCollection<PassageiroMongo> _passageiros;
        private readonly IMongoCollection<CompanhiaAereaMongo> _companhiasAereas;

        public PassagemAereaMongoRepository(MongoDbService mongoDbService)
        {
            _passagensAereas = mongoDbService.PassagensAereas;
            _passageiros = mongoDbService.Passageiros;
            _companhiasAereas = mongoDbService.CompanhiasAereas;
        }

        // Método para obter todas as passagens, com as informações do passageiro e companhia aérea
        public async Task<IEnumerable<PassagemAereaMongo>> GetAllAsync()
        {
            return await _passagensAereas.Aggregate()
                .Lookup(
                    foreignCollection: _passageiros,
                    localField: p => p.IdPassageiro,
                    foreignField: p => p.Id,
                    @as: (PassagemAereaMongo p) => p.Passageiro)  // Associar Passageiro
                .Lookup(
                    foreignCollection: _companhiasAereas,
                    localField: p => p.IdCompanhiaAerea,
                    foreignField: c => c.Id,
                    @as: (PassagemAereaMongo p) => p.CompanhiaAerea)  // Associar Companhia Aérea
                .ToListAsync();
        }

        // Método para obter uma passagem pelo Id, com as informações do passageiro e companhia aérea
        public async Task<PassagemAereaMongo?> GetByIdAsync(int id)
        {
            return await _passagensAereas.Aggregate()
                .Match(p => p.Id == id)  // Filtra pelo Id da passagem
                .Lookup(
                    foreignCollection: _passageiros,
                    localField: p => p.IdPassageiro,
                    foreignField: p => p.Id,
                    @as: (PassagemAereaMongo p) => p.Passageiro)  // Carrega dados do Passageiro
                .Lookup(
                    foreignCollection: _companhiasAereas,
                    localField: p => p.IdCompanhiaAerea,
                    foreignField: c => c.Id,
                    @as: (PassagemAereaMongo p) => p.CompanhiaAerea)  // Carrega dados da Companhia Aérea
                .FirstOrDefaultAsync();
        }

        // Outros métodos (Adicionar, Atualizar, Deletar) podem ser similares...
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

using MongoDB.Bson;
using MongoDB.Driver;
using Sistemapassagemaerea.Data.Mongodb.Entities;

namespace Sistemapassagemaerea.Data.Mongodb
{
    public class PassagemMongoRepository : IPassagemMongoRepository
    {
        private readonly IMongoCollection<PassagemAereaMongo> _passagemCollection;
        private readonly IMongoCollection<PassageiroMongo> _passageiroCollection;
        private readonly IMongoCollection<CompanhiaAereaMongo> _companhiaAereaCollection;

        public PassagemMongoRepository(IMongoDatabase database)
        {
            _passagemCollection = database.GetCollection<PassagemAereaMongo>("PassagemAereas");
            _passageiroCollection = database.GetCollection<PassageiroMongo>("Passageiros");
            _companhiaAereaCollection = database.GetCollection<CompanhiaAereaMongo>("CompanhiasAereas");
        }


        public async Task<PassagemAereaMongo> ObterPassagemComDetalhesAsync(ObjectId passagemId)
        {
            var passagem = await _passagemCollection.Find(p => p.Id == passagemId).FirstOrDefaultAsync();
            if (passagem == null) return null;


            var passageiro = await _passageiroCollection.Find(p => p.Id == passagem.IdPassageiro).FirstOrDefaultAsync();
            var companhiaAerea = await _companhiaAereaCollection.Find(c => c.Id == passagem.IdCompanhiaAerea).FirstOrDefaultAsync();


            if (passageiro != null)
                passagem.Passageiro = passageiro;

            if (companhiaAerea != null)
                passagem.CompanhiaAerea = companhiaAerea;

            return passagem;
        }




        public async Task<IEnumerable<PassagemAereaMongo>> ObterTodasPassagensAsync()
        {
            var passagens = await _passagemCollection.Find(FilterDefinition<PassagemAereaMongo>.Empty).ToListAsync();
            return passagens;
        }


        public async Task<PassagemAereaMongo> CriarPassagemAsync(PassagemAereaMongo passagem)
        {

            await _passagemCollection.InsertOneAsync(passagem);
            return passagem;
        }


        public async Task<PassagemAereaMongo> AtualizarPassagemAsync(ObjectId passagemId, PassagemAereaMongo passagemAtualizada)
        {
            var resultado = await _passagemCollection.ReplaceOneAsync(
                p => p.Id == passagemId,
                passagemAtualizada
            );

            if (resultado.MatchedCount == 0)
            {
                return null;
            }

            return passagemAtualizada;
        }

        // Deletar uma passagem
        public async Task<bool> DeletarPassagemAsync(ObjectId passagemId)
        {
            var resultado = await _passagemCollection.DeleteOneAsync(p => p.Id == passagemId);
            return resultado.DeletedCount > 0;
        }
    }
}

using MongoDB.Bson;
using Sistemapassagemaerea.Data.Mongodb.Entities;

namespace Sistemapassagemaerea.Data.Mongodb
{
    public interface IPassagemMongoRepository
    {
        // Método para obter uma passagem específica com todos os detalhes relacionados
        Task<PassagemAereaMongo> ObterPassagemComDetalhesAsync(ObjectId passagemId);

        // Método para obter todas as passagens
        Task<IEnumerable<PassagemAereaMongo>> ObterTodasPassagensAsync();

        // Método para criar uma nova passagem
        Task<PassagemAereaMongo> CriarPassagemAsync(PassagemAereaMongo passagem);

        // Método para atualizar uma passagem existente
        Task<PassagemAereaMongo> AtualizarPassagemAsync(ObjectId passagemId, PassagemAereaMongo passagemAtualizada);

        // Método para deletar uma passagem
        Task<bool> DeletarPassagemAsync(ObjectId passagemId);
    }
}

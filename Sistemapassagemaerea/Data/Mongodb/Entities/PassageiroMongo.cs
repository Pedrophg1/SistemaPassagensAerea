using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Sistemapassagemaerea.Data.Mongodb.Entities
{
    public class PassageiroMongo
    {
        [BsonId]  // Indica que a propriedade Id será usada como a chave primária no MongoDB.
        public int Id { get; set; }

        [BsonElement("cpf")]
        public string Cpf { get; set; } = default!;

        [BsonElement("nome")]
        public string Nome { get; set; } = default!;

        [BsonElement("dataNascimento")]
        public DateTime DataNascimento { get; set; }  // Usando DateTime aqui para MongoDB (ao invés de DateOnly)
    }
}
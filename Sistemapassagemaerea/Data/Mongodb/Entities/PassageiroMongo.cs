using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sistemapassagemaerea.Data.Mongodb.Entities
{
    public class PassageiroMongo
    {

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("cpf")]
        public string Cpf { get; set; } = default!;

        [BsonElement("nome")]
        public string Nome { get; set; } = default!;

        [BsonElement("dataNascimento")]
        public DateTime DataNascimento { get; set; }
    }
}

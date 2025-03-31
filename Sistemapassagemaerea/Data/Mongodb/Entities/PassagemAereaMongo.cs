using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sistemapassagemaerea.Data.Mongodb.Entities
{
    public class PassagemAereaMongo
    {

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("codigoPassagem")]
        public string CodigoPassagem { get; set; } = default!;

        [BsonElement("dataHoraCompra")]
        public DateTime DataHoraCompra { get; set; }

        [BsonElement("valorPassagem")]
        public decimal ValorPassagem { get; set; }

        [BsonElement("idPassageiro")]
        public ObjectId IdPassageiro { get; set; }

        [BsonElement("idCompanhiaAerea")]
        public ObjectId IdCompanhiaAerea { get; set; }
        [BsonElement("passageiro")]
        public PassageiroMongo? Passageiro { get; set; } = default!;  // Carrega os dados do Passageiro

        [BsonElement("companhiaAerea")]
        public CompanhiaAereaMongo? CompanhiaAerea { get; set; } = default!;
    }
}

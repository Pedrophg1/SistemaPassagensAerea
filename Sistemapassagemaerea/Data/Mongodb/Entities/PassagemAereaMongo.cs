using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Sistemapassagemaerea.Data.Mongodb.Entities
{
    public class PassagemAereaMongo
    {
        [BsonId]  // Indica que a propriedade Id será usada como a chave primária no MongoDB.
        public int Id { get; set; }

        [BsonElement("codigoPassagem")]
        public string CodigoPassagem { get; set; } = default!;

        [BsonElement("dataHoraCompra")]
        public DateTime DataHoraCompra { get; set; }

        [BsonElement("valorPassagem")]
        public decimal ValorPassagem { get; set; }

        [BsonElement("idPassageiro")]
        public int IdPassageiro { get; set; }

        [BsonElement("idCompanhiaAerea")]
        public int IdCompanhiaAerea { get; set; }
    }
}

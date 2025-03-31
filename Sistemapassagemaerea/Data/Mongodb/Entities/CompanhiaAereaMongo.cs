using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sistemapassagemaerea.Data.Mongodb.Entities
{
    public class CompanhiaAereaMongo
    {

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("codIATA")]
        public string CodIATA { get; set; } = default!;

        [BsonElement("nomeCompanhia")]
        public string NomeCompanhia { get; set; } = default!;

        [BsonElement("enderecoCompanhia")]
        public string EnderecoCompanhia { get; set; } = default!;
        [BsonElement("passagensAereas")]
        public List<PassagemAereaMongo> PassagensAereas { get; set; } = new List<PassagemAereaMongo>();


    }
}

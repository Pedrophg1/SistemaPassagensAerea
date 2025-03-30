using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Sistemapassagemaerea.Data.Mongodb.Entities
{
    public class CompanhiaAereaMongo
    {
        [BsonId]  // Indica que a propriedade Id será usada como a chave primária no MongoDB.
        public int Id { get; set; }

        [BsonElement("codIATA")]
        public string CodIATA { get; set; } = default!;

        [BsonElement("nomeCompanhia")]
        public string NomeCompanhia { get; set; } = default!;

        [BsonElement("enderecoCompanhia")]
        public string EnderecoCompanhia { get; set; } = default!;

       
        //public virtual List<PassagemAereaMongo> PassagensAereas { get; set; } = new List<PassagemAereaMongo>();
    }
}

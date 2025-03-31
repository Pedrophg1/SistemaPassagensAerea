using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sistemapassagemaerea.Data.Mongodb.Entities;

namespace Sistemapassagemaerea.Data.Mongodb
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        }

        public IMongoCollection<PassageiroMongo> Passageiros => _database.GetCollection<PassageiroMongo>("Passageiros");
        public IMongoCollection<PassagemAereaMongo> PassagensAereas => _database.GetCollection<PassagemAereaMongo>("PassagensAereas");
        public IMongoCollection<CompanhiaAereaMongo> CompanhiasAereas => _database.GetCollection<CompanhiaAereaMongo>("CompanhiasAereas");
    }
}

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoTest.Model;

namespace MongoTest.Data
{

    public class MongoContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Todo> Todos
        {
            get
            {
                return _database.GetCollection<Todo>("Todos");
            }
        }
    }
}
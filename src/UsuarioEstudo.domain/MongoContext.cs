using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace UsuarioEstudo.domain
{
    public class MongoContext
    {
        public readonly IMongoDatabase DataBase;

        public MongoContext(IConfiguration configuration)
        {
            MongoUrl url = new MongoUrl(configuration.GetConnectionString("mongoDb"));
            MongoClient client = new MongoClient(url);
            DataBase = client.GetDatabase(url.DatabaseName);
        }
    }
}

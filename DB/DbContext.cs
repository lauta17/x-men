using DB.Entities;
using DB.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DB
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public DbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("MongoDataBaseConnection:ConnectionString").Value);
            _mongoDatabase = client.GetDatabase(configuration.GetSection("MongoDataBaseConnection:DataBase").Value);
        }

        public IMongoCollection<DnaData> Dna
        {
            get
            {
                return _mongoDatabase.GetCollection<DnaData>("dna");
            }
        }
    }
}

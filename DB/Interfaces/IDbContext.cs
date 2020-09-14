using DB.Entities;
using MongoDB.Driver;

namespace DB.Interfaces
{
    public interface IDbContext
    {
        IMongoCollection<DnaData> Dna { get; }
    }
}

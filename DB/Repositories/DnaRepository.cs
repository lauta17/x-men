using DB.Entities;
using DB.Interfaces;
using Domain.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class DnaRepository : IDnaRepository
    {
        private readonly IDbContext _dbContext;

        public DnaRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(HumanDna dna)
        {
            await _dbContext.Dna.InsertOneAsync(new DnaData
            {
                Dna = dna.Description,
                IsMutant = dna.IsMutant
            });
        }

        public async Task<DnaSummary> GetSummary()
        {
            var humansCountTask = _dbContext.Dna.CountDocumentsAsync(new BsonDocument());
            var mutantsCountTask = _dbContext.Dna.CountDocumentsAsync(x => x.IsMutant);

            await Task.WhenAll(humansCountTask, mutantsCountTask);

            return new DnaSummary
            {
                CountHumanDna = humansCountTask.Result,
                CountMutantDna = mutantsCountTask.Result
            };
        }
    }
}

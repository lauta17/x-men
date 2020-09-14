using AutoMoqCore;
using DB.Entities;
using DB.Interfaces;
using DB.Repositories;
using Domain.Entities;
using MongoDB.Driver;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DB.Tests.Repositories
{
    public class DnaRepositoryTests
    {
        private readonly AutoMoqer _autoMoqer;
        private readonly IDnaRepository _dnaRepository;

        public DnaRepositoryTests()
        {
            _autoMoqer = new AutoMoqer();
            _dnaRepository = _autoMoqer.Resolve<DnaRepository>();
        }

        [Fact]
        public void InsertHumanDna()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"
            };

            var humanDna = new HumanDna(dna) { IsMutant = true };

            var mockDnaData = _autoMoqer.GetMock<IMongoCollection<DnaData>>();
            mockDnaData.Setup(x => x.InsertOneAsync(It.IsAny<DnaData>(), It.IsAny<InsertOneOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<object>(null));

            var mockDbContext = _autoMoqer.GetMock<IDbContext>();
            mockDbContext.Setup(x => x.Dna)
                .Returns(mockDnaData.Object);

            //ACT
            _dnaRepository.Insert(humanDna);

            //ASSERT
            mockDnaData.Verify(x => x.InsertOneAsync(It.IsAny<DnaData>(), It.IsAny<InsertOneOptions>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void GetSummary()
        {
            //ARRANGE
            var mockDnaData = _autoMoqer.GetMock<IMongoCollection<DnaData>>();
            mockDnaData.Setup(x => x.CountDocumentsAsync(It.IsAny<FilterDefinition<DnaData>>(), It.IsAny<CountOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((long)1));

            var mockDbContext = _autoMoqer.GetMock<IDbContext>();
            mockDbContext.Setup(x => x.Dna)
                .Returns(mockDnaData.Object);

            //ACT
            var result = _dnaRepository.GetSummary().Result;

            //ASSERT
            Assert.Equal(result.CountMutantDna, 1);
            Assert.Equal(result.CountHumanDna, 1);
            Assert.Equal(result.CountMutantDna, 1);
        }
    }
}

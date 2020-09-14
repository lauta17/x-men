using AutoMoqCore;
using DB.Interfaces;
using Domain.Entities;
using Services.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace Services.Tests.Controllers
{
    public class StatsControllerTests
    {
        private readonly StatsController _statsController;
        private readonly AutoMoqer _autoMoqer;

        public StatsControllerTests()
        {
            _autoMoqer = new AutoMoqer();
            _statsController = _autoMoqer.Resolve<StatsController>();
        }

        [Fact]
        public void Get()
        {
            //ARRANGE
            var summary = new DnaSummary
            {
                CountHumanDna = 4,
                CountMutantDna = 2
            };

            var ratio = (decimal)summary.CountMutantDna / summary.CountHumanDna;

            var mockDnaRepository = _autoMoqer.GetMock<IDnaRepository>();
            mockDnaRepository.Setup(x => x.GetSummary())
                .Returns(Task.FromResult(summary));

            //ACT
            var result = _statsController.Get().Result;

            //ASSERT
            Assert.Equal(result.count_human_dna, 4);
            Assert.Equal(result.count_mutant_dna, 2);
            Assert.Equal(result.ratio, ratio);
        }
    }
}

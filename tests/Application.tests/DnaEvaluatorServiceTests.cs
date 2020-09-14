using Application.Interfaces;
using AutoMoqCore;
using DB.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.tests
{
    public class DnaEvaluatorServiceTests
    {
        private readonly AutoMoqer _autoMoqer;
        private readonly IDnaEvaluatorService _dnaEvaluatorService;

        public DnaEvaluatorServiceTests()
        {
            _autoMoqer = new AutoMoqer();
            _dnaEvaluatorService = _autoMoqer.Resolve<DnaEvaluatorService>();
        }

        [Fact]
        public void EvaluateMustReturnIsMutant()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"
            };

            var humanDna = new HumanDna(dna);

            var mockDnaBuilder = _autoMoqer.GetMock<IDnaBuilder>();

            mockDnaBuilder.Setup(x => x.AddDna(dna, DnaType.Human))
                .Returns(mockDnaBuilder.Object);
            mockDnaBuilder.Setup(x => x.Build())
                .Returns(humanDna);

            var mockDnaEvaluator = _autoMoqer.GetMock<IDnaEvaluator>();

            mockDnaEvaluator.Setup(x => x.IsMutant(humanDna))
                .Returns(true);

            var mockDnaRepository = _autoMoqer.GetMock<IDnaRepository>();
            mockDnaRepository.Setup(x => x.Insert(humanDna))
                .Returns(Task.CompletedTask);

            //ACT
            var result = _dnaEvaluatorService.Evaluate(dna).Result;

            //ASSERT
            Assert.True(result);
            Assert.Equal(humanDna.IsMutant, result);
        }
    }
}

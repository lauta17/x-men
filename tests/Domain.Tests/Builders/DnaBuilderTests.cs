using AutoMoqCore;
using Domain.Builders;
using Domain.Entities;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests.Builders
{
    public class DnaBuilderTests
    {
        private readonly AutoMoqer _autoMoqer;
        private readonly IDnaBuilder _dnaBuilder;

        public DnaBuilderTests()
        {
            _autoMoqer = new AutoMoqer();
            _dnaBuilder = _autoMoqer.Resolve<DnaBuilder>();
        }

        [Fact]
        public void AddDnaAndBuild()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"
            };

            var mockDnaFactory = _autoMoqer.GetMock<IDnaFactory>();
            mockDnaFactory.Setup(x => x.Create(dna, DnaType.Human))
                .Returns(new HumanDna(dna));

            //ACT
            var result = _dnaBuilder.AddDna(dna, DnaType.Human);
            var humanDna = result.Build();

            //ASSERT
            Assert.Equal(humanDna.Description.ToString(), dna.ToString());
            Assert.Equal(typeof(HumanDna), humanDna.GetType());
        }
    }
}

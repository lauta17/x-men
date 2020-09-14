using AutoMoqCore;
using Domain.Entities;
using Domain.Factories;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests.Factories
{
    public class DnaFactoryTests
    {
        private readonly AutoMoqer _autoMoqer;
        private readonly IDnaFactory _dnaFactory;

        public DnaFactoryTests()
        {
            _autoMoqer = new AutoMoqer();
            _dnaFactory = _autoMoqer.Resolve<DnaFactory>();
        }

        [Fact]
        public void CreateHumanDna()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"
            };

            //ACT
            var result = _dnaFactory.Create(dna, DnaType.Human);

            //ASSERT
            Assert.Equal(typeof(HumanDna), result.GetType());
            Assert.Equal(result.Description, dna);
        }
    }
}

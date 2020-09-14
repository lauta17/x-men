using AutoMoqCore;
using Domain.Evaluators.Dna;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests.Evaluators.Dna
{
    public class AntiDiagonalEvaluatorTests
    {
        private readonly AutoMoqer _autoMoqer;
        private readonly IDnaCondition _dnaCondition;

        public AntiDiagonalEvaluatorTests()
        {
            _autoMoqer = new AutoMoqer();
            _dnaCondition = _autoMoqer.Resolve<AntiDiagonalEvaluator>();
        }

        [Fact]
        public void ContainsMustGetFoundMatch()
        {
            //ARRANGE
            var dna = new string[] { "ATGCGA", "CAGTAC", "TTAAGT", "AGAAGG", "CCCCTA", "TCACTG" };

            //ACT
            var result = _dnaCondition.Contains(dna);

            //ASSERT
            Assert.True(result == 1);
        }

        [Fact]
        public void ContainsMustNotGetFoundMatch()
        {
            //ARRANGE
            var dna = new string[] { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" };

            //ACT
            var result = _dnaCondition.Contains(dna);

            //ASSERT
            Assert.True(result == 0);
        }
    }
}

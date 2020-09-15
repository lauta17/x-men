using AutoMoqCore;
using Domain.Evaluators.Dna;
using Domain.Interfaces;
using Xunit;

namespace Domain.Tests.Evaluators.Dna
{
    public class RowEvaluatorTests
    {
        private readonly AutoMoqer _autoMoqer;
        private readonly IDnaCondition _dnaCondition;

        public RowEvaluatorTests()
        {
            _autoMoqer = new AutoMoqer();
            _dnaCondition = _autoMoqer.Resolve<RowEvaluator>();
        }

        [Fact]
        public void ContainsMustGetFoundMatch()
        {
            //ARRANGE
            var dna = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            //ACT
            var result = _dnaCondition.GetCoincidences(dna);

            //ASSERT
            Assert.True(result == 1);
        }

        [Fact]
        public void ContainsMustNotGetFoundMatch()
        {
            //ARRANGE
            var dna = new string[] { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG" };

            //ACT
            var result = _dnaCondition.GetCoincidences(dna);

            //ASSERT
            Assert.True(result == 0);
        }
    }
}

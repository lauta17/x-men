using AutoMoqCore;
using Domain.Entities;
using Domain.Evaluators;
using Domain.Interfaces;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Domain.Evaluators.Dna;

namespace Domain.Tests.Evaluators
{
    public class DnaEvaluatorTests
    {
        private readonly IDnaEvaluator _dnaEvaluator;

        public DnaEvaluatorTests()
        {
            var services = new ServiceCollection();

            services.AddScoped<IDnaCondition>(p => new ColumnEvaluator());
            services.AddScoped<IDnaCondition>(p => new DiagonalEvaluator());
            services.AddScoped<IDnaCondition>(p => new AntiDiagonalEvaluator());
            services.AddScoped<IDnaCondition>(p => new RowEvaluator());

            _dnaEvaluator = new DnaEvaluator(services.BuildServiceProvider());
        }

        [Fact]
        public void IsMutantMustReturnTrue()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG"
            };

            var humanDna = new HumanDna(dna);

            //ACT
            var result = _dnaEvaluator.IsMutant(humanDna);

            //ASSERT
            Assert.True(result);
        }

        [Fact]
        public void IsMutantMustReturnFalse()
        {
            //ARRANGE
            var dna = new string[]
            {
                "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG"
            };

            var humanDna = new HumanDna(dna);

            //ACT
            var result = _dnaEvaluator.IsMutant(humanDna);

            //ASSERT
            Assert.False(result);
        }
    }
}

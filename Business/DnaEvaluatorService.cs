using Application.Interfaces;
using DB.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Application
{
    public class DnaEvaluatorService : IDnaEvaluatorService
    {
        private readonly IDnaBuilder _dnaBuilder;
        private readonly IDnaEvaluator _dnaEvaluator;
        private readonly IDnaRepository _dnaRepository;

        public DnaEvaluatorService(
            IDnaBuilder dnaBuilder,
            IDnaEvaluator dnaEvaluator,
            IDnaRepository dnaRepository)
        {
            _dnaBuilder = dnaBuilder;
            _dnaEvaluator = dnaEvaluator;
            _dnaRepository = dnaRepository;
        }

        public async Task<bool> Evaluate(string[] dna)
        {
            var humanDna = (HumanDna)_dnaBuilder.AddDna(dna, DnaType.Human).Build();
            humanDna.IsMutant = _dnaEvaluator.IsMutant(humanDna);

            //await _dnaRepository.Insert();

            return await Task.FromResult(humanDna.IsMutant);
        }
    }
}

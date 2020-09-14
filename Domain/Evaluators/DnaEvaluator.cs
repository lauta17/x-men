using Domain.Entities;
using Domain.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Evaluators
{
    public class DnaEvaluator : IDnaEvaluator
    {
        private readonly IServiceProvider _serviceProvider;
        private const int _matchesNeededToBeMutant = 2;

        public DnaEvaluator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool IsMutant(HumanDna humanDna)
        {
            var amountMatches = 0;

            foreach (var conditions in _serviceProvider.GetServices<IDnaCondition>())
            {
                amountMatches += conditions.Contains(humanDna.Description);

                if (amountMatches >= _matchesNeededToBeMutant)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

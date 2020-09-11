using Application.Interfaces;
using DB.Interfaces;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Application
{
    public class DnaEvaluator : IDnaEvaluator
    {
        private readonly IDnaValidator _dnaValidator;
        private readonly IDnaRepository _dnaRepository;
        private readonly IServiceProvider _serviceProvider;

        public DnaEvaluator(IDnaValidator dnaValidator,
            IDnaRepository dnaRepository,
            IServiceProvider serviceProvider)
        {
            _dnaValidator = dnaValidator;
            _dnaRepository = dnaRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> IsMutant(string[] dna)
        {
            //isHuman ? validar que las letras del adn no contengan letras no contempladas. esto te daria si es un humano.//valida si es adn mutante
            var matches = 0;

            foreach (var conditions in _serviceProvider.GetServices<IDnaCondition>())
            {
                matches += conditions.Contains(dna);
            }

            if (matches > 2)
            {
                var isMutant = true;
            }
            
            //inserta valores.
            await _dnaRepository.Insert();

            return await Task.FromResult(true);
        }
    }
}

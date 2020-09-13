using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.Factories
{
    public class DnaFactory : IDnaFactory
    {
        private readonly Dictionary<DnaType, Dna> _dictionary;

        public DnaFactory()
        {
            _dictionary = new Dictionary<DnaType, Dna>();
        }

        public Dna Create(string[] dna, DnaType dnaType)
        {
            _dictionary.Add(DnaType.Human, new HumanDna(dna));

            return _dictionary[dnaType];
        }
    }
}

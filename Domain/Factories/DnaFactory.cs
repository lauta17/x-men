using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Factories
{
    public class DnaFactory : IDnaFactory
    {
        private readonly Dictionary<DnaType, Func<string[], Dna>> _dictionary;

        public DnaFactory()
        {
            _dictionary = new Dictionary<DnaType, Func<string[], Dna>>
            {
                { DnaType.Human, (dna) => new HumanDna(dna) }
            };
        }

        public Dna Create(string[] dna, DnaType dnaType)
        {
            return _dictionary[dnaType].Invoke(dna);
        }
    }
}

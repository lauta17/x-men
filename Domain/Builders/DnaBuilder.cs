using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Builders
{
    public class DnaBuilder : IDnaBuilder
    {
        private Dna _dna { get; set; }
        private readonly IDnaFactory _dnaFactory;

        public DnaBuilder(IDnaFactory dnaFactory)
        {
            _dnaFactory = dnaFactory;
        }

        public IDnaBuilder AddDna(string[] dna, DnaType dnaType)
        {
            _dna = _dnaFactory.Create(dna, dnaType);

            return this;
        }

        public Dna Build()
        {
            return _dna;
        }
    }
}

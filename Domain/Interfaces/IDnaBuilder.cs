using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDnaBuilder
    {
        IDnaBuilder AddDna(string[] dna, DnaType dnaType);
        Dna Build();
    }
}

using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDnaFactory
    {
        Dna Create(string[] dna, DnaType dnaType);
    }
}

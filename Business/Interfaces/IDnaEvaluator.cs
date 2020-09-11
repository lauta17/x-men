using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDnaEvaluator
    {
        Task<bool> IsMutant(string[] dna);
    }
}

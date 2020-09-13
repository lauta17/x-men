using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDnaEvaluatorService
    {
        Task<bool> Evaluate(string[] dna);
    }
}

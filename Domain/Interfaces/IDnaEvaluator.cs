using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDnaEvaluator
    {
        bool IsMutant(HumanDna humanDna);
    }
}

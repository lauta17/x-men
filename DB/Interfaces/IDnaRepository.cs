using Domain.Entities;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IDnaRepository
    {
        Task Insert(HumanDna dna);
        Task<DnaSummary> GetSummary();
    }
}

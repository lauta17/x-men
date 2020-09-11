using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IDnaRepository
    {
        Task<int> Insert();
    }
}

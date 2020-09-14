using DB.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using System.Threading.Tasks;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IDnaRepository _dnaRepository;

        public StatsController(IDnaRepository dnaRepository)
        {
            _dnaRepository = dnaRepository;
        }

        [HttpGet]
        public async Task<DnaSummaryResponse> Get()
        {
            var summary = await _dnaRepository.GetSummary();

            return new DnaSummaryResponse
            {
                count_human_dna = summary.CountHumanDna,
                count_mutant_dna = summary.CountMutantDna,
                ratio = summary.Ratio
            };
        }
    }
}

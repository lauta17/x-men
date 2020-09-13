using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MutantController : ControllerBase
    {
        private readonly IDnaEvaluatorService _dnaEvaluator;

        public MutantController(IDnaEvaluatorService dnaEvaluator)
        {
            _dnaEvaluator = dnaEvaluator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]DnaDto dnaDto)
        {
            try
            {
                var isMutant = await _dnaEvaluator.Evaluate(dnaDto.Dna);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public string Get()
        {
            return "hola mundo";
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Data.Mongodb.Entities;
using Sistemapassagemaerea.Domain.Interfaces;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanhiaAereaMongoController : ControllerBase
    {
        private readonly ICompanhiaAereaMongoRepository _companhiaAereaMongoRepository;

        public CompanhiaAereaMongoController(ICompanhiaAereaMongoRepository companhiaAereaMongoRepository)
        {
            _companhiaAereaMongoRepository = companhiaAereaMongoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanhias()
        {
            var companhias = await _companhiaAereaMongoRepository.GetAllAsync();
            return Ok(companhias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanhiaById(int id)
        {
            var companhia = await _companhiaAereaMongoRepository.GetByIdAsync(id);
            if (companhia == null)
            {
                return NotFound();
            }
            return Ok(companhia);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanhia([FromBody] CompanhiaAereaMongo companhia)
        {
            await _companhiaAereaMongoRepository.AddAsync(companhia);
            return CreatedAtAction(nameof(GetCompanhiaById), new { id = companhia.Id }, companhia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanhia(int id, [FromBody] CompanhiaAereaMongo companhia)
        {
            if (id != companhia.Id)
            {
                return BadRequest();
            }

            await _companhiaAereaMongoRepository.UpdateAsync(companhia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanhia(int id)
        {
            await _companhiaAereaMongoRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Data.Mongodb.Entities;
using Sistemapassagemaerea.Domain.Interfaces;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassageiroMongoController : ControllerBase
    {
        private readonly IPassageiroMongoRepository _passageiroMongoRepository;

        public PassageiroMongoController(IPassageiroMongoRepository passageiroMongoRepository)
        {
            _passageiroMongoRepository = passageiroMongoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPassageiros()
        {
            var passageiros = await _passageiroMongoRepository.GetAllAsync();
            return Ok(passageiros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassageiroById(int id)
        {
            var passageiro = await _passageiroMongoRepository.GetByIdAsync(id);
            if (passageiro == null)
            {
                return NotFound();
            }
            return Ok(passageiro);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassageiro([FromBody] PassageiroMongo passageiro)
        {
            await _passageiroMongoRepository.AddAsync(passageiro);
            return CreatedAtAction(nameof(GetPassageiroById), new { id = passageiro.Id }, passageiro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassageiro(int id, [FromBody] PassageiroMongo passageiro)
        {
            if (id != passageiro.Id)
            {
                return BadRequest();
            }

            await _passageiroMongoRepository.UpdateAsync(passageiro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassageiro(int id)
        {
            await _passageiroMongoRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Data.Mongodb.Entities;
using Sistemapassagemaerea.Domain.Interfaces;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassagemAereaMongoController : ControllerBase
    {
        private readonly IPassagemAereaMongoRepository _passagemAereaMongoRepository;

        public PassagemAereaMongoController(IPassagemAereaMongoRepository passagemAereaMongoRepository)
        {
            _passagemAereaMongoRepository = passagemAereaMongoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPassagensAereas()
        {
            var passagensAereas = await _passagemAereaMongoRepository.GetAllAsync();
            return Ok(passagensAereas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassagemAereaById(int id)
        {
            var passagemAerea = await _passagemAereaMongoRepository.GetByIdAsync(id);
            if (passagemAerea == null)
            {
                return NotFound();
            }
            return Ok(passagemAerea);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassagemAerea([FromBody] PassagemAereaMongo passagemAerea)
        {
            await _passagemAereaMongoRepository.AddAsync(passagemAerea);
            return CreatedAtAction(nameof(GetPassagemAereaById), new { id = passagemAerea.Id }, passagemAerea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassagemAerea(int id, [FromBody] PassagemAereaMongo passagemAerea)
        {
            if (id != passagemAerea.Id)
            {
                return BadRequest();
            }

            await _passagemAereaMongoRepository.UpdateAsync(passagemAerea);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagemAerea(int id)
        {
            await _passagemAereaMongoRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
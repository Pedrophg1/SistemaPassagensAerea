using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Data.Mongodb.Entities;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassagemAereaMongoController : ControllerBase
    {
        private readonly IPassagemAereaMongoService _passagemAereaService;

        // Construtor corrigido
        public PassagemAereaMongoController(IPassagemAereaMongoService passagemAereaService)
        {
            _passagemAereaService = passagemAereaService;
        }

        // Método para criar uma passagem
        [HttpPost]
        public async Task<IActionResult> CriarPassagem([FromBody] PassagemAereaMongo passagemAerea)
        {
            try
            {
                await _passagemAereaService.AddPassagemAsync(passagemAerea);
                return CreatedAtAction(nameof(CriarPassagem), new { id = passagemAerea.Id }, passagemAerea);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Método para buscar todas as passagens
        [HttpGet]
        public async Task<IActionResult> GetAllPassagens()
        {
            var passagens = await _passagemAereaService.GetAllPassagensAsync();
            return Ok(passagens);
        }

        // Método para buscar passagem por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassagemById(int id)
        {
            var passagem = await _passagemAereaService.GetPassagemByIdAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            return Ok(passagem);
        }

        // Método para atualizar uma passagem
        [HttpPut]
        public async Task<IActionResult> UpdatePassagem([FromBody] PassagemAereaMongo passagemAerea)
        {
            try
            {
                await _passagemAereaService.UpdatePassagemAsync(passagemAerea);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Método para deletar uma passagem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            try
            {
                await _passagemAereaService.DeletePassagemAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

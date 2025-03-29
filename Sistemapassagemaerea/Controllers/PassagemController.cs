using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Services;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {
        private readonly IPassagemService _passagemService;

        public PassagemController(IPassagemService passagemService)
        {
            _passagemService = passagemService;
        }

        // GET: api/Passagem
        [HttpGet]
        public async Task<IActionResult> GetAllPassagens()
        {
            var passagens = await _passagemService.GetAllPassagensAsync();
            return Ok(passagens);
        }

        // GET: api/Passagem/5/AA
        [HttpGet("{cpfPassageiro}/{codigoCompanhiaAerea}")]
        public async Task<IActionResult> GetPassagemById(string cpfPassageiro, string codigoCompanhiaAerea)
        {
            var passagem = await _passagemService.GetPassagemByIdAsync(cpfPassageiro, codigoCompanhiaAerea);
            if (passagem == null)
            {
                return NotFound();
            }
            return Ok(passagem);
        }

        // POST: api/Passagem
        [HttpPost]
        public async Task<IActionResult> CreatePassagem([FromBody] PassagemAerea passagemAerea)
        {
            if (passagemAerea == null)
            {
                return BadRequest();
            }

            await _passagemService.AddPassagemAsync(passagemAerea);
            return CreatedAtAction(nameof(GetPassagemById), new { cpfPassageiro = passagemAerea.CpfPassageiro, codigoCompanhiaAerea = passagemAerea.CodigoCompanhiaAerea }, passagemAerea);
        }

        // PUT: api/Passagem/5/AA
        [HttpPut("{cpfPassageiro}/{codigoCompanhiaAerea}")]
        public async Task<IActionResult> UpdatePassagem(string cpfPassageiro, string codigoCompanhiaAerea, [FromBody] PassagemAerea passagemAerea)
        {
            if (cpfPassageiro != passagemAerea.CpfPassageiro || codigoCompanhiaAerea != passagemAerea.CodigoCompanhiaAerea)
            {
                return BadRequest();
            }

            await _passagemService.UpdatePassagemAsync(passagemAerea);
            return NoContent();
        }

        // DELETE: api/Passagem/5/AA
        [HttpDelete("{cpfPassageiro}/{codigoCompanhiaAerea}")]
        public async Task<IActionResult> DeletePassagem(string cpfPassageiro, string codigoCompanhiaAerea)
        {
            await _passagemService.DeletePassagemAsync(cpfPassageiro, codigoCompanhiaAerea);
            return NoContent();
        }
    }
}

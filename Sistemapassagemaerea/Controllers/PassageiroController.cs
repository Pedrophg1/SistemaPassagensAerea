using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Services;

namespace Sistemapassagemaerea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassageiroController : ControllerBase
    {
        private readonly IPassageiroService _passageiroService;

        public PassageiroController(IPassageiroService passageiroService)
        {
            _passageiroService = passageiroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPassageiros()
        {
            var passageiros = await _passageiroService.GetAllPassageirosAsync();
            return Ok(passageiros);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetPassageiro(string cpf)
        {
            var passageiro = await _passageiroService.GetPassageiroByCpfAsync(cpf);
            if (passageiro == null)
                return NotFound();
            return Ok(passageiro);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassageiro([FromBody] Passageiro passageiro)
        {
            await _passageiroService.AddPassageiroAsync(passageiro);
            return CreatedAtAction(nameof(GetPassageiro), new { cpf = passageiro.CpfPassageiro }, passageiro);
        }

        [HttpPut("{cpf}")]
        public async Task<IActionResult> UpdatePassageiro(string cpf, [FromBody] Passageiro passageiro)
        {
            var existingPassageiro = await _passageiroService.GetPassageiroByCpfAsync(cpf);
            if (existingPassageiro == null)
                return NotFound();

            await _passageiroService.UpdatePassageiroAsync(passageiro);
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeletePassageiro(string cpf)
        {
            await _passageiroService.DeletePassageiroAsync(cpf);
            return NoContent();
        }
    }

}

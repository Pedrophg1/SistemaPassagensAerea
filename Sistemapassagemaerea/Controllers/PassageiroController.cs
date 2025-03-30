using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Application.Interfaces;

namespace Sistemapassagemaerea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassageiroController(IPassageiroService passageiroService) : ControllerBase
    {
        private readonly IPassageiroService _passageiroService = passageiroService;

        [HttpGet]
        public async Task<IActionResult> GetAllPassageiros()
        {
            var passageiros = await _passageiroService.GetAllAsync();
            return Ok(passageiros);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPassageiro(int id)
        {
            var passageiro = await _passageiroService.GetByIdAsync(id);
            if (passageiro == null)
                return NotFound();
            return Ok(passageiro);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassageiro([FromBody] CadastrarPassageiroDto passageiro)
        {
            var response = await _passageiroService.AddAsync(passageiro);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePassageiro(int id, [FromBody] CadastrarPassageiroDto passageiro)
        {
            var existingPassageiro = await _passageiroService.GetByIdAsync(id);
            if (existingPassageiro == null)
                return NotFound();

            
            await _passageiroService.UpdatePassageiroAsync(id, passageiro);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassageiro(int id)
        {
            await _passageiroService.DeletePassageiroAsync(id);
            return NoContent();
        }
    }

}

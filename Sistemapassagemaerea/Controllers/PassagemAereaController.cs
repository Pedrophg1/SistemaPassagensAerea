using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Application.Interfaces;

namespace Sistemapassagemaerea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassagemAereaController : ControllerBase
    {
        private readonly IPassagemAereaService _passagemAereaService;

        public PassagemAereaController(IPassagemAereaService passagemAereaService)
        {
            _passagemAereaService = passagemAereaService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPassagens()
        {
            var passagens = await _passagemAereaService.GetAllPassagensAsync();
            return Ok(passagens);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePassagemAerea(int id, [FromBody] CadastrarPassagemAereaDto passagemAereaDto)
        {

            var existingPassagemAerea = await _passagemAereaService.GetByIdAsync((id));
            if (existingPassagemAerea == null)
                return NotFound();


            await _passagemAereaService.UpdatePassagemAereaAsync(id, passagemAereaDto);


            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> AddPassagemAerea([FromBody] CadastrarPassagemAereaDto passagemAereaDto)
        {
            var response = await _passagemAereaService.AddPassagemAereaAsync(passagemAereaDto);


            return CreatedAtAction(nameof(GetAllPassagens), new { id = response.Id }, passagemAereaDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagemAerea(int id)
        {
            await _passagemAereaService.DeletePassagemAereaAsync(id);
            return NoContent();
        }
    }
}

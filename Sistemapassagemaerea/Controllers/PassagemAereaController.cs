using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Application.Interfaces;
using Sistemapassagemaerea.Application.DTOs;

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

        [HttpPost]
        public async Task<IActionResult> AddPassagemAerea([FromBody] PassagemAereaDto passagemAereaDto)
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

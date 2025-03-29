using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Services;

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
        public async Task<IActionResult> AddPassagemAerea([FromBody] PassagemAerea passagemAerea)
        {
            await _passagemAereaService.AddPassagemAereaAsync(passagemAerea);
            return CreatedAtAction(nameof(GetAllPassagens), passagemAerea);
        }

        [HttpDelete("{cpfPassageiro}/{codigoCompanhiaAerea}")]
        public async Task<IActionResult> DeletePassagemAerea(string cpfPassageiro, string codigoCompanhiaAerea)
        {
            await _passagemAereaService.DeletePassagemAereaAsync(cpfPassageiro, codigoCompanhiaAerea);
            return NoContent();
        }
    }

}

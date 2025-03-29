using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Services;

namespace Sistemapassagemaerea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanhiaAereaController : ControllerBase
    {
        private readonly ICompanhiaAereaService _companhiaAereaService;

        public CompanhiaAereaController(ICompanhiaAereaService companhiaAereaService)
        {
            _companhiaAereaService = companhiaAereaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanhias()
        {
            var companhias = await _companhiaAereaService.GetAllCompanhiasAsync();
            return Ok(companhias);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetCompanhia(string codigo)
        {
            var companhia = await _companhiaAereaService.GetCompanhiaByCodigoAsync(codigo);
            if (companhia == null)
                return NotFound();
            return Ok(companhia);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanhia([FromBody] Companhia_Aerea companhia)
        {
            await _companhiaAereaService.AddCompanhiaAsync(companhia);
            return CreatedAtAction(nameof(GetCompanhia), new { codigo = companhia.CodIATA }, companhia);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> UpdateCompanhia(string codigo, [FromBody] Companhia_Aerea companhia)
        {
            var existingCompanhia = await _companhiaAereaService.GetCompanhiaByCodigoAsync(codigo);
            if (existingCompanhia == null)
                return NotFound();

            await _companhiaAereaService.UpdateCompanhiaAsync(companhia);
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteCompanhia(string codigo)
        {
            await _companhiaAereaService.DeleteCompanhiaAsync(codigo);
            return NoContent();
        }
    }

}

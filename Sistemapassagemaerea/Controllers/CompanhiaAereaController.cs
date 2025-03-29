using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Application.Interfaces;

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
            var companhias = await _companhiaAereaService.GetAllAsync();

            return Ok(companhias);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCompanhia(int id)
        {
            var companhia = await _companhiaAereaService.GetByIdAsync(id);
            
            if (companhia == null)
                return NotFound();

            return Ok(companhia);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanhia([FromBody] CadastrarCompanhiaAereaDto companhia)
        {
            var response = await _companhiaAereaService.AddAsync(companhia);

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCompanhia(int id, [FromBody] CadastrarCompanhiaAereaDto companhia)
        {
            var existingCompanhia = await _companhiaAereaService.GetByIdAsync(id);

            if (existingCompanhia == null)
                return NotFound();

            await _companhiaAereaService.Update(id, companhia);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompanhia(int id)
        {
            var existingCompanhia = await _companhiaAereaService.GetByIdAsync(id);

            if (existingCompanhia == null)
                return NotFound();

            await _companhiaAereaService.DeleteAsync(id);

            return NoContent();
        }
    }

}

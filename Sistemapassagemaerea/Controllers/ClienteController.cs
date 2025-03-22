using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Models;
using Sistemapassagemaerea.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistemapassagemaerea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        // Injeção de dependência
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

        // GET: api/cliente/{cpf}
        [HttpGet("{cpf}")]
        public async Task<ActionResult<Cliente>> GetClienteByCpf(string cpf)
        {
            var cliente = await _clienteService.GetClienteByCpfAsync(cpf);
            if (cliente == null)
            {
                return NotFound($"Cliente com CPF {cpf} não encontrado.");
            }
            return Ok(cliente);
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<ActionResult> AddCliente([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteService.AddClienteAsync(cliente);
                return CreatedAtAction(nameof(GetClienteByCpf), new { cpf = cliente.CpfCliente }, cliente);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cliente/{cpf}
        [HttpPut("{cpf}")]
        public async Task<ActionResult> UpdateCliente(string cpf, [FromBody] Cliente cliente)
        {
            if (cpf != cliente.CpfCliente)
            {
                return BadRequest("O CPF no corpo da requisição não corresponde ao CPF na URL.");
            }

            try
            {
                await _clienteService.UpdateClienteAsync(cliente);
                return NoContent(); // Atualizado com sucesso, mas sem retorno de dados
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/cliente/{cpf}
        [HttpDelete("{cpf}")]
        public async Task<ActionResult> DeleteCliente(string cpf)
        {
            try
            {
                await _clienteService.DeleteClienteAsync(cpf);
                return NoContent(); // Deletado com sucesso, mas sem retorno de dados
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Sistemapassagemaerea.Data.Mongodb;
using Sistemapassagemaerea.Data.Mongodb.Entities;

namespace Sistemapassagemaerea.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {
        private readonly IPassagemMongoRepository _passagemRepository;

        public PassagemController(IPassagemMongoRepository passagemRepository)
        {
            _passagemRepository = passagemRepository;
        }

        // GET: api/Passagem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassagemAereaMongo>>> GetAll()
        {
            var passagens = await _passagemRepository.ObterTodasPassagensAsync();
            return Ok(passagens);
        }

        // GET: api/Passagem/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PassagemAereaMongo>> GetById(string id)
        {
            if (!ObjectId.TryParse(id, out var passagemId))
            {
                return BadRequest("ID inválido.");
            }

            var passagem = await _passagemRepository.ObterPassagemComDetalhesAsync(passagemId);
            if (passagem == null)
            {
                return NotFound("Passagem não encontrada.");
            }

            return Ok(passagem);
        }



        // POST: api/Passagem
        [HttpPost]
        public async Task<ActionResult<PassagemAereaMongo>> Create([FromBody] PassagemAereaMongo passagem)
        {
            if (!ObjectId.TryParse(passagem.IdPassageiro.ToString(), out ObjectId idPassageiro))
            {
                return BadRequest("O id do Passageiro não é válido.");
            }

            var novaPassagem = await _passagemRepository.CriarPassagemAsync(passagem);

            return CreatedAtAction(nameof(GetById), new { id = novaPassagem.Id.ToString() }, novaPassagem);
        }

        // PUT: api/Passagem/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PassagemAereaMongo>> Update(string id, [FromBody] PassagemAereaMongo passagem)
        {
            if (!ObjectId.TryParse(id, out var passagemId))
            {
                return BadRequest("ID inválido.");
            }

            var passagemExistente = await _passagemRepository.ObterPassagemComDetalhesAsync(passagemId);
            if (passagemExistente == null)
            {
                return NotFound("Passagem não encontrada.");
            }

            passagem.Id = passagemId;  // Manter o ID da passagem existente
            var passagemAtualizada = await _passagemRepository.AtualizarPassagemAsync(passagemId, passagem);

            return Ok(passagemAtualizada);
        }

        // DELETE: api/Passagem/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (!ObjectId.TryParse(id, out var passagemId))
            {
                return BadRequest("ID inválido.");
            }

            var sucesso = await _passagemRepository.DeletarPassagemAsync(passagemId);

            if (!sucesso)
            {
                return NotFound("Passagem não encontrada.");
            }

            return NoContent();
        }
    }
}

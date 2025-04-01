using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Domain;

[Route("api/[controller]")]
[ApiController]
public class ComprovanteController : ControllerBase
{
    private readonly ComprovanteService _comprovanteService;

    public ComprovanteController(ComprovanteService comprovanteService)
    {
        _comprovanteService = comprovanteService;
    }

    [HttpPost("gerar")]
    public async Task<IActionResult> GerarComprovante([FromBody] Comprovante comprovante)
    {
        var passageiro = new Passageiro
        {
            Nome = comprovante.NomePassageiro,
            Cpf = comprovante.CpfPassageiro,
        };

        var passagem = new PassagemAerea
        {
            CodigoPassagem = comprovante.CodigoPassagem,
            DataHoraCompra = comprovante.DataHoraCompra,
            ValorPassagem = comprovante.ValorPassagem
        };

        var resultado = await _comprovanteService.GerarComprovanteAsync(passageiro, passagem);
        if (resultado)
        {
            return Ok("Comprovante gerado com sucesso!");
        }
        return BadRequest("Erro ao gerar comprovante.");
    }
}
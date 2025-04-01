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
    public async Task<IActionResult> GerarComprovante([FromBody] ComprovanteDto comprovanteDto)
    {
        var passageiro = new Passageiro
        {
            Nome = comprovanteDto.nomePassageiro,
            Cpf = comprovanteDto.cpfPassageiro
        };

        var passagem = new PassagemAerea
        {
            CodigoPassagem = comprovanteDto.CodigoPassagem,
            DataHoraCompra = comprovanteDto.DataHoraCompra,
            ValorPassagem = comprovanteDto.ValorPassagem
        };

        var resultado = await _comprovanteService.GerarComprovanteAsync(passageiro, passagem);
        if (resultado)
        {
            return Ok("Comprovante gerado com sucesso!");
        }
        return BadRequest("Erro ao gerar comprovante.");
    }
}
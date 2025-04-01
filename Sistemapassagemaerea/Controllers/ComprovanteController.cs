﻿using Microsoft.AspNetCore.Mvc;
using Sistemapassagemaerea.Application.DTOs;
using Sistemapassagemaerea.Application.Services;
using Sistemapassagemaerea.Domain;
using System.Threading.Tasks;

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
        if (comprovanteDto == null)
            return BadRequest("Dados inválidos.");

        var comprovante = new Comprovante
        {
            NomePassageiro = comprovanteDto.NomePassageiro,
            CpfPassageiro = comprovanteDto.CpfPassageiro,
            CodigoPassagem = comprovanteDto.CodigoPassagem,
            DataHoraCompra = comprovanteDto.DataHoraCompra,
            ValorPassagem = comprovanteDto.ValorPassagem
        };

        var resultado = await _comprovanteService.GerarComprovanteAsync(comprovante);
        if (resultado)
            return Ok("Comprovante gerado com sucesso!");

        return BadRequest("Erro ao gerar comprovante.");
    }
}
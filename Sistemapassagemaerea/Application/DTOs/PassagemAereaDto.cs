namespace Sistemapassagemaerea.Application.DTOs;

public record PassagemAereaDto(string CodigoPassagem,
                                DateTime DataHoraCompra,
                                decimal ValorPassagem,
                                int IdPassageiro,
                                string NomePassageiro,
                                int IdCompanhiaAerea);
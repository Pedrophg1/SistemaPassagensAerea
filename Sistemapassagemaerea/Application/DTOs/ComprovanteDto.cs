namespace Sistemapassagemaerea.Application.DTOs
{


    public record ComprovanteDto(string NomePassageiro, string CpfPassageiro, string CodigoPassagem, DateTime DataHoraCompra, decimal ValorPassagem);

}
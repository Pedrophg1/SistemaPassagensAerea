namespace Sistemapassagemaerea.Application.DTOs
{


    public record ComprovanteDto(string nomePassageiro, string cpfPassageiro, string CodigoPassagem, DateTime DataHoraCompra, decimal ValorPassagem);

}
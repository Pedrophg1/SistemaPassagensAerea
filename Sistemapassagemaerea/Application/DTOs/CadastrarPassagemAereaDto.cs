namespace Sistemapassagemaerea.Application.DTOs
{


    public record CadastrarPassagemAereaDto(string CodigoPassagem,
                                    DateTime DataHoraCompra,
                                    decimal ValorPassagem,
                                    int IdPassageiro,
                                    int IdCompanhiaAerea);
}

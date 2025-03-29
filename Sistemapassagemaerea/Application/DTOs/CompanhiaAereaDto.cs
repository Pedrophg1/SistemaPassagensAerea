using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Application.DTOs;

public record CompanhiaAereaDto(string CodIATA, string NomeCompanhia, string EnderecoCompanhia, 
                                IEnumerable<PassagemAereaDto>? PassagensAereas);

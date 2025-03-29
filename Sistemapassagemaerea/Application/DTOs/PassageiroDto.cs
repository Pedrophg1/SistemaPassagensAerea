using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Application.DTOs;

public record PassageiroDto(string Cpf, string Nome, DateOnly DataNascimento,
                            IEnumerable<PassagemAereaDto>? PassagensAereas);

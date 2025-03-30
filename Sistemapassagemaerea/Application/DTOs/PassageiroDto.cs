using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Application.DTOs;

public record PassageiroDto(string Cpf, string Nome, DateTime DataNascimento,
                            IEnumerable<PassagemAereaDto>? PassagensAereas);

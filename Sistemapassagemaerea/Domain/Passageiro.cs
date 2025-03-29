

using System.Text.Json.Serialization;

namespace Sistemapassagemaerea.Domain
{
    public class Passageiro : Entity
    {
        public string Cpf { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public required DateOnly DataNascimento { get; set; }
        
        public virtual ICollection<PassagemAerea>? PassagensAereas { get; set; }


    }
}

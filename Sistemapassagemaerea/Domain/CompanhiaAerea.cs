using System.Text.Json.Serialization;

namespace Sistemapassagemaerea.Domain
{
    public class CompanhiaAerea : Entity
    {
        public string CodIATA { get; set; } = default!;
        public string NomeCompanhia { get; set; } = default!;
        public string EnderecoCompanhia { get; set; } = default!;
        public virtual ICollection<PassagemAerea>? PassagensAereas { get; set; }
    }
}

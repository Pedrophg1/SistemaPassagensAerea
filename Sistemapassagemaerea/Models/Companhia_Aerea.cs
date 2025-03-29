using System.Text.Json.Serialization;

namespace Sistemapassagemaerea.Models
{
    public class Companhia_Aerea
    {
        public required string CodIATA { get; set; }
        public required string NomeCompanhia { get; set; }
        public required string EnderecoCompanhia { get; set; }
        [JsonIgnore]
        public  ICollection<PassagemAerea>? PassagensAereas { get; set; }
    }
}

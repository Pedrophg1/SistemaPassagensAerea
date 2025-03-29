

using System.Text.Json.Serialization;

namespace Sistemapassagemaerea.Models
{
    public class Passageiro
    {
        public required string CpfPassageiro { get; set; }
        public required string nome { get;  set; }
        public required DateOnly data_nasc { get; set; }
        [JsonIgnore]
        public  ICollection<PassagemAerea>? PassagensAereas { get; set; }


    }
}

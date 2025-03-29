using System.Text.Json.Serialization;

namespace Sistemapassagemaerea.Models
{
    public class PassagemAerea
    {
        public required string CodPassagem { get; set; }
        public required string CpfPassageiro { get; set; }
        public required DateTime DataHoraCompra { get; set; }
        public float ValorPassagem { get; set; }
        public  required string CodIATA { get; set; }
        
        public Companhia_Aerea? CompanhiaAerea { get; set; }
        
        public Passageiro? Passageiro { get; set; }
    }
}

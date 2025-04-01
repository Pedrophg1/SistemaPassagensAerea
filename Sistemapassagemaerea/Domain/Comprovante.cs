using System.ComponentModel.DataAnnotations;

namespace Sistemapassagemaerea.Domain
{
    public class Comprovante()
    {
        public string? NomePassageiro { get; set; }
        public string? CpfPassageiro { get; set; }
        [Key]
        public string? CodigoPassagem { get; set; }
        public DateTime DataHoraCompra { get; set; }
        public decimal ValorPassagem { get; set; }
    }
}

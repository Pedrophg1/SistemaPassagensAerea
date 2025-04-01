using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistemapassagemaerea.Domain
{
    public class Comprovante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? NomePassageiro { get; set; }

        [Required]
        public string? CpfPassageiro { get; set; }

        [Required]
        public string? CodigoPassagem { get; set; }

        [Required]
        public DateTime DataHoraCompra { get; set; }

        [Required]
        public decimal ValorPassagem { get; set; }
    }
}
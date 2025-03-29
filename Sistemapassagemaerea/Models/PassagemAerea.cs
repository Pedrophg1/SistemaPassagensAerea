namespace Sistemapassagemaerea.Models
{
    public class PassagemAerea
    {
        public required string CodPassagem { get; set; }
        public required string CpfPassageiro { get; set; }
        public required DateTime DataHoraCompra { get; set; }
        public float ValorPassagem { get; set; }
        public  required string CodigoCompanhiaAerea { get; set; }
        public required Companhia_Aerea CompanhiaAerea { get; set; }

        public Passageiro? Passageiro { get; set; }
    }
}

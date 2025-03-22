namespace Sistemapassagemaerea.Models
{
    public class PassagemAerea
    {
        public string CodPassagem { get; set; }
        public string CpfPassageiro { get; set; }
        public DateTime DataHoraCompra { get; set; }
        public float ValorPassagem { get; set; }

        public Passageiro Passageiro { get; set; }
    }
}

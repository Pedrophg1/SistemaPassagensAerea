namespace Sistemapassagemaerea.Domain
{
    public class PassagemAerea : Entity
    {
        public string CodigoPassagem { get; set; } = default!;
        public DateTime DataHoraCompra { get; set; }
        public decimal ValorPassagem { get; set; }

        public int IdPassageiro { get; set; }
        public int IdCompanhiaAerea { get; set; }

        public virtual CompanhiaAerea? CompanhiaAerea { get; set; }

        public virtual Passageiro? Passageiro { get; set; }
    }
}

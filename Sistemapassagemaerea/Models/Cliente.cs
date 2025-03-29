namespace Sistemapassagemaerea.Models
{

        public class Cliente
        {
            public required string CpfCliente { get; set; } 
            public required string PrimeiroNome { get; set; }
            public required string Sobrenome { get; set; }
            public required string Endereco { get; set; }
            public DateTime? DataNascimento { get; set; }

     
            public Passageiro? Passageiro { get; set; }
        }
    

}

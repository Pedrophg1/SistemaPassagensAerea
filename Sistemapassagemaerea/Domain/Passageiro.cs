﻿namespace Sistemapassagemaerea.Domain
{
    public class Passageiro : Entity
    {
        public string Cpf { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<PassagemAerea>? PassagensAereas { get; set; }


    }
}

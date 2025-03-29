using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Models;
using System;

namespace Sistemapassagemaerea.Data

{


    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Companhia_Aerea> Companhia_Aereas { get; set; }
        public DbSet<TelefoneCliente> TelefonesCliente { get; set; }
        public DbSet<Tripulante> Tripulantes { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<PassagemAerea> PassagensAereas { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<AssistenteDeVoo> AssistentesDeVoo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=myuser;Password=mypassword");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chave composta para TelefoneCliente
            modelBuilder.Entity<TelefoneCliente>()
                .HasKey(t => new { t.CpfCliente, t.Telefone });

            // Relacionamento entre Passageiro e Companhia_Aerea através de PassagemAerea
            modelBuilder.Entity<PassagemAerea>()
                .HasKey(pa => new { pa.CpfPassageiro, pa.CodigoCompanhiaAerea }); // Definindo a chave composta

            // Relacionamento 1:N de Passageiro com PassagemAerea
            modelBuilder.Entity<PassagemAerea>()
                .HasOne(pa => pa.Passageiro) // PassagemAerea tem um Passageiro
                .WithMany(p => p.PassagensAereas) // Passageiro pode ter várias PassagensAereas
                .HasForeignKey(pa => pa.CpfPassageiro); // A chave estrangeira de Passageiro na PassagemAerea

            // Relacionamento 1:N de Companhia_Aerea com PassagemAerea
            modelBuilder.Entity<PassagemAerea>()
                .HasOne(pa => pa.CompanhiaAerea) // PassagemAerea tem uma Companhia_Aerea
                .WithMany(c => c.PassagensAereas) // Companhia_Aerea pode ter várias PassagensAereas
                .HasForeignKey(pa => pa.CodigoCompanhiaAerea); // A chave estrangeira de Companhia_Aerea na PassagemAerea
        }
    }
}

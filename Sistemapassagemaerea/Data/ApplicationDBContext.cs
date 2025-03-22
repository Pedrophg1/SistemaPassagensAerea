using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Models;
using System;

namespace Sistemapassagemaerea.Data
{

        public class ApplicationDbContext : DbContext
        {
            public DbSet<Cliente> Clientes { get; set; }
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
                modelBuilder.Entity<TelefoneCliente>()
                    .HasKey(t => new { t.CpfCliente, t.Telefone });

                modelBuilder.Entity<Passageiro>()
                    .HasOne(p => p.Cliente)
                    .WithOne(c => c.Passageiro)
                    .HasForeignKey<Passageiro>(p => p.CpfPassageiro);

               
            }
        }

       
}

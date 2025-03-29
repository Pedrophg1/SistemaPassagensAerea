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
        
        public DbSet<Companhia_Aerea> Companhia_Aereas { get; set; }
      
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<PassagemAerea> PassagensAereas { get; set; }
  
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=myuser;Password=mypassword");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
           

           
            modelBuilder.Entity<PassagemAerea>()
                .HasKey(pa => new { pa.CpfPassageiro, pa.CodIATA });

            
            modelBuilder.Entity<PassagemAerea>()
                .HasOne(pa => pa.Passageiro) 
                .WithMany(p => p.PassagensAereas) 
                .HasForeignKey(pa => pa.CpfPassageiro); 

          
            modelBuilder.Entity<PassagemAerea>()
                .HasOne(pa => pa.CompanhiaAerea) 
                .WithMany(c => c.PassagensAereas) 
                .HasForeignKey(pa => pa.CodIATA); 
        }
    }
}

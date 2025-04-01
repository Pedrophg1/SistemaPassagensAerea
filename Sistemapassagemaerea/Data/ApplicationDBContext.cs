using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Data

{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<CompanhiaAerea> CompanhiasAereas { get; set; }

        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<PassagemAerea> PassagensAereas { get; set; }
        public DbSet<Comprovante> Comprovantes { get; set; }
        public object CompanhiaAereas { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Comprovante>()
        .HasKey(c => c.CodigoPassagem);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }

}

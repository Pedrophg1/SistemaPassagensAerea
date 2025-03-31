using Microsoft.EntityFrameworkCore;
using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Data

{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<CompanhiaAerea> CompanhiasAereas { get; set; }

        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<PassagemAerea> PassagensAereas { get; set; }
        public object CompanhiaAereas { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db_passagemaerea;Username=pedroadmin;Password=@dmin159");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

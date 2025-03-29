using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Data.Configuration;

public class PassageiroConfiguration : IEntityTypeConfiguration<Passageiro>
{
    public void Configure(EntityTypeBuilder<Passageiro> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(p => p.PassagensAereas)
                .WithOne(p => p.Passageiro)
                .HasForeignKey(pa => pa.IdPassageiro);
    }
}

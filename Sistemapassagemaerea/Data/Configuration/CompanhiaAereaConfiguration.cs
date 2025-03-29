using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Data.Configuration;

public class CompanhiaAereaConfiguration : IEntityTypeConfiguration<CompanhiaAerea>
{
    public void Configure(EntityTypeBuilder<CompanhiaAerea> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasMany(p => p.PassagensAereas)
                .WithOne(p => p.CompanhiaAerea)
                .HasForeignKey(pa => pa.IdCompanhiaAerea);
    }
}

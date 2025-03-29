using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemapassagemaerea.Domain;

namespace Sistemapassagemaerea.Data.Configuration;

public class PassagemAereaConfiguration : IEntityTypeConfiguration<PassagemAerea>
{
    public void Configure(EntityTypeBuilder<PassagemAerea> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CodigoPassagem).HasMaxLength(12);

        builder.Property(x => x.ValorPassagem).HasPrecision(12, 2);

        builder.HasOne(p => p.Passageiro)
                .WithMany(p => p.PassagensAereas)
                .HasForeignKey(pa => pa.IdPassageiro);

        builder.HasOne(p => p.CompanhiaAerea)
                .WithMany(p => p.PassagensAereas)
                .HasForeignKey(pa => pa.IdCompanhiaAerea);
    }
}


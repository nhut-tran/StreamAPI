using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAPI.Domain;

namespace StreamAPI.Infrastructure.Database.EntityConfigs;

public class SeasonConfiguration : IEntityTypeConfiguration<Season>
{
    public void Configure(EntityTypeBuilder<Season> builder)
    {

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Number)
            .IsRequired();

        builder.HasMany(s => s.Episodes)
            .WithOne(e => e.Season)
            .HasForeignKey(e => e.SeasonId);

        builder.Navigation(s => s.Episodes)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

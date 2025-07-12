using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAPI.Domain;

namespace StreamAPI.Infrastructure.Database.EntityConfigs;

public class TvShowConfiguration : IEntityTypeConfiguration<TvShow>
{
    public void Configure(EntityTypeBuilder<TvShow> builder)
    {
        builder.HasMany(s => s.Seasons)
            .WithOne(s => s.TvShow)
            .HasForeignKey(s => s.TvShowId);

        builder.Navigation(s => s.Seasons)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

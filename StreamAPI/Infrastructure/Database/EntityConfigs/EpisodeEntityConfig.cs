using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAPI.Domain;

namespace StreamAPI.Infrastructure.Database.EntityConfigs;

public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PlayBackUrl).HasMaxLength(300);
        builder.Property(e => e.Number)
            .IsRequired();

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(255);
    }
}

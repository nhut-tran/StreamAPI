using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAPI.Domain;

namespace StreamAPI.Infrastructure.Database.EntityConfigs;

public class MediaConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.PublicId)
            .IsRequired()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(m => m.PublicId).IsUnique();

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(m => m.Description)
            .IsRequired()
            .HasMaxLength(400);
        
        builder.Property(m => m.Category)
            .HasConversion<string>();
 
        builder.Navigation(nameof(Movie.Genres))
            .UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(nameof(Movie.Seasons))
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}


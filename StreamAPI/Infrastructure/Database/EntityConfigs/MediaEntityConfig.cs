using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAPI.Domain;

namespace StreamAPI.Infrastructure.Database.EntityConfigs;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable("media");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.PublicId)
            .IsRequired()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(m => m.PublicId).IsUnique();

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(m => m.Category)
            .HasConversion<string>();

        builder.HasDiscriminator<Category>("category")
            .HasValue<Movie>(Category.Movie)
            .HasValue<TvShow>(Category.TVShow);

        builder.Navigation(nameof(Media.Genres))
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}


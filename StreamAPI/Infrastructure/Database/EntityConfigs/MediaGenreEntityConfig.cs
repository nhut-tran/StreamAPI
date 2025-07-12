using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAPI.Domain;

namespace StreamAPI.Infrastructure.Database.EntityConfigs;

public class MediaGenreConfiguration : IEntityTypeConfiguration<MediaGenre>
{
    public void Configure(EntityTypeBuilder<MediaGenre> builder)
    {
 
        builder.HasKey(mg => new { mg.MediaId, mg.GenreId });

        builder.Property(mg => mg.AddedAt)
            .IsRequired();

        builder.HasOne(mg => mg.Media)
            .WithMany("Genres") // Refer to `Media.Genres`
            .HasForeignKey(mg => mg.MediaId);

        builder.HasOne(mg => mg.Genre)
            .WithMany("MediaGenres") // Refer to `Genre.MediaGenres`
            .HasForeignKey(mg => mg.GenreId);
    }
}


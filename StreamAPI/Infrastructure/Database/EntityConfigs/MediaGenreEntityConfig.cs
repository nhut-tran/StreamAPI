using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAPI.Domain;

namespace StreamAPI.Infrastructure.Database.EntityConfigs;

public class MediaGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
 
        builder.HasKey(mg => new { mg.MovieId, mg.GenreId });

        builder.Property(mg => mg.AddedAt)
            .IsRequired();

        builder.HasOne(mg => mg.Movie)
            .WithMany(nameof(Movie.Genres))
            .HasForeignKey(mg => mg.MovieId);

        builder.HasOne(mg => mg.Genre)
            .WithMany(nameof(Genre.MovieGenres))
            .HasForeignKey(mg => mg.GenreId);
    }
}


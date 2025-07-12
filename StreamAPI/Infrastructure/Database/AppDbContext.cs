using StreamAPI.Domain;
using StreamAPI.Infrastructure.Database.EntityConfigs;

namespace StreamAPI.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;


public class AppDbContext : DbContext
{
    public DbSet<Media> Media => Set<Media>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<TvShow> TvShows => Set<TvShow>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<MediaGenre> MediaGenres => Set<MediaGenre>();
    public DbSet<Season> Seasons => Set<Season>();
    public DbSet<Episode> Episodes => Set<Episode>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
        // Apply all configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}

using StreamAPI.Domain;
using StreamAPI.Infrastructure.Database.EntityConfigs;

namespace StreamAPI.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;


public class AppDbContext : DbContext
{

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
    public DbSet<Season> Seasons => Set<Season>();
    public DbSet<Episode> Episodes => Set<Episode>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
        // Apply all configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityWithTimeStamp>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.SetCreatedAt();
                    break;
                case EntityState.Modified:
                    entry.Entity.SetUpdatedAt();
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

}

using Microsoft.EntityFrameworkCore;
using StreamAPI.Domain;
using StreamAPI.EndPoint;
using StreamAPI.Infrastructure.Database;

namespace StreamAPI.Features.Movie;

public static class MovieCreate
{
    public record Request(string Title, string Description,  int ReleaseYear, Category Category, IEnumerable<int> Genres);
    
    public class Endpoint : IAppEndpoint
    {
        public int Version { get; } = ApiVersion.V1;

        public RouteHandlerBuilder MapEndpoint(IEndpointRouteBuilder builder)
        {
            return builder.MapPost(MediaPath.Create, async (Request request, AppDbContext dbContext) =>
            {
                var genres = await dbContext.Genres.Where(g => request.Genres.Contains(g.Id)).ToListAsync();
                
                var movie = new Domain.Movie(request.Title, request.ReleaseYear, request.Description, request.Category, genres);
                
                await dbContext.Movies.AddAsync(movie);
                
                Results.Ok("OK");
            });

        }
    }
}
   
using StreamAPI.EndPoint;

namespace StreamAPI.Features.Media;

public static class MediaCreate
{
    public record Request(string Title, string Description);
    public record Response(string Title, string Description);
    public class Handler : IAppEndpoint
    {
        public int Version { get; } = 1;

        public RouteHandlerBuilder MapEndpoint(IEndpointRouteBuilder builder)
        {
            return builder.MapGet(MediaPath.Create, () =>
            {
                Results.Ok("OK");
            }).WithOpenApi();
        }
        
    }
    public class HandlerV2 : IAppEndpoint
    {
        public int Version { get; } = 2;

        public RouteHandlerBuilder MapEndpoint(IEndpointRouteBuilder builder)
        {
            return builder.MapGet(MediaPath.Create, () =>
            {
                Results.Ok("OK");
            }).WithOpenApi();
        }
        
    }
}
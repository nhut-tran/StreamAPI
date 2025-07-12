using Asp.Versioning;

namespace StreamAPI.EndPoint;

public interface IAppEndpoint
{
    int Version { get; }
    public RouteHandlerBuilder MapEndpoint(IEndpointRouteBuilder builder);
}
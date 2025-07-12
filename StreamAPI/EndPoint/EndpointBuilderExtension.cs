using Asp.Versioning;
using Asp.Versioning.Builder;
using Asp.Versioning.Conventions;
using StreamAPI.Domain;
using StreamAPI.Features;

namespace StreamAPI.EndPoint;

public static class EndpointBuilderExtension
{
    public static WebApplication AddEndPoints(this WebApplication app)
    {
        var endpoints = typeof(FeatureAssemblyReference).Assembly.GetTypes()
            .Where(x => x is { IsAbstract: false, IsClass: true } && typeof(IAppEndpoint).IsAssignableFrom(x))
            .Select(Activator.CreateInstance).Cast<IAppEndpoint>().ToList();
        
        var versions = endpoints.Select(x => x.Version).Distinct().ToArray();
        var apiVersionSet = app.CreateApiVersionSet(versions);
        
        foreach (var endpoint in endpoints)
        {
            endpoint
                .MapEndpoint(app)
                .WithApiVersionSet(apiVersionSet)
                .MapToApiVersion(endpoint.Version);
        }
        
        return app;
    }

    private static ApiVersionSet CreateApiVersionSet(this WebApplication app, int[] versions)
    {
        var apiVersionSetBuilder = app.NewApiVersionSet();
        foreach (var version in versions)
        {
            apiVersionSetBuilder.HasApiVersion(version);
        }
        return apiVersionSetBuilder.Build();
    }

}
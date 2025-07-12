using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StreamAPI.EndPoint;

public class SwaggerGenOptionWithApiVersion : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerGenOptionWithApiVersion(IApiVersionDescriptionProvider provider)
    {
        _provider =  provider;
    }
    public void Configure(SwaggerGenOptions options)
    {
    
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, new OpenApiInfo() { Title = $"StreamAPI v{description.ApiVersion}", Version = description.ApiVersion.ToString() });
        }
    }
    
}
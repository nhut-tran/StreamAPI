using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Asp.Versioning.Builder;
using FFMpegCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StreamAPI.EndPoint;
using StreamAPI.Infrastructure.Database;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<SwaggerGenOptionWithApiVersion>();
builder.Services.AddDbContext<AppDbContext>(bd => bd.UseNpgsql(builder.Configuration.GetConnectionString("Default")).UseSnakeCaseNamingConvention());
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader()
       // new HeaderApiVersionReader("X-Api-Version")
       );
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});
var app = builder.Build();
app.AddEndPoints();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(op =>
    {
        var provider = app.DescribeApiVersions();
        foreach (var description in provider)
        {
            
            op.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{description.GroupName}");
           
        }
    });
}

app.UseHttpsRedirection();


app.Run();

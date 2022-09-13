using Projeto01.Services.Api.Configurations;
using Projeto01.Services.Api.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ApplicationConfig.AddApplicationConfig(builder);
DomainConfig.AddDomainConfig(builder);
RepositoryConfig.AddRepositoryConfig(builder);
CacheConfig.AddCacheConfig(builder);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
SwaggerSetup.AddSwaggerSetup(builder);
CorsSetup.AddCorsSetup(builder);
JwtSetup.AddJwtSetup(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
SwaggerSetup.UseSwaggerSetup(app);
CorsSetup.UseCorsSetup(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
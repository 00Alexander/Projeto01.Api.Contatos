using Microsoft.Extensions.Options;
using Projeto01.Infra.Cache.MongoDB.Contexts;
using Projeto01.Infra.Cache.MongoDB.Interfaces;
using Projeto01.Infra.Cache.MongoDB.Persistence;

namespace Projeto01.Services.Api.Configurations
{
    /// <summary>
    /// Classe para configuração de injeção de dependencia dos componentes
    /// das camadas de cache do sistema.
    /// </summary>
    public static class CacheConfig
    {
        public static void AddCacheConfig(WebApplicationBuilder builder)
        {

            var mongoDBSettings = new MongoDBSettings();

            //capturando os parametros do 'appsettings.json'
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (builder.Configuration.GetSection("MongoDBSettings"))
                .Configure(mongoDBSettings);

            //mapeamento de injeção de dependência
            builder.Services.AddSingleton(mongoDBSettings);
            builder.Services.AddSingleton<MongoDBContext>();

            builder.Services.AddTransient<IContatosPersistence, ContatosPersistence>();


        }

    }
}

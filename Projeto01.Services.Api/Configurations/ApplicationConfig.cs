using MediatR;
using Projeto01.Application.Interfaces;
using Projeto01.Application.Services;

namespace Projeto01.Services.Api.Configurations
{
    public static class ApplicationConfig
    {
        /// <summary>
        /// Classe para configuração de injeção de dependencia dos componentes
        /// das camadas de aplicação do sistema.
        /// </summary>
        public static void AddApplicationConfig(WebApplicationBuilder builder)
        {

            builder.Services.AddTransient<IContatoAppService, ContatoAppService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        }


    }
}

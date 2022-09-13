using Projeto01.Domain.Interfaces;
using Projeto01.Domain.Services;

namespace Projeto01.Services.Api.Configurations
{
    public class DomainConfig
    {
        /// <summary>
        /// Classe para configuração de injeção de dependencia dos componentes
        /// das camadas de domain do sistema.
        /// </summary>
        public static void AddDomainConfig(WebApplicationBuilder builder)
        {

            builder.Services.AddTransient<IContatoDomainService, ContatoDomainService>();
           
        }
    }
}

using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Services.Api.Tests.Helpers
{
    public class TestsHelper
    {
        public static string _accessToken
            => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoic2VyZ2lvLmNvdGlAZ21haWwuY29tIiwibmJmIjoxNjU4MzUyOTE4LCJleHAiOjE2NTgzNzQ1MTgsImlhdCI6MTY1ODM1MjkxOH0.VIR6f88WWT9TbeFho7ZwsOhm4rmOngafXWLDNXTqE7U";
        /// <summary>
        /// Executando a API e criando um objeto Client HTTP
        /// </summary>
        public static HttpClient CreateClient()
        {
            var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();

            //adicionar o TOKEN no objeto HttpClient
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
           
            return client;
        }

        /// <summary>
        /// Método para serializar objetos C# em JSON para envio de serviços de API
        /// </summary>
        public static StringContent CreateContent<TRequest>(TRequest request)
        {
            return new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Método para deserializar o retorno de uma API (JSON) para objeto C#
        /// </summary>
        public static TResponse CreateResponse<TResponse>(HttpResponseMessage message)
        {
            return JsonConvert.DeserializeObject<TResponse>
                (message.Content.ReadAsStringAsync().Result);
        }

    }
}

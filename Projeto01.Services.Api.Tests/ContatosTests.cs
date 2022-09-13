using Bogus;
using FluentAssertions;
using Projeto01.Application.Commands;
using Projeto01.Application.Model;
using Projeto01.Infra.Cache.MongoDB.Models;
using Projeto01.Services.Api.Tests.Helpers;
using System.Net;

namespace Projeto01.Services.Api.Tests
{
    public class ContatosTests
    {
        private readonly string _endpoint;

        public ContatosTests()
        {
            _endpoint = "/api/contatos";
        }

        [Fact]
        public async Task<ContatoDTO> Contatos_Post_Returns_Ok()
        {
            var faker = new Faker("pt_BR");

            var command = new ContatoCreateCommand
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email.ToLower(),
                Telefone = faker.Person.Phone
            };

            var client = TestsHelper.CreateClient();
            var result = await client.PostAsync(_endpoint, TestsHelper.CreateContent(command));

            result.StatusCode.Should().Be(HttpStatusCode.Created);

            return TestsHelper.CreateResponse<ContatoDTO>(result);

        }

        [Fact]
        public async Task Contatos_Puts_Returns_Ok()
        {
            var contato = await Contatos_Post_Returns_Ok();

            var faker = new Faker("pt_BR");

            var command = new ContatoUpdateCommand
            {
              Id = contato.Id,
                Nome = faker.Person.FullName,
                Email = faker.Person.Email.ToLower(),
                Telefone = faker.Person.Phone
            };

            var client = TestsHelper.CreateClient();
            var result = await client.PutAsync(_endpoint, TestsHelper.CreateContent(command));

            result.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Contatos_Delete_Returns_Ok()
        {
            //cadastrando um contato
            var contato = await Contatos_Post_Returns_Ok();

            var client = TestsHelper.CreateClient();
            var result = await client.DeleteAsync($"{_endpoint}/{contato.Id}");

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Contatos_GetAll_Returns_Ok()
        {
            var client = TestsHelper.CreateClient();
            var result = await client.GetAsync($"{_endpoint}/0/10");

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            //capturando os contatos obtidos da API
            var response = TestsHelper.CreateResponse<List<ContatosModel>>(result);
            response.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Contatos_GetById_Returns_Ok()
        {
            //cadastrando um contato
            var contato = await Contatos_Post_Returns_Ok();

            var client = TestsHelper.CreateClient();
            var result = await client.GetAsync($"{_endpoint}/{contato.Id}");

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            //capturando o contato obtido da API
            var response = TestsHelper.CreateResponse<ContatosModel>(result);
            response.Should().NotBeNull();
        }

    }
}
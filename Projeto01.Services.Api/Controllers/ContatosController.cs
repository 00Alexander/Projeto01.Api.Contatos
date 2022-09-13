using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Commands;
using Projeto01.Application.Interfaces;

namespace Projeto01.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoAppService _contatoAppService;

        public ContatosController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContatoCreateCommand command)
        {
            try
            {
                var contato = await _contatoAppService.Create(command);
                return StatusCode(201, contato); //Created!
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Errors);  //Bad Request!    
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message }); //Bad Request!
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message }); //Internal Server Erro!
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ContatoUpdateCommand command)
        {
            try
            {
                return StatusCode(200, await _contatoAppService.Update(command)); //OK!
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Errors);  //Bad Request!    
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message }); //Bad Request!
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message }); //Internal Server Erro!
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var command = new ContatoDeleteCommand { Id = id };

                var contato = await _contatoAppService.Delete(command);
                return StatusCode(200, contato); //OK!
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message }); //Bad Request!
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message }); //Internal Server Erro!
            };
        }

        [HttpGet("{page}/{limit}")]
        public IActionResult GetAll (int page, int limit)
        {
            try
            {
                var contatos = _contatoAppService.GetAll(page, limit);
                if (contatos.Count == 0)
                    return NoContent();

                return StatusCode(200, contatos);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var contato = _contatoAppService.GetById(id);
                if (contato == null)
                    return NoContent();

                return StatusCode(200, contato);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }

        }
    }
}

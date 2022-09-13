using MediatR;
using Projeto01.Application.Commands;
using Projeto01.Application.Interfaces;
using Projeto01.Application.Model;
using Projeto01.Domain.Interfaces;
using Projeto01.Infra.Cache.MongoDB.Interfaces;
using Projeto01.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Services
{
    public class ContatoAppService : IContatoAppService
    {
        private readonly IMediator _mediator;
        private readonly IContatosPersistence _contatosPersistence;

        public ContatoAppService(IMediator mediator, IContatosPersistence contatosPersistence)
        {
            _mediator = mediator;
            _contatosPersistence = contatosPersistence;
        }

        public async Task<ContatoDTO> Create(ContatoCreateCommand command)
        {
           return await _mediator.Send(command);
        }
        public async Task<ContatoDTO> Update(ContatoUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ContatoDTO> Delete(ContatoDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public List<ContatosModel> GetAll(int page, int limit)
        {
            return _contatosPersistence.GetAll(page, limit);
        }

        public ContatosModel GetById(Guid id)
        {
           return _contatosPersistence.GetById(id);
        }

        public void Dispose()
        {
           GC.SuppressFinalize(this);
        }

        
    }
}

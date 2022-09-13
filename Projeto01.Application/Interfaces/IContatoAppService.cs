using Projeto01.Application.Commands;
using Projeto01.Application.Model;
using Projeto01.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Interfaces
{
    public interface IContatoAppService : IDisposable
    {
        Task<ContatoDTO> Create(ContatoCreateCommand command);
        Task<ContatoDTO> Update(ContatoUpdateCommand command);
        Task<ContatoDTO> Delete(ContatoDeleteCommand command);

        List<ContatosModel> GetAll(int page, int limit);
        ContatosModel GetById(Guid id);
    }
}

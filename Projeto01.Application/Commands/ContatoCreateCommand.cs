using MediatR;
using Projeto01.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Commands
{
    /// <summary>
    /// Dados do comando de cadastro de contatos
    /// </summary>
    public class ContatoCreateCommand : IRequest<ContatoDTO>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }

}

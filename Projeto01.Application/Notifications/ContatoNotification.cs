using MediatR;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Notifications
{
    /// <summary>
    /// Classe para armazenar as notificações relacionadas a contato
    /// </summary>
    public class ContatoNotification : INotification
    {
        /// <summary>
        /// Define a ação que estamos recebendo para Contato
        /// </summary>
        public ActionNotification Action { get; set; }

        /// <summary>
        /// Entidade com os dados da notificação
        /// </summary>
        public Contato Contato { get; set; }

    }
}

using AutoMapper;
using MediatR;
using Projeto01.Application.Notifications;
using Projeto01.Infra.Cache.MongoDB.Interfaces;
using Projeto01.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.NotificationHandlers
{
    /// <summary>
    /// Classe para capturar notificações da entidade Contato (CREATED, UPDATED e DELETED)
    /// </summary>
    public class ContatoNotificationHandler : INotificationHandler<ContatoNotification>
    {
        private readonly IContatosPersistence _contatosPersistence;
        private readonly IMapper _mapper;

        public ContatoNotificationHandler(IContatosPersistence contatosPersistence, IMapper mapper)
        {
            _contatosPersistence = contatosPersistence;
            _mapper = mapper;
        }

        public Task Handle(ContatoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var model = _mapper.Map<ContatosModel>(notification.Contato);

                switch (notification.Action)
                {
                    case ActionNotification.Created:
                        _contatosPersistence.Create(model);
                        break;

                    case ActionNotification.Updated:
                        _contatosPersistence.Update(model);
                        break;

                    case ActionNotification.Deleted:
                        _contatosPersistence.Delete(model);
                        break;
                }


            });
        }
    }
}

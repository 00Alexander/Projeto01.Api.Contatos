using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Interfaces;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class ContatoRepository : BaseRepository<Contato, Guid>, IContatoRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        //base passa o parametro para o construtor da superclass herdada.
        public ContatoRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Contato GetByEmail(string email)
            => _sqlServerContext.Contatos
                .AsNoTracking()
                .FirstOrDefault(c => c.Email.Equals(email));

        public Contato GetByTelefone(string telefone)
        => _sqlServerContext.Contatos
            .AsNoTracking()
            .FirstOrDefault(c => c.Telefone.Equals(telefone));
    }
}

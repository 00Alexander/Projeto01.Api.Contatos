using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Core.Interfaces;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    /// <summary>
    /// Classe genérica para implementaçõ do repositório
    /// </summary>
    public abstract class BaseRepository<TEntity, Tkey> : IRepository<TEntity, Tkey>
        where TEntity : class
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //método construtor (injeção de dependência)
        protected BaseRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public async virtual Task CreateAsync(TEntity entity)
        {
            _sqlServerContext.Set<TEntity>().Add(entity);
            await _sqlServerContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            await _sqlServerContext.SaveChangesAsync();

        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            _sqlServerContext.Set<TEntity>().Remove(entity);
            await _sqlServerContext.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(int page, int limit)
            => await _sqlServerContext.Set<TEntity>()
                    .AsNoTracking() //para não ficar rastreando o objeto e parar a concorrencia
                    .Skip(page)
                    .Take(limit)
                    .ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(Tkey id)
        {
            var result = await _sqlServerContext.Set<TEntity>().FindAsync(id);

            _sqlServerContext.Entry(result).State = EntityState.Detached; //para não ficar rastreando o objeto e parar a concorrencia

            return result;
        }


        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}

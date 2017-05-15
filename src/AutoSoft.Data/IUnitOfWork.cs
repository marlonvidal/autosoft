using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data
{
    public interface IUnitOfWork : IDisposable
    {
        TEntity GetById<TEntity, TKey>(TKey id)
            where TEntity : class, IEntity<TKey>;

        IQueryable<TEntity> QueryableFor<TEntity>()
            where TEntity : class;

        IEnumerable<TEntity> QueryableFor<TEntity>(string sql, Dictionary<string, object> parameters = null)
            where TEntity : class;

        TEntity Add<TEntity>(TEntity entity)
            where TEntity : class;

        TEntity Update<TEntity>(TEntity entity)
            where TEntity : class;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class;

        void SaveChanges();
    }
}

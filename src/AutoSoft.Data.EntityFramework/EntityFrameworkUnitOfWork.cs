using AutoSoft.Data;
using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.EntityFramework
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly DbContext _dbContext;

        public EntityFrameworkUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            var result = _dbContext.Set<TEntity>().Add(entity);
            return result;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public TEntity GetById<TEntity, TKey>(TKey id) where TEntity : class, IEntity<TKey>
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> QueryableFor<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> QueryableFor<TEntity>(string sql, Dictionary<string, object> parameters = null) where TEntity : class
        {
            DbRawSqlQuery<TEntity> query = null;

            if (parameters != null)
                query = _dbContext.Database.SqlQuery<TEntity>(sql, parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToList());
            else
                query = _dbContext.Database.SqlQuery<TEntity>(sql, null);

            return query.ToList();
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var msg = "";

                foreach (var eve in e.EntityValidationErrors)
                {
                    msg += $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:\n";

                    foreach (var ve in eve.ValidationErrors)
                        msg += $"- Property: { ve.PropertyName }, Error: { ve.ErrorMessage }\n";
                }

                throw new ValidationException(msg);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _dbContext.Dispose();

            disposed = true;
        }
    }
}

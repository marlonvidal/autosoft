using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AutoSoft.Data
{
    public abstract class BaseRepository<TEntity, TKeyType> : IRepository<TEntity, TKeyType>
        where TEntity : class, IEntity<TKeyType>
        where TKeyType : class
    {
        protected readonly IUnitOfWork _uow;

        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IList<TEntity> FindBy(Expression<Func<TEntity, bool>> condition)
        {
            if (condition == null)
                return null;

            return _uow.QueryableFor<TEntity>().Where(condition).ToList();
        }

        public TEntity FindById(TKeyType id)
        {
            var entity = _uow.GetById<TEntity, TKeyType>(id);
            return entity;
        }

        public IList<TEntity> FindAll()
        {
            return _uow.QueryableFor<TEntity>().ToList();
        }

        public TEntity Add(TEntity entity)
        {
            var result = _uow.Add(entity);
            return result;
        }

        public TEntity Update(TEntity entity)
        {
            var result = _uow.Update(entity);
            return result;
        }

        public void Delete(TEntity entity)
        {
            _uow.Delete(entity);
        }

        public void Save()
        {
            _uow.SaveChanges();
        }
    }
}

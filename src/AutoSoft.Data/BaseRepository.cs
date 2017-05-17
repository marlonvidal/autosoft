using AutoSoft.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AutoSoft.Data
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
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

        public IList<TEntity> FindAll()
        {
            return _uow.QueryableFor<TEntity>().ToList();
        }

        public TEntity Add(TEntity entity)
        {
            var result = _uow.Add(entity);
            _uow.SaveChanges();
            return result;
        }

        public TEntity Update(TEntity entity)
        {
            var result = _uow.Update(entity);
            _uow.SaveChanges();
            return result;
        }

        public void Delete(TEntity entity)
        {
            _uow.Delete(entity);
            _uow.SaveChanges();
        }

        public void Save()
        {
            _uow.SaveChanges();
        }
    }
}

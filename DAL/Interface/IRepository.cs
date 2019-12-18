using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IQueryable<TEntity> GetMany(Expression<Func<TEntity,bool>> expression);
        TEntity GetById(int id);
        void Add(TEntity entity);
        void AddRange(ICollection<TEntity> entities);
        void UpdateRange(ICollection<TEntity> entities);
        void Update(TEntity entity);
        void DeleteById(int id);
        void Delete(TEntity entity);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);
    }
}

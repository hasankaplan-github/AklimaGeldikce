using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AklimaGeldikce.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(Guid? id);
        void Update(TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        void Create(TEntity entity);
        void UnDelete(Guid id);
        void UnDelete(TEntity entity);
        void UnDelete(Expression<Func<TEntity, bool>> where);
        void Drop(Guid id);
        void Drop(TEntity entity);
        void Drop(Expression<Func<TEntity, bool>> where);
        IList<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        IList<TEntity> GetAllDeleted(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IList<TEntity>> GetAllDeletedAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<PagedList<TEntity>> GetAllDeletedAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<PagedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(Expression<Func<TEntity, bool>> where);

        Task<IList<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IList<TEntity>> GetManyDeletedAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        IList<TEntity> GetMany(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        IList<TEntity> GetManyDeleted(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        void BulkInsert(IList<TEntity> entities);
    }
}

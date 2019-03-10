using AklimaGeldikce.Repositories;
using AklimaGeldikce.Repositories.UnitOfWork;
using AklimaGeldikce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AklimaGeldikce.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>, IDisposable
        where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IBaseRepository<TEntity> repository;

        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = unitOfWork.GetRepository<TEntity>();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.unitOfWork.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TEntity GetById(Guid? id)
        {
            return this.repository.GetById(id);
        }

        public void Update(TEntity entity)
        {
            this.repository.Update(entity);
            this.unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            this.repository.Delete(id);
            this.unitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this.repository.Delete(entity);
            this.unitOfWork.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            this.repository.Delete(where);
            this.unitOfWork.SaveChanges();
        }

        public void Create(TEntity entity)
        {
            this.repository.Add(entity);
            this.unitOfWork.SaveChanges();
        }

        public void UnDelete(Guid id)
        {
            this.repository.UnDelete(id);
            this.unitOfWork.SaveChanges();
        }

        public void UnDelete(TEntity entity)
        {
            this.repository.UnDelete(entity);
            this.unitOfWork.SaveChanges();
        }

        public void UnDelete(Expression<Func<TEntity, bool>> where)
        {
            this.repository.UnDelete(where);
            this.unitOfWork.SaveChanges();
        }

        public void Drop(Guid id)
        {
            this.repository.Drop(id);
            this.unitOfWork.SaveChanges();
        }

        public void Drop(TEntity entity)
        {
            this.repository.Drop(entity);
            this.unitOfWork.SaveChanges();
        }

        public void Drop(Expression<Func<TEntity, bool>> where)
        {
            this.repository.Drop(where);
            this.unitOfWork.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return this.repository.Get(where);
        }

        public IList<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return this.repository.GetAll(orderBy);
        }

        public IList<TEntity> GetAllDeleted(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return this.repository.GetAllDeleted(orderBy);
        }

        public async Task<PagedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await this.repository.GetAllAsync(pageIndex, pageSize, orderBy);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return this.repository.Exists(predicate);
        }

        public async Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await this.repository.GetAllAsync(orderBy);
        }

        public async Task<IList<TEntity>> GetAllDeletedAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await this.repository.GetAllDeletedAsync(orderBy);
        }

        public async Task<PagedList<TEntity>> GetAllDeletedAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await this.repository.GetAllDeletedAsync(pageIndex, pageSize, orderBy);
        }

        public async Task<IList<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await this.repository.GetManyAsync(where, orderBy);
        }

        public async Task<IList<TEntity>> GetManyDeletedAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await this.repository.GetManyDeletedAsync(where, orderBy);
        }

        public IList<TEntity> GetMany(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return this.repository.GetMany(where, orderBy);
        }

        public IList<TEntity> GetManyDeleted(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return this.repository.GetManyDeleted(where, orderBy);
        }

        public void BulkInsert(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.repository.Add(entity);
            }
            this.unitOfWork.SaveChanges();
        }

        public void BulkUpdate(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.repository.Update(entity);
            }
            this.unitOfWork.SaveChanges();
        }
    }
}

using AklimaGeldikce.Entities;
using System;

namespace AklimaGeldikce.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //AppDbContext appDbContext { get; set; }

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}

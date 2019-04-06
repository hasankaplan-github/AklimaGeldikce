using AklimaGeldikce.Entities;
using System;

namespace AklimaGeldikce.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //AppDbContext appDbContext { get; set; }
        INotificationRepository NotificationRepository { get; }
        IUserRepository UserRepository { get; }
        IMenuItemRepository MenuItemRepository { get; }
        IRoleMenuItemRepository RoleMenuItemRepository { get; }

        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}

using System;
using AklimaGeldikce.DbContext;
using AklimaGeldikce.Entities;

namespace AklimaGeldikce.Repositories.UnitOfWork
{
    /// <summary>
    /// EntityFramework için oluşturmuş olduğumuz UnitOfWork.
    /// EFRepository'de olduğu gibi bu şekilde tasarlamamızın ana sebebi ise veritabanına independent(bağımsız) bir durumda kalabilmek. Örneğin MongoDB için ise ilgili provider'ı aracılığı ile MongoDBOfWork tasarlayabiliriz.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        //public AppDbContext appDbContext { get; set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException("dbContext can not be null.");

            // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.
            //this.appDbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }

        #region IUnitOfWork Members
        public IRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : BaseEntity
        {
            return new Repository<TEntity>(this.appDbContext);
        }

        public int SaveChanges()
        {
            int retVal = 0;
            try
            {
                using (var transaction = this.appDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        retVal = this.appDbContext.SaveChanges();
                        transaction.Commit();
                        return retVal;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                //TODO:Logging
                throw;
            }

            /*
            try
            {
                // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return appDbContext.SaveChanges();
            }
            catch
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
            */
        }
        #endregion

        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    appDbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

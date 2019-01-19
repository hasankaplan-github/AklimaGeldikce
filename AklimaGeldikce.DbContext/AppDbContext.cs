using Microsoft.EntityFrameworkCore;

namespace AklimaGeldikce.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AklimaGeldikce.Entities.Comment> Comment { get; set; }
        public DbSet<AklimaGeldikce.Entities.User> User { get; set; }
        public DbSet<AklimaGeldikce.Entities.AppLevelLog> AppLevelLog { get; set; }
        public DbSet<AklimaGeldikce.Entities.Role> Role { get; set; }
        public DbSet<AklimaGeldikce.Entities.Request> Request { get; set; }
        public DbSet<AklimaGeldikce.Entities.RoleRequest> RoleRequest { get; set; }
        public DbSet<AklimaGeldikce.Entities.RoleUser> RoleUser { get; set; }
        public DbSet<AklimaGeldikce.Entities.Category> Category { get; set; }
        public DbSet<AklimaGeldikce.Entities.CategoryArticle> CategoryArticle { get; set; }
        public DbSet<AklimaGeldikce.Entities.MenuItem> MenuItem { get; set; }
        public DbSet<AklimaGeldikce.Entities.Article> Article { get; set; }
        public DbSet<AklimaGeldikce.Entities.RoleMenuItem> RoleMenuItem { get; set; }
        public DbSet<AklimaGeldikce.Entities.ArticleStatus> ArticleStatus { get; set; }
        public DbSet<AklimaGeldikce.Entities.ArticleStatusArticleStatus> ArticleStatusArticleStatus { get; set; }
        public DbSet<AklimaGeldikce.Entities.ArticleOperation> ArticleOperation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AklimaGeldikce.Entities.AppLevelLog>()
                .HasOne(l => l.Owner)
                .WithMany(u => u.AppLevelLogs)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<AklimaGeldikce.Entities.Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AklimaGeldikce.Entities.Comment>()
                .HasOne(c => c.OwnerArticle)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<AklimaGeldikce.Entities.Comment>()
                .HasOne(c => c.Owner)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<AklimaGeldikce.Entities.MenuItem>()
                .HasOne(m => m.ParentMenuItem)
                .WithMany(m => m.ChildMenuItems)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AklimaGeldikce.Entities.Article>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Articles)
                .OnDelete(DeleteBehavior.SetNull);


            /*many to many relationship*/
            modelBuilder.Entity<AklimaGeldikce.Entities.ArticleStatusArticleStatus>()
               .HasOne(a=>a.ParentArticleStatus)
               .WithMany(b => b.ParentArticleStatusArticleStatuses)
               .HasForeignKey(x=>x.ParentArticleStatusId)
               .OnDelete(DeleteBehavior.Restrict);

            /*many to many relationship*/
            modelBuilder.Entity<AklimaGeldikce.Entities.ArticleStatusArticleStatus>()
              .HasOne(a => a.ChildArticleStatus)
              .WithMany(b => b.ChildArticleStatusArticleStatuses)
              .HasForeignKey(x => x.ChildArticleStatusId)
              .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}

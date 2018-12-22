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
        public DbSet<AklimaGeldikce.Entities.CategoryPost> CategoryPost { get; set; }
        public DbSet<AklimaGeldikce.Entities.MenuItem> MenuItem { get; set; }
        public DbSet<AklimaGeldikce.Entities.Post> Post { get; set; }
        public DbSet<AklimaGeldikce.Entities.RoleMenuItem> RoleMenuItem { get; set; }
    }
}

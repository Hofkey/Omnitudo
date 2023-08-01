using Microsoft.EntityFrameworkCore;
using Omnitudo.Core.Entities;

namespace Omnitudo.Infrastructuur.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostFile> PostFiles { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}

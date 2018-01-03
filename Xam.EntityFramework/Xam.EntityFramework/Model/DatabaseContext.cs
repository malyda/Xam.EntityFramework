using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model.Entity;

namespace Xam.EntityFramework.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
        private string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}

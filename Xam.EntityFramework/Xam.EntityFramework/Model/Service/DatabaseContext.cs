using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model.DatabaseHelpers;
using Xam.EntityFramework.Model.Entity;

namespace Xam.EntityFramework.Model.Service
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
        private readonly string _databasePath;

        public readonly EfService Methods;
        public DatabaseContext() : base()
        {
            _databasePath = DatabasePathProvider.DatabasePath();
            
            // Ensure database is created
            base.Database.EnsureCreated();

            Methods = new EfService(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}

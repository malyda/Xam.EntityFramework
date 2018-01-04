using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model.DatabaseHelpers;
using Xam.EntityFramework.Model.Entity;

namespace Xam.EntityFramework.Model.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
        private readonly string _databasePath;

        public readonly DatabaseMethods Methods;
        public DatabaseContext()
        {
            _databasePath = DatabasePathProvider.DatabasePath();
            
            // Ensure database is created
            base.Database.EnsureCreated();

            Methods = new DatabaseMethods(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}

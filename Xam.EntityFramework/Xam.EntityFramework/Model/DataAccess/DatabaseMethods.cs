using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model.Entity;

namespace Xam.EntityFramework.Model.DataAccess
{
    public class DatabaseMethods
    {
        private readonly DatabaseContext _dbContext;

        public DatabaseMethods(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Article GetArticle(int id)
        {
            return _dbContext.Articles.Find(id);
        }

        public Blog GetBlog(int id)
        {
            return _dbContext.Blogs
                .Where(b => b.BlogId == id)
                .Include(b => b.Articles)
                .FirstOrDefault();
        }

        public Blog InsertNewBlogAndArticleIntoDatabase()
        {
            _dbContext.Add(new Article() {Content = "Standalone article"});

            Blog blog = new Blog()
            {
                Rating = 5,
                Url = "https://UrlOfBlog.com",
                Articles = new List<Article>()
                {
                    new Article() {Content = "First Article"},
                    new Article() {Content = "Second Article"}
                }
            };


            // Insert Data
            _dbContext.Add(blog);
            _dbContext.SaveChanges();
            return blog;
        }

        public List<Blog> GetAllBlogsFromDatabase()
        {
            return _dbContext.Blogs.ToList();
        }

        /// <summary>
        /// Get Blog with id = 1
        /// Add Article with id = 1 to selected Blog
        /// </summary>
        public void AddExistingArticleToExistingBlog()
        {
            // Get Blog with id = 1
            var blog = _dbContext.Methods.GetBlog(1);
            if (blog.Articles != null)
            {
                // Get Article with id = 1
                var existingArticle = _dbContext.Methods.GetArticle(1);
                // Add Article to selected blog
                blog.Articles.Add(existingArticle);

                _dbContext.SaveChanges();
            }
        }
    }
}
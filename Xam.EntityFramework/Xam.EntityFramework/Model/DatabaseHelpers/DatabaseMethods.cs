using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model.Entity;

namespace Xam.EntityFramework.Model.DatabaseHelpers
{
    public class DatabaseMethods
    {
        private readonly DatabaseContext _db;

        public DatabaseMethods(DatabaseContext db)
        {
            this._db = db;
        }

        public Article GetArticle(int id)
        {
            return _db.Articles.Find(id);
        }

        public Blog GetBlog(int id)
        {
            return _db.Blogs
                .Where(b => b.BlogId == id)
                .Include(b => b.Articles)
                .FirstOrDefault();
        }

        public void InsertIntoDatabase()
        {
            _db.Add(new Article() {Content = "modified"});

            // Insert Data
            _db.Add(new Blog()
            {
                Rating = 5,
                Url = "https://xamarinhelp.com",
                Articles = new List<Article>()
                {
                    new Article() {Content = "1"},
                    new Article() {Content = "3"}
                }
            });
            _db.SaveChanges();

        }

        public List<Blog> GetAllBlogsFromDatabase()
        {
            return _db.Blogs.ToList();
        }

        /// <summary>
        /// Get Blog with id = 1
        /// Add Article with id = 1 to selected Blog
        /// </summary>
        public void AddExistingArticleToExistingBlog()
        {
            // Get Blog with id = 1
            var blog = _db.Methods.GetBlog(1);
            if (blog.Articles != null)
            {
                // Get Article with id = 1
                var existingArticle = _db.Methods.GetArticle(1);
                // Add Article to selected blog
                blog.Articles.Add(existingArticle);

                _db.SaveChanges();
            }
        }


    }
}

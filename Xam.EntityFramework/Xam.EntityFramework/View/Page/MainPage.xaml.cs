using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model;
using Xam.EntityFramework.Model.Entity;
using Xamarin.Forms;

namespace Xam.EntityFramework.View.Page
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Debug.WriteLine(App.DB());


            List<Blog> itemSource;

            // Create Database & Tables
            using (var db = new DatabaseContext(App.DB()))
            {
                // Ensure database is created
                db.Database.EnsureCreated();

                db.Add( new Article() { Content = "modified" });

                // Insert Data
                db.Add(new Blog() {
                    Rating = 5,
                    Url = "https://xamarinhelp.com",
                    Articles = new List<Article>(){
                    new Article(){ Content = "1"}
                    ,new Article(){ Content = "3"}
                    }
                });
                db.SaveChanges();
                itemSource = db.Blogs.ToList();

                var blog = GetBlog(1, db);
                if (blog.Articles != null)
                { 
                    var existingArticle = GetArticle(1,db);
                    blog.Articles.Add(existingArticle);
       
                    db.SaveChanges();
                }
                // Retreive Data
      
            }
         
        

            listView.ItemsSource = itemSource;
        }

        public Article GetArticle(int id, DatabaseContext db)
        {
            return db.Articles.Find(id);
        }

        public Blog GetBlog(int id, DatabaseContext db)
        {

            return db.Blogs
                       .Where(b => b.BlogId == id)
                       .Include(b => b.Articles)
                       .FirstOrDefault();
            // return db.Blogs.Find(id);
        }
    }
}

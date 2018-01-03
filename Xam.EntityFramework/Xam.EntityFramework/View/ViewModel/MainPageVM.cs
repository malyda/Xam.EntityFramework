using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model;
using Xam.EntityFramework.Model.Entity;

namespace Xam.EntityFramework.View.ViewModel
{
    public class MainPageVm
    {
        public ObservableCollection<Blog> Blogs { get; set; }

        public MainPageVm()
        {
            using (DatabaseContext dbContext = new DatabaseContext(App.DB()))
            {
                dbContext.Methods.InsertIntoDatabase();

                Blogs =new ObservableCollection<Blog>(dbContext.Methods.GetAllBlogsFromDatabase());

                dbContext.Methods.AddExistingArticleToExistingBlog();
            }
        }
    }
}

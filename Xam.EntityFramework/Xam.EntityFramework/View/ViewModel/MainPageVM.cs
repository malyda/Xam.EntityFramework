using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model;
using Xam.EntityFramework.Model.DatabaseHelpers;
using Xam.EntityFramework.Model.Entity;
using Xamarin.Forms;

namespace Xam.EntityFramework.View.ViewModel
{
    public class MainPageVm
    {
        public ObservableCollection<Blog> Blogs { get; set; } = new ObservableCollection<Blog>();


        public ICommand AddBlogCommand { protected set; get; }

        public MainPageVm()
        {
            AddBlogCommand = new Command(InsertNewBlogAndArticleIntoDatabase);

            DisplayAllBlogsFromDatabase();
        }

        private void InsertNewBlogAndArticleIntoDatabase()
        {
            Blogs.Add(App.EfService.InsertNewBlogAndArticleIntoDatabase());
        }

        /// <summary>
        /// Get all Blogs from database
        /// </summary>
        private void DisplayAllBlogsFromDatabase()
        {
            Blogs = new ObservableCollection<Blog>(App.EfService.GetAllBlogsFromDatabase());
        }
    }
}

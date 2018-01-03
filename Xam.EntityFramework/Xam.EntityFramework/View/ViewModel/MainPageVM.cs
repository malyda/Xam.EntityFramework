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
    public class MainPageVm : INotifyPropertyChanged
    {
        public ObservableCollection<Blog> Blogs { get; set; } = new ObservableCollection<Blog>();

        private bool _isLoading = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddBlogCommand { protected set; get; }

        public MainPageVm()
        {
            AddBlogCommand = new Command(async () => { await Task.Run(() => InsertNewBlogAndArticleIntoDatabase()); });

            DisplayAllBlogsFromDatabase();
        }

        private void InsertNewBlogAndArticleIntoDatabase()
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                Blogs.Add(dbContext.Methods.InsertNewBlogAndArticleIntoDatabase());
            }
        }

        /// <summary>
        /// Get all Blogs from database
        /// </summary>
        private async void DisplayAllBlogsFromDatabase()
        {
            IsLoading = true;
            await Task.Run(() =>
            {
                using (DatabaseContext dbContext = new DatabaseContext())
                {
                    // Get all Blogs from database
                    foreach (var blog in dbContext.Methods.GetAllBlogsFromDatabase())
                    {
                        Blogs.Add(blog);
                    }

                    IsLoading = false;
                }
            });
        }
    }
}

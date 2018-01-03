using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model;
using Xam.EntityFramework.Model.Entity;
using Xam.EntityFramework.View.ViewModel;
using Xamarin.Forms;

namespace Xam.EntityFramework.View.Page
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Debug.WriteLine(App.DB());       
        }    
    }
}

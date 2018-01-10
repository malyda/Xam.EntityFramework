using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xam.EntityFramework.Model;
using Xam.EntityFramework.Model.DatabaseHelpers;
using Xam.EntityFramework.Model.Entity;
using Xam.EntityFramework.View.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


/*
 *     <ContentPage.BindingContext>
        <local:View.ViewModel.MainPageVm/>
    </ContentPage.BindingContext>
 */
namespace Xam.EntityFramework.View.Page
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();      
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new MainPageVm();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.EntityFramework;
using Xam.EntityFramework.Model.DatabaseHelpers;
using Xam.EntityFramework.Model.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xam.EntityFramework
{
	public partial class App : Application
	{
       public static EfService EfService = new DatabaseContext().Methods;
        public App()
	    {
	        InitializeComponent();
	       
            MainPage = new View.Page.MainPage();
	    }

	    protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

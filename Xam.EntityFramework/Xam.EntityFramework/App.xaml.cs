﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam.EntityFramework;
using Xam.EntityFramework.Model.DatabaseHelpers;
using Xamarin.Forms;

namespace Xam.EntityFramework
{
	public partial class App : Application
	{
		public App ()
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

        public static string DB()
        {
          return  DependencyService.Get<IDatabasePathHelper>().GetDatabasePath("entityFrameworkDatabase.db");
        }
	}
}

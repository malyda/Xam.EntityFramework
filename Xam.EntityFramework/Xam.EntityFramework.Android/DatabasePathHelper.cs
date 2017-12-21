using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xam.EntityFramework.Droid;
using Xam.EntityFramework;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePathHelper))]
namespace Xam.EntityFramework.Droid
{
    class DatabasePathHelper : IDatabasePathHelper
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
        }
    }
}
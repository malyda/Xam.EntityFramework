using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.EntityFramework.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePathHelper))]
namespace Xam.EntityFramework.UWP
{
    class DatabasePathHelper : IDatabasePathHelper
    {
        public string GetDatabasePath(string filename)
        {
           return Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "exrin.db");

        }
    }
}

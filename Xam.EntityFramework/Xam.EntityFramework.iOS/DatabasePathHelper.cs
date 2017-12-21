using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xam.EntityFramework.iOS;
using Xam.EntityFramework;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePathHelper))]
namespace Xam.EntityFramework.iOS
{
    class DatabasePathHelper : IDatabasePathHelper
    {
        public string GetDatabasePath(string filename)
        {
           return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", filename;

        }
    }
}
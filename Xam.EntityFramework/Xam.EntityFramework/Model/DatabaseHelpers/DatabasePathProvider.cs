using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xam.EntityFramework.Model.DatabaseHelpers
{
    class DatabasePathProvider
    {
        public static string DatabasePath()
        {
            return  DependencyService.Get<IDatabasePathHelper>().GetDatabasePath("entityFrameworkDatabase.db");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Xam.EntityFramework.Model.DatabaseHelpers
{
    public interface IDatabasePathHelper
    {
       string GetDatabasePath(string filename);
    }
}

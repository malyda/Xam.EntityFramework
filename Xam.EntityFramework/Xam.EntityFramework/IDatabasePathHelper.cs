using System;
using System.Collections.Generic;
using System.Text;

namespace Xam.EntityFramework
{
    public interface IDatabasePathHelper
    {
       string GetDatabasePath(string filename);
    }
}

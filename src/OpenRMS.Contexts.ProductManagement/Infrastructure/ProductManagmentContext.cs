using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure
{
    public class SqlProductManagmentContext : /*  DBContext , */ IDisposable
    {
        public void SaveChanges()
        {
            throw new NotImplementedException(nameof(SaveChanges));
        }

        public void Dispose()
        {
            throw new NotImplementedException(nameof(Dispose));
        }
    }
}
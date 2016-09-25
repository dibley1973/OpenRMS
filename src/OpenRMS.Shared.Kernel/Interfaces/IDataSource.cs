using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IDataSource<T> where T : DataTransferObject
    {
        IEnumerable<T> GetAll();
        T GetForId(Guid id);
        IQueryable<T> Query();
    }
}

using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    /// <summary>
    /// An interface that provides access to a data source.
    /// </summary>
    /// <typeparam name="TDataTransferObject">The type of DTO returned by the data source.</typeparam>
    public interface IDataSource<TDataTransferObject> where TDataTransferObject : DataTransferObject
    {
        IEnumerable<TDataTransferObject> GetAll();
        TDataTransferObject GetForId(Guid id);
        IQueryable<TDataTransferObject> Query();
    }
}

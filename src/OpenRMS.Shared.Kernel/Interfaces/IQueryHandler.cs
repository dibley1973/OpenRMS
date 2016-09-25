using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IQueryHandler<T, R> where T : Query where R : class
    {
        R Execute(T query);
    }
}

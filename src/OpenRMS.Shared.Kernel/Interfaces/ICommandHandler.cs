using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface ICommandHandler<T, R> where T : Command where R : Entity
    {
        R Execute(T command);
    }
}

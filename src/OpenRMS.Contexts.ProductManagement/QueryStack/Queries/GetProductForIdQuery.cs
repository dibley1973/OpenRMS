using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.QueryStack.Queries
{
    public class GetProductForIdQuery : Query
    {
        public Guid Id { get; set; }
    }
}

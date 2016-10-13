using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.QueryStack.Queries
{
    public class GetProductForIdQuery : Query
    {
        public Guid Id { get; set; }
    }
}

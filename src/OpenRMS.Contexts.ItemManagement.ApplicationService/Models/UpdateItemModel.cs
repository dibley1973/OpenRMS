using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Models
{
    public class UpdateItemModel
    {
        public Guid Id { get; set; } //TODO: Currently here to support V2 implementation that doesn't use intermediate commands
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

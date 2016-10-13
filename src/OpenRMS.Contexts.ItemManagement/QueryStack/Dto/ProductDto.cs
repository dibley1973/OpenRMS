using System;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.QueryStack.Dto
{
    public class ProductDto : DataTransferObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductAttributeDto> Attributes { get; set; }
    }
}

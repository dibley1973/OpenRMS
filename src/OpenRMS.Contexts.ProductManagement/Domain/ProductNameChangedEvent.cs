using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Domain
{
    public class ProductNameChangedEvent : IDomainEvent
    {
        public string Name { get; }

        public ProductNameChangedEvent(string name)
        {
            Name = name;
        }
    }
}
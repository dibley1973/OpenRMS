using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.Domain.Entities
{
    public class ItemCode: ValueObject<ItemCode>
    {
        public static readonly ItemCode Empty = new ItemCode(string.Empty);
        public string Value { get; private set; }

        private ItemCode() { }

        public ItemCode(string value)
        {
            if(value==null) throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        protected override bool EqualsCore(ItemCode other)
        {
            return Value==other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}

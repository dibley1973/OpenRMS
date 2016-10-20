using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Shared.Kernel.BaseClasses
{
    public class BusinessCode : ValueObject<BusinessCode>
    {
        public static readonly BusinessCode Empty = new BusinessCode(string.Empty);
        public string Value { get; private set; }

        private BusinessCode()
        {
        }

        public BusinessCode(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        protected override bool EqualsCore(BusinessCode other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator BusinessCode(string value)
        {
            return new BusinessCode(value);
        }
    }
}

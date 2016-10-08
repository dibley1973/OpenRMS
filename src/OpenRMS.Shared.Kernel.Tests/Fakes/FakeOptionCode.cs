using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Tests.Fakes
{
    public class FakeOptionCode : ValueObject<FakeOptionCode>
    {
        private readonly string _styleCode;
        private readonly string _colourcode;

        public FakeOptionCode(string styleCode, string colourcode)
        {
            if (string.IsNullOrWhiteSpace(styleCode)) throw new ArgumentNullException(nameof(styleCode));
            if (string.IsNullOrWhiteSpace(colourcode)) throw new ArgumentNullException(nameof(colourcode));

            _styleCode = styleCode;
            _colourcode = colourcode;
        }

        public string StyleCode => _styleCode;

        public string Colourcode => _colourcode;

        public string OptionCode => string.Concat(StyleCode, ":", Colourcode);

        /// <summary>
        /// Represents an empty option code.
        /// </summary>
        /// <value>
        /// The empty option code.
        /// </value>
        public FakeOptionCode EmptyOptionCode => new FakeOptionCode("0", "0");

        protected override bool EqualsCore(FakeOptionCode other)
        {
            return StyleCode == other.StyleCode
                   && Colourcode == other.Colourcode;
        }

        protected override int GetHashCodeCore()
        {
            const int hashCodePrimeNumber = 313;
            unchecked
            {
                int hashCode = StyleCode.GetHashCode();
                hashCode = (hashCode * hashCodePrimeNumber) ^ Colourcode.GetHashCode();
                return hashCode;
            }
        }
    }
}
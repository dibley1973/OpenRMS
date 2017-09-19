//-----------------------------------------------------------------------
// <copyright file="FakeOptionCode.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Fakes
{
    using System;
    using BaseClasses;

    /// <summary>
    /// Represents a fake option code for testing purposes only
    /// </summary>
    public class FakeOptionCode : ValueObject<FakeOptionCode>
    {
        private readonly string _styleCode;
        private readonly string _colourcode;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeOptionCode"/> class.
        /// </summary>
        /// <param name="styleCode">The style code.</param>
        /// <param name="colourcode">The colourcode.</param>
        /// <exception cref="ArgumentNullException">
        /// styleCode
        /// or
        /// colourcode
        /// </exception>
        public FakeOptionCode(string styleCode, string colourcode)
        {
            if (string.IsNullOrWhiteSpace(styleCode)) throw new ArgumentNullException(nameof(styleCode));
            if (string.IsNullOrWhiteSpace(colourcode)) throw new ArgumentNullException(nameof(colourcode));

            _styleCode = styleCode;
            _colourcode = colourcode;
        }

        /// <summary>
        /// Gets the style code.
        /// </summary>
        /// <value>
        /// The style code.
        /// </value>
        public string StyleCode => _styleCode;

        /// <summary>
        /// Gets the colourcode.
        /// </summary>
        /// <value>
        /// The colourcode.
        /// </value>
        public string Colourcode => _colourcode;

        /// <summary>
        /// Gets the option code.
        /// </summary>
        /// <value>
        /// The option code.
        /// </value>
        public string OptionCode => string.Concat(StyleCode, ":", Colourcode);

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" />, is equal to this instance
        /// of <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1" />.  This member should be overridden in the derived class.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(FakeOptionCode other)
        {
            return StyleCode == other.StyleCode
                   && Colourcode == other.Colourcode;
        }

        /// <summary>
        /// Returns a hash code for this instance. This member should be overridden in the derived class.
        /// </summary>
        /// <returns>
        /// Returns a hash code for this instance
        /// </returns>
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
//-----------------------------------------------------------------------
// <copyright file="FakeValueObject.cs" company="Chesil Media">
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
    using Guards;

    /// <summary>
    /// Represents a fake value object for testing purposes only
    /// </summary>
    public class FakeValueObject : ValueObject<FakeValueObject>
    {
        private readonly string _code;
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeValueObject"/> class.
        /// </summary>
        /// <param name="code">The style code.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">code or name</exception>
        public FakeValueObject(string code, string name)
        {
            Ensure.IsNotNullEmptyOrWhiteSpace(code, (ArgumentName)nameof(code));
            Ensure.IsNotNullEmptyOrWhiteSpace(name, (ArgumentName)nameof(name));

            _code = code;
            _name = name;
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code => _code;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => _name;

        /// <summary>
        /// Gets the code and name concatenated.
        /// </summary>
        /// <value>The code and name.</value>
        public string CodeAndName => string.Concat(Code, ":", Name);

        /// <summary>
        /// Determines whether the specified <see cref="FakeValueObject"/>, is equal to this instance.
        /// </summary>
        /// <param name="other">The other <see cref="FakeValueObject"/>.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="FakeValueObject"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(FakeValueObject other)
        {
            return Code == other.Code && Name == other.Name;
        }

        /// <summary>
        /// Returns a hash code for this instance. This member should be overridden in the derived class.
        /// </summary>
        /// <returns>Returns a hash code for this instance</returns>
        protected override int GetHashCodeCore()
        {
            const int hashCodePrimeNumber = 313;
            unchecked
            {
                int hashCode = Code.GetHashCode();
                hashCode = (hashCode * hashCodePrimeNumber) ^ Name.GetHashCode();
                return hashCode;
            }
        }
    }
}
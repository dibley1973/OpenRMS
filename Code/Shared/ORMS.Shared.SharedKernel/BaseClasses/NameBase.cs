//-----------------------------------------------------------------------
// <copyright file="NameBase.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.BaseClasses
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The base class for name obejcts to inherit from
    /// </summary>
    /// <seealso cref="ValueObject{NameBase}"/>
    [DebuggerDisplay("Value:{" + nameof(Value) + "}")]
    public abstract class NameBase : ValueObject<NameBase>
    {
        /// <summary>
        /// The maximum number of characters this instance can be. This shoudl be overridden by any
        /// sub classes.
        /// </summary>
        protected const byte MaximumCharacterLength = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="NameBase"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if value is null, empty or white space.
        /// </exception>
        protected NameBase(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/>, is equal to this instance
        /// of <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1"/>.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the specified <see
        /// cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(NameBase other)
        {
            return Value == other.Value;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>Returns a hash code for this instance</returns>
        protected override int GetHashCodeCore()
        {
            int initialPrimeNumber = 47;
            int multiplierPrimeNumber = 71;

            // Overflow is fine, just wrap
            unchecked
            {
                int hash = initialPrimeNumber;

                hash = (hash * multiplierPrimeNumber) + Value.GetHashCode();

                return hash;
            }
        }
    }
}
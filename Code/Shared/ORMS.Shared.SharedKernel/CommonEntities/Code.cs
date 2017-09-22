//-----------------------------------------------------------------------
// <copyright file="Code.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.CommonEntities
{
    using System;
    using BaseClasses;

    /// <summary>
    /// Represents a code
    /// </summary>
    /// <seealso cref="ValueObject{Code}" />
    public class Code : ValueObject<Code>
    {
        /// <summary>
        /// The maximum number of characters this instance can be.
        /// </summary>
        public const byte MaximumCharacterLength = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="Code" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        private Code(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets an empty special case <see cref="Code"/>.
        /// </summary>
        /// <value>
        /// The empty.
        /// </value>
        public static Code Empty => CreateInternal(string.Empty);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Code"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator Code(string value)
        {
            return Create(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string" /> to <see cref="Code" />.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator string(Code code)
        {
            return code.Value;
        }

        /// <summary>
        /// Creates a <see cref="Code"/> using the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Code"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown value is null, empty or whitespace</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if value length exceeds <see cref="MaximumCharacterLength"/>.
        /// </exception>
        public static Code Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            if (value.Length > MaximumCharacterLength) throw new ArgumentOutOfRangeException(nameof(value), $"Must not exceed {MaximumCharacterLength} characters in length");

            return CreateInternal(value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" />, is equal to this instance
        /// of <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1" />.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(Code other)
        {
            return Value == other.Value;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// Returns a hash code for this instance
        /// </returns>
        protected override int GetHashCodeCore()
        {
            return GetType().ToString().GetHashCode() * Value.GetHashCode() ^ 307;
        }

        /// <summary>
        /// internal method to create a <see cref="Code"/> object.
        /// Warning: This function bypasses argument validation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Code"/>.</returns>
        private static Code CreateInternal(string value)
        {
            return new Code(value);
        }
    }
}
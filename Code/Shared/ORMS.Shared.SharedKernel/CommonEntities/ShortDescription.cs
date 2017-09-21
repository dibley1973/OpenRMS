//-----------------------------------------------------------------------
// <copyright file="ShortDescription.cs" company="Chesil Media">
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
    /// Represents a short description
    /// </summary>
    /// <seealso cref="ValueObject{ShortDescription}" />
    public class ShortDescription : ValueObject<ShortDescription>
    {
        /// <summary>
        /// The maximum number of characters this instance can be.
        /// </summary>
        public const byte MaximumCharacterLength = 255;

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortDescription" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">Thrown if value is null, empty or white space.</exception>
        public ShortDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            if (value.Length > MaximumCharacterLength) throw new ArgumentOutOfRangeException(nameof(value), $"Must not exceed {MaximumCharacterLength} characters in length");

            _value = value;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="ShortDescription"/> class from being created.
        /// </summary>
        private ShortDescription()
        {
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value => _value;

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="ShortDescription"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator ShortDescription(string value)
        {
            return new ShortDescription(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string" /> to <see cref="ShortDescription" />.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator string(ShortDescription description)
        {
            return description.Value;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" />, is equal to this instance
        /// of <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1" />.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(ShortDescription other)
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
    }
}
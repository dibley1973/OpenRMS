//-----------------------------------------------------------------------
// <copyright file="Name.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.CommonEntities
{
    using System;
    using Amplifiers;
    using BaseClasses;
    using Constants.ResultErrorKeys;

    /// <summary>
    /// Represents a name
    /// </summary>
    /// <seealso cref="ValueObject{Name}" />
    public class Name : ValueObject<Name>
    {
        /// <summary>
        /// The maximum number of characters this instance can be.
        /// </summary>
        public const byte MaximumCharacterLength = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="Name" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">Thrown if value is null, empty or white space.</exception>
        private Name(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets an empty special case <see cref="Name"/>.
        /// </summary>
        /// <value>
        /// The empty.
        /// </value>
        public static Name Empty => CreateInternal(string.Empty);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Name"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator Name(string value)
        {
            var nameResult = Create(value);

            if (nameResult.IsFailure) throw new InvalidCastException(nameResult.Error);

            return nameResult.Value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string" /> to <see cref="Name" />.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Name" /> class using.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Name"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if value is null, empty or white space.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if value length exceeds <see cref="MaximumCharacterLength"/>.
        /// </exception>
        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Result.Fail<Name>(NameErrorKeys.NameIsNullEmptyOrwhiteSpace);
            if (value.Length > MaximumCharacterLength) return Result.Fail<Name>(NameErrorKeys.NameIsTooLong);

            return Result.Ok(CreateInternal(value));
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object" />, is equal to this instance
        /// of <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1" />.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="T:ORMS.Shared.SharedKernel.BaseClasses.ValueObject`1" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(Name other)
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
        /// Internal method to create a <see cref="Name"/> object.
        /// Warning: This function bypasses argument validation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Name"/>.</returns>
        private static Name CreateInternal(string value)
        {
            return new Name(value);
        }
    }
}
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
    using System.Diagnostics;
    using Amplifiers;
    using BaseClasses;
    using Constants.ResultErrorKeys;

    /// <summary>
    /// Represents a name
    /// </summary>
    /// <seealso cref="ValueObject{Name}"/>
    [DebuggerDisplay("Value:{" + nameof(Value) + "}")]
    public class Name : NameBase // ValueObject<Name>
    {
        /// <summary>
        /// The maximum number of characters this instance can be.
        /// </summary>
        public new const byte MaximumCharacterLength = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if value is null, empty or white space.
        /// </exception>
        private Name(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Gets an empty special case <see cref="Name"/>.
        /// </summary>
        /// <value>The empty.</value>
        public static Name Empty => CreateInternal(string.Empty);

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Name"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Name(string value)
        {
            var nameResult = Create(value);

            if (nameResult.IsFailure) throw new InvalidCastException(nameResult.Error);

            return nameResult.Value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Name"/> to <see cref="string"/> .
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        /// <summary>
        /// If the specified value is valid then creates and returns a new instance of the <see
        /// cref="Name"/> class using the value and wraps it in an Ok <see cref="Result{name}"/>;
        /// otherwise creates a fail <see cref="Result{Name}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Result{Name}"/>.</returns>
        /// Thrown if value length exceeds
        /// <see cref="MaximumCharacterLength"/>
        /// .
        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Result.Fail<Name>(NameErrorKeys.IsNullEmptyOrWhiteSpace);
            if (value.Length > MaximumCharacterLength) return Result.Fail<Name>(NameErrorKeys.IsTooLong);

            return Result.Ok(CreateInternal(value));
        }

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
        protected bool EqualsCore(Name other)
        {
            return base.EqualsCore(other);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>Returns a hash code for this instance</returns>
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
//-----------------------------------------------------------------------
// <copyright file="Identity.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.CommonValueObjects
{
    using Amplifiers;
    using BaseClasses;
    using Constants.ErrorKeys;

    /// <summary>
    /// Represents an idendity
    /// </summary>
    /// <seealso cref="BaseClasses.ValueObject{Identity}"/>
    public class Identity : ValueObject<Identity>
    {
        /// <summary>
        /// The minimum value an identity can be
        /// </summary>
        public const int MinimumValue = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Identity"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        private Identity(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets a not set special case <see cref="Identity"/>.
        /// </summary>
        /// <value>The empty.</value>
        public static Identity NotSet => CreateInternal(default(int));

        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        /// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
        public bool HasValue => Value != default(int);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; }

        /// <summary>
        /// If the specified value is valid then creates and returns a new instance of the <see
        /// cref="Name"/> class using the value and wraps it in an Ok <see cref="Result{Identity}"/>;
        /// otherwise creates a fail <see cref="Result{Identity}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Result{Identity}"/>.</returns>
        public static Result<Identity> Create(int value)
        {
            if (value < MinimumValue) return Result.Fail<Identity>(IdentityErrorKeys.IsLessThanMinimum);

            return Result.Ok(CreateInternal(value));
        }

        /// <summary>
        /// Determines whether the specified <see cref="Identity"/>, is equal to this instance of
        /// <see cref="Identity"/>. This member should be overridden in the derived class.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Identity"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(Identity other)
        {
            return Value == other.Value;
        }

        /// <summary>
        /// Returns a hash code for this instance. This member should be overridden in the derived class.
        /// </summary>
        /// <returns>Returns a hash code for this instance</returns>
        protected override int GetHashCodeCore()
        {
            int initialPrimeNumber = 181;
            int multiplierPrimeNumber = 29;

            // Overflow is fine, just wrap
            unchecked
            {
                int hash = initialPrimeNumber;

                hash = (hash * multiplierPrimeNumber) + Value.GetHashCode();

                return hash;
            }
        }

        /// <summary>
        /// Internal method to create a <see cref="Identity"/> object.
        /// Warning: This function bypasses argument validation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Identity"/>.</returns>
        private static Identity CreateInternal(int value)
        {
            return new Identity(value);
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="ValueObject.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.BaseClasses
{
    using System;

    /// <summary>
    /// Represents the base class that all ValueObjects should inherit from
    /// </summary>
    /// <typeparam name="T">
    /// Defines the <see cref="Type"/> of the "leaf" class which the value object actually is.
    /// </typeparam>
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        /// <summary>
        /// Determines if the first <see cref="ValueObject{T}"/> is equal to the second <see cref="ValueObject{T}"/>.
        /// </summary>
        /// <param name="first">The first <see cref="ValueObject{T}"/> to check.</param>
        /// <param name="second">The second <see cref="ValueObject{T}"/> to check.</param>
        /// <returns>
        /// The result of the operator; <c>true</c> if the two <see cref="ValueObject{T}"/>
        /// objects are equal, otherwise <c>false</c>.
        /// </returns>
        public static bool operator ==(ValueObject<T> first, ValueObject<T> second)
        {
            var firstIsNull = ReferenceEquals(first, null);
            var secondIsNull = ReferenceEquals(second, null);

            var bothAreNull = firstIsNull && secondIsNull;
            if (bothAreNull) return true;

            var atLeastOneIsNull = firstIsNull || secondIsNull;
            if (atLeastOneIsNull) return false;

            return first.Equals(second);
        }

        /// <summary>
        /// Determines if the first <see cref="ValueObject{T}"/> is not equal to the second <see cref="ValueObject{T}"/>.
        /// </summary>
        /// <param name="first">The first <see cref="ValueObject{T}"/> to check.</param>
        /// <param name="second">The second <see cref="ValueObject{T}"/> to check.</param>
        /// <returns>
        /// The result of the operator; <c>true</c> if the two <see cref="ValueObject{T}"/>
        /// objects are not equal, otherwise <c>false</c>.
        /// </returns>
        public static bool operator !=(ValueObject<T> first, ValueObject<T> second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance of <see cref="ValueObject{T}"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        /// Returns <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            var objectIsDifferentType = ReferenceEquals(valueObject, null);
            if (objectIsDifferentType) return false;

            return EqualsCore(valueObject);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance
        /// of <see cref="ValueObject{T}"/>.  This member should be overridden in the derived class.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="ValueObject{T}" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        protected abstract bool EqualsCore(T other);

        /// <summary>
        /// Returns a hash code for this instance. This member should be overridden in the derived class.
        /// </summary>
        /// <returns>Returns a hash code for this instance</returns>
        protected abstract int GetHashCodeCore();
    }
}
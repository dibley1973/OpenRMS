//-----------------------------------------------------------------------
// <copyright file="Maybe.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Amplifiers
{
    using System;
    using Guards;

    /// <summary>
    /// Amplifies any given Type to provide expression of clear intent that the given object may be
    /// an instance or may be nothing.
    /// </summary>
    /// <typeparam name="T">
    /// Indicates the type of the entities identifier. Normally a Long or Guid
    /// </typeparam>
    public struct Maybe<T> : IEquatable<Maybe<T>>
    {
        /// <summary>
        /// Defines the special case "Empty" Maybe
        /// </summary>
        public static readonly Maybe<T> Empty = new Maybe<T>(default(T));

        /// <summary>
        /// Defines the _value
        /// </summary>
        private readonly T _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        private Maybe(T value)
        {
            _value = value;
        }

        /////// <summary>
        /////// Gets an empty maybe.
        /////// </summary>
        /////// <value>The none.</value>
        ////public static Maybe<T> Empty => EmptyMaybe;

        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        /// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
        public bool HasValue => _value != null;

        /// <summary>
        /// Gets a value indicating whether this instance has no value.
        /// </summary>
        /// <value><c>true</c> if this instance has no value; otherwise, <c>false</c>.</value>
        public bool HasNoValue => !HasValue;

        /// <summary>
        /// Gets the value, of this instance has a value to get; otherwise throws an exception.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="InvalidOperationException">
        /// Thrown is this property is accessed when this instance does not have a value.
        /// </exception>
        public T Value
        {
            get
            {
                Ensure.IsNotInvalidOperation(HasValue, "Cannot return value if no value has been set");

                return _value;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from object of type &lt;T&gt; to <see cref="Maybe{T}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }

        /// <summary>
        /// Determines whether the value of the specified <see cref="Maybe{T}"/> is the same as the
        /// specified value
        /// </summary>
        /// <param name="maybe">The maybe.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (maybe.HasNoValue) return false;

            return maybe.Value.Equals(value);
        }

        /// <summary>
        /// Determines whether the value of the specified <see cref="Maybe{T}"/> is not the same as
        /// the specified value
        /// </summary>
        /// <param name="maybe">The maybe.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return !(maybe == value);
        }

        /// <summary>
        /// Determines whether the value of the first specified <see cref="Maybe{T}"/> is the same as
        /// the value of the second specified <see cref="Maybe{T}"/>.
        /// </summary>
        /// <param name="first">The first maybe.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }

        /// <summary>
        /// Determines whether the value of the first specified <see cref="Maybe{T}"/> is not the
        /// same as the value of the second specified <see cref="Maybe{T}"/>.
        /// </summary>
        /// <param name="first">The first maybe.</param>
        /// <param name="second">The second value.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Wraps the specified type in a <see cref="Maybe{T}"/> with the <see cref="Value"/> set to
        /// the specified object.
        /// </summary>
        /// <param name="obj">The object to wrap.</param>
        /// <returns>Returns an instance of a <see cref="Maybe{T}"/> with the type as the value</returns>
        public static Maybe<T> Wrap(T obj)
        {
            return new Maybe<T>(obj);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var objectCanBeWrapped = obj is T;
            if (objectCanBeWrapped)
            {
                obj = Wrap((T)obj);
            }

            var objectIsNotSameType = !(obj is Maybe<T>);
            if (objectIsNotSameType) return false;

            var otherMaybe = (Maybe<T>)obj;
            return Equals(otherMaybe);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Maybe<T> other)
        {
            var bothHaveNoValue = HasNoValue && other.HasNoValue;
            if (bothHaveNoValue) return true;

            var oneHasValueAndOtherDoesNot = HasNoValue || other.HasNoValue;
            if (oneHasValueAndOtherDoesNot) return false;

            return _value.Equals(other._value);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures
        /// like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            if (HasNoValue) return 0;

            return _value.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString()
        {
            if (HasNoValue) return "Value: No-value";

            return $"Value: {Value.ToString()}";
        }
    }
}
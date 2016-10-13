using System;
using System.Collections;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.BaseClasses;
using OpenRMS.Shared.Kernel.Resources;

namespace OpenRMS.Shared.Kernel.Amplifiers
{
    /// <summary>
    /// An amplifier of the the specified <see cref="T"/> which the programmer to specify
    /// that the <see cref="T"/> may or may not be present.
    /// </summary>
    /// <typeparam name="T">The type of the @value.</typeparam>
    /// <typeparam name="TId">The type of the @value's identifier.</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public class Maybe<T> : IEnumerable<T>
        where T : class
    {
        private readonly T _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> class without an @value.
        /// </summary>
        public Maybe() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> class with an @value.
        /// </summary>
        /// <param name="value">
        /// The @value to construct the instance with. If a null reference @value is provided as the 
        /// then the instance is treated as not having an @value;
        /// </param>
        public Maybe(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the @value if it exists .
        /// </summary>
        /// <value>
        /// The @value.
        /// </value>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if there is no @value to return.</exception>
        public T Value
        {
            get
            {
                if (HasValue()) return _value;

                throw new InvalidOperationException(string.Format(ExceptionMessages.NoEntityToReturn, typeof(T), nameof(HasValue)));
            }
        }

        /// <summary>
        /// Returns an enumerator that will yield the <see cref="T"/> if one exists or nothing if it does not.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to yield the <see cref="T"/> if it exists.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (HasValue())
            {
                yield return _value;
            }
        }

        /// <summary>
        /// Returns an enumerator that will yield the <see cref="T"/> if one exists.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> value that can be used to will 
        /// yield the <see cref="T"/> if one exists.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Determines whether this instance has value.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has value; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValue()
        {
            return _value != null;
        }

        /// <summary>
        /// Casts an value of <see cref="T"/> to an value of type <see cref="Maybe{T}"/>
        /// </summary>
        /// <param name="value">The <see cref="T"/> to cast from</param>
        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }

        /// <summary>
        /// Casts an value of type <see cref="Maybe{T}"/> to an value of type <see cref="T"/>
        /// </summary>
        /// <param name="maybe">The <see cref="Maybe{T}"/> to cast from</param>
        public static implicit operator T(Maybe<T> maybe)
        {
            return maybe.HasValue() 
                ? maybe.Value 
                : null;
        }
    }
}

namespace OpenRMS.Shared.Kernel.BaseClasses
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance of <see cref="ValueObject{T}"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null)) return false;

            return EqualsCore(valueObject);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance 
        /// of <see cref="ValueObject{T}"/>.  This member should be overridden in the derived class.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        protected abstract bool EqualsCore(T other);

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
        /// Returns a hash code for this instance. This member should be overridden in the derived class.
        /// </summary>
        /// <returns></returns>
        protected abstract int GetHashCodeCore();

        /// <summary>
        /// Determines if the first <see cref="ValueObject{T}"/> is equal to the second <see cref="ValueObject{T}"/>.
        /// </summary>
        /// <param name="a">The first <see cref="ValueObject{T}"/> to check.</param>
        /// <param name="b">The first <see cref="ValueObject{T}"/> to check.</param>
        /// <returns>
        /// The result of the operator; <c>true</c> if the two <see cref="ValueObject{T}"/> 
        /// objects are equal, otherwise <c>false</c>.
        /// </returns>
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        /// <summary>
        /// Determines if the first <see cref="ValueObject{T}"/> is not equal to the second <see cref="ValueObject{T}"/>.
        /// </summary>
        /// <param name="a">The first <see cref="ValueObject{T}"/> to check.</param>
        /// <param name="b">The first <see cref="ValueObject{T}"/> to check.</param>
        /// <returns>
        /// The result of the operator; <c>true</c> if the two <see cref="ValueObject{T}"/> 
        /// objects are not equal, otherwise <c>false</c>.
        /// </returns>
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
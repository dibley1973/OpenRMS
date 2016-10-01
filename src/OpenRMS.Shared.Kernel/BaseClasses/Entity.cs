using System;

namespace OpenRMS.Shared.Kernel.BaseClasses
{
    /// <summary>
    /// The base class which all entities should inherit from
    /// </summary>
    /// <typeparam name="TId">
    /// Indicates the type of the entities identifier. Normally a Long or Guid
    /// </typeparam>
    public abstract class Entity<TId>
        where TId : struct
    {
        protected Entity(TId id)
        {
            if (id.Equals(default(TId))) throw new ArgumentNullException(nameof(id));

            Id = id;
        }

        /// <summary>
        /// Gets the identity for the entity
        /// </summary>
        public TId Id { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<TId>;

            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            if (Id.Equals(default(TId)) || other.Id.Equals(default(TId))) return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Returns the hash code for this entity
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}

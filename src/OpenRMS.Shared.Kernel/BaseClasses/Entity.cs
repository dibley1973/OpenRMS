using System;

namespace OpenRMS.Shared.Kernel.BaseClasses
{
    /// <summary>
    /// The base class which all entities should inherit from
    /// </summary>
    /// <typeparam name="TId">Indicates the type of the entities identifier. Normally a Long or Guid.</typeparam>
    public abstract class Entity<TId>
        where TId : struct
    {
       /// <summary>
        /// Gets the identity for the entity
        /// </summary>
        public TId Id { get; private set; }

        /// <summary>
        /// Parameterless contructor.
        /// </summary>
        protected Entity() { }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        protected Entity(TId id)
        {
            if (id.Equals(default(TId))) throw new ArgumentNullException(nameof(id));

            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Entity<TId>;

            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            if (Id.Equals(default(TId)) || other.Id.Equals(default(TId))) return false;

            return Id.Equals(other.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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

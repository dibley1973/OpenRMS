namespace ORMS.Shared.SharedKernel.Entities
{
    /// <summary>
    /// The base class which all entities should inherit from
    /// </summary>
    /// <typeparam name="T">
    /// Indicates the type of the entities identifier. Normally a Long or Guid
    /// </typeparam>
    public abstract class Entity<T>
        where T : struct 
    {
        protected Entity(T id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identity for the entity
        /// </summary>
        public T Id { get; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<T>;

            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            if (Id.Equals(default(T)) || other.Id.Equals(default(T))) return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
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

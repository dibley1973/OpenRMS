using System;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    /// <summary>
    /// An interface that provides access to a repository of entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the entity's identifier.</typeparam>
    public interface IRepository<TEntity, TId> 
        where TEntity : Entity<TId>
        where TId : struct
    {
        IEnumerable<TEntity> GetAll();
        Maybe<TEntity> GetForId(TId id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

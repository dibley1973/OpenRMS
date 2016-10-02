using System;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of teh entity</typeparam>
    /// <typeparam name="TId">The type of the entity's identifier</typeparam>
    public interface IRepository<TEntity, TId> 
        where TEntity : Entity<TId>
        where TId : struct
    {
        IEnumerable<TEntity> GetAll();
        Maybe<TEntity, TId> GetForId(TId id);

        //IQueryable<Entity> Query();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        //void Save();
    }
}

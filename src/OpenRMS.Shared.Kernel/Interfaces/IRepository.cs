using System;
using System.Collections.Generic;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IRepository<TEntity> 
        //where TEntity : Entity<TId>
        //where TId : struct
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetForId(Guid id);
        //IQueryable<Entity> Query();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        //void Save();
    }
}

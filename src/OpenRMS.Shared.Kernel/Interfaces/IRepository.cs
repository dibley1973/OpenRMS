using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IRepository<Entity> 
        //where TEntity : Entity<TId>
        //where TId : struct
    {
        IEnumerable<Entity> GetAll();
        Entity GetForId(Guid id);
        IQueryable<Entity> Query();
        void Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        //void Save();
    }
}

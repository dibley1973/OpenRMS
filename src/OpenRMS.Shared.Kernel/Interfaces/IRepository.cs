using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetForId(Guid id);
        IQueryable<T> Query();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}

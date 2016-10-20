using System;
using OpenRMS.Contexts.LocationManagement.Domain;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;

namespace OpenRMS.Contexts.LocationManagement.Domain.Interfaces
{
    /// <summary>
    /// An interface that provides access to a repository of products.
    /// </summary>
    public interface ILocationRepository : IRepository<Location>
    {
        Maybe<Location> GetForName(string name);
    }
}
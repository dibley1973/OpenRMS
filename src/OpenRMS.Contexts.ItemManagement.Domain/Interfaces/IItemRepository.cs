using System;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;

namespace OpenRMS.Contexts.ItemManagement.Domain.Interfaces
{
    /// <summary>
    /// An interface that provides access to a repository of products.
    /// </summary>
    public interface IItemRepository : IRepository<Item, Guid>
    {
        Maybe<Item> GetForName(string name);
    }
}
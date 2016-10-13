using System;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.Interfaces
{
    /// <summary>
    /// An interface that provides access to a repository of products.
    /// </summary>
    public interface IItemRepository : IRepository<Item, Guid>
    {
        Maybe<Item> GetForName(string name);
    }
}
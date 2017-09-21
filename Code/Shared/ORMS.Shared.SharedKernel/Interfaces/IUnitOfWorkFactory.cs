//-----------------------------------------------------------------------
// <copyright file="IUnitOfWorkFactory.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Interfaces
{
    /// <summary>
    /// An interface that provides access to a unit of work factory.
    /// </summary>
    /// <typeparam name="TUnitOfWork">The type of unit of work that the factory can create.</typeparam>
    public interface IUnitOfWorkFactory<out TUnitOfWork>
        where TUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Creates the unit of work.
        /// </summary>
        /// <returns>Returns a typed UnitOfWork.</returns>
        TUnitOfWork CreateUnitOfWork();
    }
}
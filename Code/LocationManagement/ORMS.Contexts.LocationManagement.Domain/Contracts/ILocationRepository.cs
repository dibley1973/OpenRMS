//-----------------------------------------------------------------------
// <copyright file="ILocationRepository.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.LocationManagement.Domain.Contracts
{
    using Entities;
    using Shared.SharedKernel.Amplifiers;

    /// <summary>
    /// An interface that provides access to a repository of locations.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Gets the <see cref="Location"/> for the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A <see cref="Location"/> wrapped in a <see cref="Maybe{Location}"/></returns>
        Maybe<Location> GetForName(string name);
    }
}
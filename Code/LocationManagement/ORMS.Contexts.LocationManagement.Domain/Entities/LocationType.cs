//-----------------------------------------------------------------------
// <copyright file="LocationType.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.LocationManagement.Domain.Entities
{
    using Shared.SharedKernel.BaseClasses;

    /// <summary>
    /// Represents the type of an <see cref="Location"/>
    /// </summary>
    public class LocationType : Entity<int>
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationType"/> class.
        /// </summary>
        /// <param name="id">The identity of the type</param>
        /// <param name="name">The name of the type</param>
        private LocationType(int id, string name)
            : base(id)
        {
            _name = name;
        }

        /// <summary>
        /// Gets a value for the name
        /// </summary>
        public string Name => _name;
    }
}
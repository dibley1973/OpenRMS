//-----------------------------------------------------------------------
// <copyright file="LocationState.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.LocationManagement.Domain.Constants.ResultErrorKeys
{
    using Entities;
    using Shared.SharedKernel.BaseClasses;

    /// <summary>
    /// Represents the state of an <see cref="Location"/>
    /// </summary>
    public class LocationState : Entity<int>
    {
        /// <summary>
        /// Creates an instance of an <see cref="LocationState"/> which represents the "created" state.
        /// </summary>
        public static readonly LocationState Created = new LocationState(1, "Created");

        /// <summary>
        /// Creates an instance of an <see cref="LocationState"/> which represents the "Active" state.
        /// </summary>
        public static readonly LocationState Active = new LocationState(2, "Active");

        /// <summary>
        /// Creates an instance of an <see cref="LocationState"/> which represents the "Deactivated" state.
        /// </summary>
        public static readonly LocationState Deactivated = new LocationState(3, "Deactivated");

        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationState"/> class.
        /// </summary>
        /// <param name="id">The identity of the state</param>
        /// <param name="name">The name of the state</param>
        private LocationState(int id, string name)
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
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
    using Constants.ResultErrorKeys;
    using Shared.SharedKernel.Amplifiers;
    using Shared.SharedKernel.BaseClasses;
    using Shared.SharedKernel.CommonValueObjects;
    using Shared.SharedKernel.Guards;

    /// <summary>
    /// Represents the type of an <see cref="Location"/>
    /// </summary>
    public class LocationType : Entity<int>
    {
        private const string NotSetName = "Not Set";

        private readonly Name _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationType"/> class.
        /// </summary>
        /// <param name="id">The identity of the type</param>
        /// <param name="name">The name of the type</param>
        private LocationType(int id, Name name)
            : base(id)
        {
            _name = name;
        }

        /// <summary>
        /// Gets the default special case not set <see cref="LocationType"/>.
        /// </summary>
        /// <value>The not set.</value>
        public static LocationType NotSet => CreateInternal(Identity.NotSet.Value, (Name)NotSetName);

        /// <summary>
        /// Gets a value for the name
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// If the specified arguments are valid, then creates a new instance of the <see
        /// cref="Location"/> and wraps it in a <see cref="Result"/>. Otherwise returns a fail <see cref="Result{Location}"/>.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns>Returns a <see cref="Result{Location}"/></returns>
        public static Result<LocationType> Create(Identity id, Name name)
        {
            var validationResult = Result.Combine(
                Check.IsNotNull(id, LocationErrorKeys.IdIsNull),
                Check.IsNotNull(name, LocationErrorKeys.NameIsNull));

            return validationResult.IsSuccess
                ? Result.Ok(new LocationType(id.Value, name))
                : Result.Fail<LocationType>(validationResult.Error);
        }

        /// <summary>
        /// Internal method to create a <see cref="LocationType"/> object.
        /// Warning: This function bypasses argument validation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns>Returns a newly constructed <see cref="LocationType"/>.</returns>
        private static LocationType CreateInternal(int id, Name name)
        {
            return new LocationType(id, name);
        }
    }
}
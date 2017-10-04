//-----------------------------------------------------------------------
// <copyright file="Location.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.LocationManagement.Domain.Entities
{
    using System;
    using Constants.ResultErrorKeys;
    using Shared.SharedKernel.Amplifiers;
    using Shared.SharedKernel.BaseClasses;
    using Shared.SharedKernel.CommonEntities;
    using Shared.SharedKernel.Guards;

    /// <summary>
    /// Represents a location.
    /// </summary>
    public class Location : AggregateRoot<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class. Sets the state to <see cref="ORMS.Contexts.LocationManagement.Domain.Entities.LocationState.Created"/>
        /// </summary>
        /// <param name="businessCode">The business businessCode.</param>
        /// <param name="name">The name.</param>
        private Location(Code businessCode, Name name)
            : this(Guid.NewGuid(), businessCode, name, LocationState.Created)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="businessCode">The business businessCode.</param>
        /// <param name="name">The name.</param>
        /// <param name="state">The state.</param>
        private Location(Guid id, Code businessCode, Name name, LocationState state)
            : base(id)
        {
            ChangeBusinessCode(businessCode);
            ChangeName(name);
            ChangeLocationState(state);
        }

        /// <summary>
        /// Gets the businessCode for this instance.
        /// </summary>
        /// <value>The businessCode.</value>
        public Code BusinessCode { get; private set; }

        /// <summary>
        /// Gets the description for this instance.
        /// </summary>
        /// <value>The description.</value>
        public ShortDescription Description { get; private set; }

        /// <summary>
        /// Gets the state of this instance.
        /// </summary>
        /// <value>The state of this instance.</value>
        public LocationState LocationState { get; private set; }

        /// <summary>
        /// Gets the optional parent <see cref="Location"/>.
        /// </summary>
        /// <value>The parent.</value>
        public Maybe<Location> Parent { get; private set; }

        /// <summary>
        /// Gets the name for this instance.
        /// </summary>
        /// <value>The name.</value>
        public Name Name { get; private set; }

        /// <summary>
        /// If the specified arguments are valid, then creates a new instance of the <see
        /// cref="Location"/> and wraps it in a <see cref="Result{Location}"/>. Otherwise returns a
        /// fail <see cref="Result{Location}"/>.
        /// </summary>
        /// <param name="businessCode">The business businessCode.</param>
        /// <param name="name">The name.</param>
        /// <returns>Returns a <see cref="Result{Location}"/></returns>
        public static Result<Location> Create(Code businessCode, Name name)
        {
            var validationResult = Result.Combine(
                Check.IsNotNull(businessCode, LocationErrorKeys.BusinessCodeIsNull),
                Check.IsNotNull(name, LocationErrorKeys.NameIsNull));

            return validationResult.IsSuccess
                ? Result.Ok(new Location(businessCode, name))
                : Result.Fail<Location>(validationResult.Error);
        }

        /// <summary>
        /// If the specified arguments are valid, then creates a new instance of the <see
        /// cref="Location"/> and wraps it in a <see cref="Result{Location}"/>. Otherwise returns a
        /// fail <see cref="Result{Location}"/>.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="businessCode">The business businessCode.</param>
        /// <param name="name">The name.</param>
        /// <param name="state">The state.</param>
        /// <returns>Returns a <see cref="Result{Location}"/></returns>
        public static Result<Location> Create(Guid id, Code businessCode, Name name, LocationState state)
        {
            var validationResult = Result.Combine(
                Check.IsNotEqual(id, Guid.Empty, LocationErrorKeys.IdIsDefaultOrEmpty),
                Check.IsNotNull(businessCode, LocationErrorKeys.BusinessCodeIsNull),
                Check.IsNotNull(name, LocationErrorKeys.NameIsNull),
                Check.IsNotNull(state, LocationErrorKeys.LocationStateIsNull));

            return validationResult.IsSuccess
                ? Result.Ok(new Location(id, businessCode, name, state))
                : Result.Fail<Location>(validationResult.Error);
        }

        /// <summary>
        /// Changes the business code of this instance.
        /// </summary>
        /// <param name="businessCode">The new business code for this instance.</param>
        /// <exception cref="ArgumentNullException">Thrown if business code is null.</exception>
        public void ChangeBusinessCode(Code businessCode)
        {
            Ensure.IsNotNull(businessCode, (ArgumentName)nameof(businessCode));

            BusinessCode = businessCode;
        }

        /// <summary>
        /// Changes the description of this instance.
        /// </summary>
        /// <param name="description">The new description for this instance.</param>
        /// <exception cref="ArgumentNullException">Thrown if description is null.</exception>
        public void ChangeDescription(ShortDescription description)
        {
            Ensure.IsNotNull(description, (ArgumentName)nameof(description));

            Description = description;
        }

        /// <summary>
        /// Changes the state of this instance.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <exception cref="ArgumentNullException">Thrown if state is null.</exception>
        public void ChangeLocationState(LocationState state)
        {
            Ensure.IsNotNull(state, (ArgumentName)nameof(state));

            LocationState = state;
        }

        /// <summary>
        /// Changes the name of this instance.
        /// </summary>
        /// <param name="name">The new name for this instance.</param>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        public void ChangeName(Name name)
        {
            Ensure.IsNotNull(name, (ArgumentName)nameof(name));

            Name = name;
        }

        /// <summary>
        /// Changes the parent.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <exception cref="ArgumentNullException">Thrown if parent is null.</exception>
        public void ChangeParent(Location parent)
        {
            Ensure.IsNotNull(parent, (ArgumentName)nameof(parent));

            Parent = Maybe<Location>.Wrap(parent);
        }

        /// <summary>
        /// Removes the parent.
        /// </summary>
        public void RemoveParent()
        {
            Parent = Maybe<Location>.Empty;
        }
    }
}
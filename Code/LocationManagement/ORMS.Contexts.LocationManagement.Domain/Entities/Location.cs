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

    /// <summary>
    /// Represents a location.
    /// </summary>
    public class Location : AggregateRoot<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location" /> class.
        /// Sets the state to <see cref="ORMS.Contexts.LocationManagement.Domain.Entities.LocationState.Created"/>
        /// </summary>
        /// <param name="businessCode">The business code.</param>
        /// <param name="name">The name.</param>
        private Location(Code businessCode, Name name)
            : this(Guid.NewGuid(), businessCode, name, LocationState.Created)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="businessCode">The business code.</param>
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
        /// Gets the code for this instance.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public Code BusinessCode { get; private set; }

        /// <summary>
        /// Gets the description for this instance.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public ShortDescription Description { get; private set; }

        /// <summary>
        /// Gets the state of this instance.
        /// </summary>
        /// <value>
        /// The state of this instance.
        /// </value>
        public LocationState LocationState { get; private set; }

        /// <summary>
        /// Gets the name for this instance.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public Name Name { get; private set; }

        /// <summary>
        /// If the specified arguments are valid, then creates a new instance of
        /// the <see cref="Location" /> and wraps it in a <see cref="Result{Location}" />.
        /// Otherwise returns a fail <see cref="Result{Location}" />.
        /// </summary>
        /// <param name="businessCode">The business code.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        /// Returns a <see cref="Result{Location}" />
        /// </returns>
        public static Result<Location> Create(Code businessCode, Name name)
        {
            if (businessCode == null) return Result.Fail<Location>(LocationErrorKeys.BusinessCodeIsNull);
            if (name == null) return Result.Fail<Location>(LocationErrorKeys.NameIsNull);

            return Result.Ok(new Location(businessCode, name));
        }

        /// <summary>
        /// If the specified arguments are valid, then creates a new instance of
        /// the <see cref="Location" /> and wraps it in a <see cref="Result{Location}" />.
        /// Otherwise returns a fail <see cref="Result{Location}" />.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="businessCode">The business code.</param>
        /// <param name="name">The name.</param>
        /// <param name="state">The state.</param>
        /// <returns>
        /// Returns a <see cref="Result{Location}" />
        /// </returns>
        public static Result<Location> Create(Guid id, Code businessCode, Name name, LocationState state)
        {
            if (id.Equals(Guid.Empty)) return Result.Fail<Location>(LocationErrorKeys.IdIsDefaultOrEmpty);
            if (businessCode == null) return Result.Fail<Location>(LocationErrorKeys.BusinessCodeIsNull);
            if (name == null) return Result.Fail<Location>(LocationErrorKeys.NameIsNull);
            if (state == null) return Result.Fail<Location>(LocationErrorKeys.LocationStateIsNull);

            return Result.Ok(new Location(businessCode, name));
        }

        /// <summary>
        /// Changes the code of this instance.
        /// </summary>
        /// <param name="code">The new code for this instance.</param>
        public void ChangeBusinessCode(Code code)
        {
            BusinessCode = code ?? throw new ArgumentNullException(nameof(code));
        }

        /// <summary>
        /// Changes the description of this instance.
        /// </summary>
        /// <param name="description">The new description for this instance.</param>
        /// <exception cref="ArgumentNullException">description</exception>
        public void ChangeDescription(ShortDescription description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        /// <summary>
        /// Changes the state of this instance.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <exception cref="ArgumentNullException">state</exception>
        public void ChangeLocationState(LocationState state)
        {
            LocationState = state ?? throw new ArgumentNullException(nameof(state));
        }

        /// <summary>
        /// Changes the name of this instance.
        /// </summary>
        /// <param name="name">The new name for this instance.</param>
        /// <exception cref="ArgumentNullException">name</exception>
        public void ChangeName(Name name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
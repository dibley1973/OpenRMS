//-----------------------------------------------------------------------
// <copyright file="LocationErrorKeys.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.LocationManagement.Domain.Constants.ResultErrorKeys
{
    using Entities;

    /// <summary>
    /// Represents the keys strings for <see cref="Location"/> errors, which
    /// can be converted by the UI to meaningful messages;
    /// </summary>
    public class LocationErrorKeys
    {
        /// <summary>
        /// The key for when the identifier is default
        /// </summary>
        public const string IdIsDefault = "IdIsDefault";

        /// <summary>
        /// The key for when the identifier is empty
        /// </summary>
        public const string IdIsEmpty = "IdIsEmpty";

        /// <summary>
        /// The key for when the business code is null.
        /// </summary>
        public const string BusinessCodeIsNull = "businessCodeIsNull ";

        /// <summary>
        /// The key for when the id is null or empty.
        /// </summary>
        public const string IdIsNullOrEmpty = "IdIsNullOrEmpty";

        /// <summary>
        /// The key for when the name is null.
        /// </summary>
        public const string NameIsNull = "NameIsNull";

        /// <summary>
        /// The key for when the state is null.
        /// </summary>
        public const string LocationStateIsNull = "LocationStateIsNull";
    }
}
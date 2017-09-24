//-----------------------------------------------------------------------
// <copyright file="ItemErrorKeys.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.Constants.ResultErrorKeys
{
    using Entities;

    /// <summary>
    /// Represents the keys strings for <see cref="Item"/> errors, which
    /// can be converted by the UI to meaningful messages;
    /// </summary>
    public class ItemErrorKeys
    {
        /// <summary>
        /// The key for when the description is null.
        /// </summary>
        public const string DescriptionIsNull = "DescriptionIsNull ";

        /// <summary>
        /// The key for when the id is null.
        /// </summary>
        public const string IdIsNull = "IdIsNull";

        /// <summary>
        /// The key for when the name is null.
        /// </summary>
        public const string NameIsNull = "NameIsNull";

        /// <summary>
        /// The key for when the state is null.
        /// </summary>
        public const string StateIsNull = "StateIsNull";
    }
}
//-----------------------------------------------------------------------
// <copyright file="FakeProduct.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Fakes
{
    using BaseClasses;

    /// <summary>
    /// Represents a fake product for testoing purposes only
    /// </summary>
    public class FakeProduct : Entity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeProduct"/> class.
        /// </summary>
        public FakeProduct()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeProduct"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public FakeProduct(int id)
            : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
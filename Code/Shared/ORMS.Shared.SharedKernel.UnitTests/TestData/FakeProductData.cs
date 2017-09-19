//-----------------------------------------------------------------------
// <copyright file="FakeProductData.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.TestData
{
    using Fakes;

    /// <summary>
    /// Used for creating <see cref="FakeProduct"/> data for testing purposes only
    /// </summary>
    internal static class FakeProductData
    {
        /// <summary>
        /// Creates a null <see cref="FakeProduct"/>.
        /// </summary>
        /// <returns>Returns a a null <see cref="FakeProduct"/>.</returns>
        public static FakeProduct CreateNullProduct()
        {
            return default(FakeProduct);
        }

        /// <summary>
        /// Creates an empty <see cref="FakeProduct"/>.
        /// </summary>
        /// <returns>Returns an empty <see cref="FakeProduct"/>.</returns>
        public static FakeProduct CreateEmptyProduct()
        {
            return new FakeProduct();
        }

        /// <summary>
        /// Creates a <see cref="FakeProduct"/> with identity of 2.
        /// </summary>
        /// <returns>Returns a <see cref="FakeProduct"/>.</returns>
        public static FakeProduct CreateProductNo2()
        {
            return new FakeProduct(2);
        }

        /// <summary>
        /// Creates a <see cref="FakeProduct"/> with identity of 3.
        /// </summary>
        /// <returns>Returns a <see cref="FakeProduct"/>.</returns>
        public static FakeProduct CreateProductNo3()
        {
            return new FakeProduct(3);
        }

        /// <summary>
        /// Creates a <see cref="FakeProduct"/> with the specified identity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns a <see cref="FakeProduct"/>.
        /// </returns>
        public static FakeProduct CreateProduct(int id)
        {
            return new FakeProduct(id);
        }
    }
}
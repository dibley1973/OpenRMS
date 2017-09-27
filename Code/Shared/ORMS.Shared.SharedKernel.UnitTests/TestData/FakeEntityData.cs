//-----------------------------------------------------------------------
// <copyright file="FakeEntityData.cs" company="Chesil Media">
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
    /// Used for creating <see cref="FakeEntity"/> data for testing purposes only
    /// </summary>
    internal static class FakeEntityData
    {
        /// <summary>
        /// Creates a null <see cref="FakeEntity"/>.
        /// </summary>
        /// <returns>Returns a a null <see cref="FakeEntity"/>.</returns>
        public static FakeEntity CreateNullProduct()
        {
            return default(FakeEntity);
        }

        /// <summary>
        /// Creates an empty <see cref="FakeEntity"/>.
        /// </summary>
        /// <returns>Returns an empty <see cref="FakeEntity"/>.</returns>
        public static FakeEntity CreateEmptyProduct()
        {
            return new FakeEntity();
        }

        /// <summary>
        /// Creates a <see cref="FakeEntity"/> with identity of 2.
        /// </summary>
        /// <returns>Returns a <see cref="FakeEntity"/>.</returns>
        public static FakeEntity CreateProductNo2()
        {
            return new FakeEntity(2);
        }

        /// <summary>
        /// Creates a <see cref="FakeEntity"/> with identity of 3.
        /// </summary>
        /// <returns>Returns a <see cref="FakeEntity"/>.</returns>
        public static FakeEntity CreateProductNo3()
        {
            return new FakeEntity(3);
        }

        /// <summary>
        /// Creates a <see cref="FakeEntity"/> with the specified identity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns a <see cref="FakeEntity"/>.
        /// </returns>
        public static FakeEntity CreateProduct(int id)
        {
            return new FakeEntity(id);
        }
    }
}
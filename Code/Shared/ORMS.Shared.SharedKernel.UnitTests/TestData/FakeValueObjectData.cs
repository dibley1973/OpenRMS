//-----------------------------------------------------------------------
// <copyright file="FakeValueObjectData.cs" company="Chesil Media">
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
    /// Used for creating <see cref="FakeValueObject"/> data for testing purposes only
    /// </summary>
    internal static class FakeValueObjectData
    {
        /// <summary>
        /// Creates a default <see cref="FakeEntity"/>.
        /// </summary>
        /// <returns>Returns a null reference <see cref="FakeEntity"/>.</returns>
        public static FakeValueObject CreateDefaultFakeValueObject()
        {
            return default(FakeValueObject);
        }

        /// <summary>
        /// Creates an empty <see cref="FakeValueObject"/>.
        /// </summary>
        /// <returns>Returns an <see cref="FakeValueObject"/>.</returns>
        public static FakeValueObject CreateEmptyFakeValueObject()
        {
            return new FakeValueObject("0", "0");
        }

        /// <summary>
        /// Creates the <see cref="FakeValueObject"/> No. 1.
        /// </summary>
        /// <returns>Returns an <see cref="FakeValueObject"/>.</returns>
        public static FakeValueObject CreateFakeValueObjectNo1()
        {
            return new FakeValueObject("01", "02");
        }

        /// <summary>
        /// Creates the <see cref="FakeValueObject"/> No. 2.
        /// </summary>
        /// <returns>Returns an <see cref="FakeValueObject"/>.</returns>
        public static FakeValueObject CreateFakeValueObjectNo2()
        {
            return new FakeValueObject("01", "03");
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="FakeOptionCodeData.cs" company="Chesil Media">
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
    /// Used for creating <see cref="FakeOptionCode"/> data for testing purposes only
    /// </summary>
    internal static class FakeOptionCodeData
    {
        /// <summary>
        /// Creates a default <see cref="FakeProduct"/>.
        /// </summary>
        /// <returns>Returns a a null <see cref="FakeProduct"/>.</returns>
        public static FakeOptionCode CreateDefaultOptionCode()
        {
            return default(FakeOptionCode);
        }

        /// <summary>
        /// Creates an empty option code.
        /// </summary>
        /// <returns>Returns an <see cref="FakeOptionCode"/>.</returns>
        public static FakeOptionCode CreateEmptyOptionCode()
        {
            return new FakeOptionCode("0", "0");
        }

        /// <summary>
        /// Creates the option code no1.
        /// </summary>
        /// <returns>Returns an <see cref="FakeOptionCode"/>.</returns>
        public static FakeOptionCode CreateOptionCodeNo1()
        {
            return new FakeOptionCode("01", "02");
        }

        /// <summary>
        /// Creates the option code no2.
        /// </summary>
        /// <returns>Returns an <see cref="FakeOptionCode"/>.</returns>
        public static FakeOptionCode CreateOptionCodeNo2()
        {
            return new FakeOptionCode("01", "03");
        }
    }
}
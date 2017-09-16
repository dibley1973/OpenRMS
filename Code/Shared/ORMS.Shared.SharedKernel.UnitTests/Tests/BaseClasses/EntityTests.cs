//-----------------------------------------------------------------------
// <copyright file="EntityTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.BaseClasses
{
    using Fakes;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.BaseClasses;

    /// <summary>
    /// Provides unit tests for the <see cref="Entity{TId}"/> class.
    /// </summary>
    [TestFixture]
    public class EntityTests
    {
        /// <summary>
        /// Equalses the when other is same type but null returns false.
        /// </summary>
        [Test]
        public void Equals_WhenOtherIsSameTypeButNull_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct(2);

            // ACT
            var actual = product.Equals(null);

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="MaybeTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.Amplifiers
{
    using Fakes;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.Amplifiers;

    /// <summary>
    /// Test for Maybe structure
    /// </summary>
    [TestFixture]
    public class MaybeTests
    {
        /// <summary>
        /// Givens value for default <see cref="Maybe{T}"/> throws exception.
        /// </summary>
        [Test]
        public void GivenValue_ForDefaultMaybe_ThrowsException()
        {
            // ARRANGE
            var maybe = default(Maybe<FakeProduct>);

            // ACT
            FakeProduct ActualValueDelegate() => maybe.Value;

            // ASSERT
            Assert.That(ActualValueDelegate, Throws.InvalidOperationException);
        }

        /// <summary>
        /// Givens the value after wrapping with null argument throws exception.
        /// </summary>
        [Test]
        public void GivenValue_AfterWrappingWithNullArgument_ThrowsException()
        {
            // ARRANGE
            var maybe = Maybe<FakeProduct>.Wrap(null);

            // ACT
            FakeProduct ActualValueDelegate() => maybe.Value;

            // ASSERT
            Assert.That(ActualValueDelegate, Throws.InvalidOperationException);
        }

        /// <summary>
        /// Givens the value after wrapping with an instantiated object returns same object.
        /// </summary>
        [Test]
        public void GivenValue_AfterWrappingWithAnInstantiatedObject_ReturnsSameObject()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = Maybe<FakeProduct>.Wrap(product);

            // ACT
            var actual = maybe.Value;

            // ASSERT
            actual.Should().Be(product);
        }
    }
}
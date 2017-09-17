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
        /// Given value for a default <see cref="Maybe{T}"/> throws exception.
        /// </summary>
        [Test]
        public void GivenValue_ForADefaultMaybe_ThrowsException()
        {
            // ARRANGE
            var maybe = default(Maybe<FakeProduct>);

            // ACT
            FakeProduct ActualValueDelegate() => maybe.Value;

            // ASSERT
            Assert.That(ActualValueDelegate, Throws.InvalidOperationException);
        }

        /// <summary>
        /// Given the value after wrapping with null argument throws exception.
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
        /// Given the value after wrapping with an instantiated object returns same object.
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

        /// <summary>
        /// Given the Value after assigning null to implicit operator returns true.
        /// </summary>
        [Test]
        public void GivenValue_AfterAssigningNullToImplicitOperator_ReturnsTrue()
        {
            // ARRANGE
            Maybe<FakeProduct> maybe = null;

            // ACT
            FakeProduct ActualValueDelegate() => maybe.Value;

            // ASSERT
            Assert.That(ActualValueDelegate, Throws.InvalidOperationException);
        }

        /// <summary>
        /// Given the Value after assigning instantiated object to implicit operator returns instantiated object.
        /// </summary>
        [Test]
        public void GivenValue_AfterAssigningInstantiatedObjectToImplicitOperator_ReturnsInstantiatedObject()
        {
            // ARRANGE
            var product = new FakeProduct();
            Maybe<FakeProduct> maybe = product;

            // ACT
            var actual = maybe.Value;

            // ASSERT
            actual.Should().BeSameAs(product);
        }

        /// <summary>
        /// Given the HasValue for a default maybe returns false.
        /// </summary>
        [Test]
        public void GivenHasValue_ForADefaultMaybe_ReturnsFalse()
        {
            // ARRANGE
            var maybe = default(Maybe<FakeProduct>);

            // ACT
            var actual = maybe.HasValue;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the HasValue after wrapping with null argument throws exception.
        /// </summary>
        [Test]
        public void GivenHasValue_AfterWrappingWithNullArgument_ReturnsFalse()
        {
            // ARRANGE
            var maybe = Maybe<FakeProduct>.Wrap(null);

            // ACT
            var actual = maybe.HasValue;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the has value after wrapping with an instantiated object returns true.
        /// </summary>
        [Test]
        public void GivenHasValue_AfterWrappingWithAnInstantiatedObject_ReturnsTrue()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = Maybe<FakeProduct>.Wrap(product);

            // ACT
            var actual = maybe.HasValue;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasValue after assigning null to implicit operator returns false.
        /// </summary>
        [Test]
        public void GivenHasValue_AfterAssigningNullToImplicitOperator_ReturnsFalse()
        {
            // ARRANGE
            Maybe<FakeProduct> maybe = null;

            // ACT

            // ASSERT
            maybe.HasValue.Should().BeFalse();
        }

        /// <summary>
        /// Given the HasValue after assigning instantiated object to implicit operator returns true.
        /// </summary>
        [Test]
        public void GivenHasValue_AfterAssigningInstantiatedObjectToImplicitOperator_ReturnsTrue()
        {
            // ARRANGE
            var product = new FakeProduct();
            Maybe<FakeProduct> maybe = product;

            // ACT

            // ASSERT
            maybe.HasValue.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasNoValue for a default maybe returns true.
        /// </summary>
        [Test]
        public void GivenNoHasValue_ForADefaultMaybe_ReturnsTrue()
        {
            // ARRANGE
            var maybe = default(Maybe<FakeProduct>);

            // ACT
            var actual = maybe.HasNoValue;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasNoValue after wrapping with null argument returns true.
        /// </summary>
        [Test]
        public void GivenHasNoValue_AfterWrappingWithNullArgument_ReturnsTrue()
        {
            // ARRANGE
            var maybe = Maybe<FakeProduct>.Wrap(null);

            // ACT
            var actual = maybe.HasNoValue;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasNoValue after wrapping with an instantiated object returns false.
        /// </summary>
        [Test]
        public void GivenHasNoValue_AfterWrappingWithAnInstantiatedObject_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = Maybe<FakeProduct>.Wrap(product);

            // ACT
            var actual = maybe.HasNoValue;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the HasNoValue after assigning null to implicit operator returns true.
        /// </summary>
        [Test]
        public void GivenHasNoValue_AfterAssigningNullToImplicitOperator_ReturnsTrue()
        {
            // ARRANGE
            Maybe<FakeProduct> maybe = null;

            // ACT

            // ASSERT
            maybe.HasNoValue.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasNoValue after assigning instantiated object to implicit operator returns false.
        /// </summary>
        [Test]
        public void GivenHasNoValue_AfterAssigningInstantiatedObjectToImplicitOperator_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct();
            Maybe<FakeProduct> maybe = product;

            // ACT

            // ASSERT
            maybe.HasNoValue.Should().BeFalse();
        }
    }
}
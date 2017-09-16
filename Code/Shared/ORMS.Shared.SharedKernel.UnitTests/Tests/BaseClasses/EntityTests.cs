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
        /// Tests Equals when other is same type but null returns false.
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

        /// <summary>
        /// Tests Equals when other is different type returns false.
        /// </summary>
        [Test]
        public void Equals_WhenOtherIsDifferentType_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct(2);
            object other = new string('W', 5);

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when other is same reference returns true.
        /// </summary>
        [Test]
        public void Equals_WhenOtherIsSameReference_ReturnsTrue()
        {
            // ARRANGE
            var product = new FakeProduct(2);
            object other = product;

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test Equals when other is same type but default identifier returns false.
        /// </summary>
        [Test]
        public void Equals_WhenOtherIsSameTypeButDefaultId_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct();
            var other = new FakeProduct();

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when other is same type but different ids returns false.
        /// </summary>
        [Test]
        public void Equals_WhenOtherIsSameTypeButDifferentIds_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct(2);
            var other = new FakeProduct(3);

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when other is same type with same ids returns false.
        /// </summary>
        [Test]
        public void Equals_WhenOtherIsSameTypeWithSameIds_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct(2);
            var other = new FakeProduct(2);

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Tests the Identifier after construction with no identifier returns default value of identifier.
        /// </summary>
        [Test]
        public void Id_AfterConstructionWithNoId_ReturnsDefaultValueOfId()
        {
            // ARRANGE
            var product = new FakeProduct();

            // ACT
            var actual = product.Id;

            // ASSERT
            actual.Should().Be(default(int));
        }

        /// <summary>
        /// Tests the Identifier after construction with identifier returns value of identifier.
        /// </summary>
        [Test]
        public void Id_AfterConstructionWithId_ReturnsValueOfId()
        {
            // ARRANGE
            var id = 187;
            var product = new FakeProduct(id);

            // ACT
            var actual = product.Id;

            // ASSERT
            actual.Should().Be(id);
        }

        /// <summary>
        /// Test Equals when both instances are null returns true.
        /// </summary>
        [Test]
        public void IsEqualTo_WhenBothInstancesAreNull_ReturnsTrue()
        {
            // ARRANGE
            FakeProduct product = null;
            FakeProduct other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = product == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test Equals when one instance is instantiated and the other is null returns false.
        /// </summary>
        [Test]
        public void IsEqualTo_WhenOneInstanceIsInstantiatedAndTheOtherIsNull_ReturnsFalse()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7);
            FakeProduct other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = product == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when both instance are instantiated with different ids returns false.
        /// </summary>
        [Test]
        public void IsEqualTo_WhenBothInstanceAreInstantiatedWithDifferentIds_ReturnsFalse()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7);
            FakeProduct other = new FakeProduct(77);

            // ACT
            var actual = product == other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when both instance are instantiated with same ids returns true.
        /// </summary>
        [Test]
        public void IsEqualTo_WhenBothInstanceAreInstantiatedWithSameIds_ReturnsTrue()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7);
            FakeProduct other = new FakeProduct(7);

            // ACT
            var actual = product == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test not equal to when both instances are null returns false.
        /// </summary>
        [Test]
        public void IsNotEqualTo_WhenBothInstancesAreNull_ReturnsFalse()
        {
            // ARRANGE
            FakeProduct product = null;
            FakeProduct other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = product != other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test not equal to when one instance is instantiated and the other is null returns true.
        /// </summary>
        [Test]
        public void IsNotEqualTo_WhenOneInstanceIsInstantiatedAndTheOtherIsNull_ReturnsTrue()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7);
            FakeProduct other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = product != other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test not equal to when both instance are instantiated with different ids returns true.
        /// </summary>
        [Test]
        public void IsNotEqualTo_WhenBothInstanceAreInstantiatedWithDifferentIds_ReturnsTrue()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7);
            FakeProduct other = new FakeProduct(77);

            // ACT
            var actual = product != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test not equal to when both instance are instantiated with same ids return false.
        /// </summary>
        [Test]
        public void IsNotEqualTo_WhenBothInstanceAreInstantiatedWithSameIds_ReturnFalse()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7);
            FakeProduct other = new FakeProduct(7);

            // ACT
            var actual = product != other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Determines whether is persistent after construction with no identifier returns false.
        /// </summary>
        [Test]
        public void IsPersistent_AfterConstructionWithNoId_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct();

            // ACT
            var actual = product.IsPersistent;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Determines whether is persistent after construction with identifier returns true.
        /// </summary>
        [Test]
        public void IsPersistent_AfterConstructionWithId_ReturnsTrue()
        {
            // ARRANGE
            var id = 187;
            var product = new FakeProduct(id);

            // ACT
            var actual = product.IsPersistent;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Determines whether is transient after construction with no identifier returns true.
        /// </summary>
        [Test]
        public void IsTransient_AfterConstructionWithNoId_ReturnsTrue()
        {
            // ARRANGE
            var product = new FakeProduct();

            // ACT
            var actual = product.IsTransient;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Determines whether is transient after construction with identifier returns false.
        /// </summary>
        [Test]
        public void IsTransient_AfterConstructionWithId_ReturnsFalse()
        {
            // ARRANGE
            var id = 187;
            var product = new FakeProduct(id);

            // ACT
            var actual = product.IsTransient;

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}
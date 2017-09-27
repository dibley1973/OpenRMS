//-----------------------------------------------------------------------
// <copyright file="ValueObjectTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.BaseClasses
{
    using System;
    using System.Collections.Generic;
    using Fakes;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.BaseClasses;
    using TestData;

    /// <summary>
    /// Provides unit tests for the <see cref="Entity{TId}"/> class.
    /// </summary>
    [TestFixture]
    public class ValueObjectTests
    {
        /// <summary>
        /// Given the equals when given null object returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenNullObject_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateDefaultFakeValueObject();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the equals when given null object returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenNullSameType_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
#pragma warning disable 219
            var other = default(FakeValueObject);
#pragma warning restore 219

            // ACT
            var actual = instance.Equals(null);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the equals when given different type returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenDifferentType_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            object other = FakeEntityData.CreateEmptyProduct();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the equals when given same type different reference returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeDifferentReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo2();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the equals when given same type same reference returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeSameReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = instance;

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the equals when given same type different reference same values returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo1();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the get hash code when used same property values are used calculates same code.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenUsedSamePropertyValuesAreUsed_CalculatesSameCode()
        {
            // ARRANGE
            var dictionary = new Dictionary<FakeValueObject, FakeEntity>();
            var valueObjectNo1 = FakeValueObjectData.CreateFakeValueObjectNo1();
            var valueObjectNo2 = FakeValueObjectData.CreateFakeValueObjectNo1();
            var entity1 = FakeEntityData.CreateEmptyProduct();
            var entity2 = FakeEntityData.CreateEmptyProduct();
            dictionary.Add(valueObjectNo1, entity1);

            // ACT
            void Action() => dictionary.Add(valueObjectNo2, entity2);

            // ASSERT
            Assert.Throws<ArgumentException>(Action);
        }

        /// <summary>
        /// Given the get hash code when used different property values are used calculates different code.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenUsedDifferentPropertyValuesAreUsed_CalculatesDifferentCode()
        {
            // ARRANGE
            var dictionary = new Dictionary<FakeValueObject, FakeEntity>();
            var valueObjectNo1 = FakeValueObjectData.CreateFakeValueObjectNo1();
            var valueObjectNo2 = FakeValueObjectData.CreateFakeValueObjectNo2();
            var entity1 = FakeEntityData.CreateEmptyProduct();
            var entity2 = FakeEntityData.CreateEmptyProduct();
            dictionary.Add(valueObjectNo1, entity1);
            dictionary.Add(valueObjectNo2, entity2);

            // ACT
            var actual = dictionary.Count;

            // ASSERT
            actual.Should().Be(2);
        }

        /// <summary>
        /// Given the is equal to when given null object returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenNullObject_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateDefaultFakeValueObject();

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = instance == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the is equal to when given same type different reference returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeDifferentReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo2();

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the is equal to when given same type same reference returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeSameReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = instance;

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is equal to when given same type different reference same values returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo1();

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is not equal to when given null object returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenNullObject_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateDefaultFakeValueObject();

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = instance != other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is not equal to when given same type different reference returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeDifferentReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo2();

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the is not equal to when given same type same reference returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeSameReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = instance;

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the is not equal to when given same type different reference same values returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsFalse()
        {
            // ARRANGE
            var instance = FakeValueObjectData.CreateFakeValueObjectNo1();
            var other = FakeValueObjectData.CreateFakeValueObjectNo1();

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}
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
        /// Givens the equals when given null object returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenNullObject_ReturnsFalse()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");

            // ACT
            var actual = instance.Equals(null);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Givens the equals when given different type returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenDifferentType_ReturnsFalse()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            object other = FakeProductData.CreateEmptyProduct();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Givens the equals when given same type different reference returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeDifferentReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = new FakeOptionCode("01", "03");

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Givens the equals when given same type same reference returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeSameReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = instance;

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Givens the equals when given same type different reference same values returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsTrue()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = new FakeOptionCode("01", "02");

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Givens the get hash code when used same property values are used calculates same code.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenUsedSamePropertyValuesAreUsed_CalculatesSameCode()
        {
            // ARRANGE
            var products = new Dictionary<FakeOptionCode, FakeProduct>();
            var optionCode1 = new FakeOptionCode("01", "02");
            var optionCode2 = new FakeOptionCode("01", "02");
            var product1 = FakeProductData.CreateEmptyProduct();
            var product2 = FakeProductData.CreateEmptyProduct();
            products.Add(optionCode1, product1);

            // ACT
            void Action() => products.Add(optionCode2, product2);

            // ASSERT
            Assert.Throws<ArgumentException>(Action);
        }

        /// <summary>
        /// Givens the get hash code when used different property values are used calculates different code.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenUsedDifferentPropertyValuesAreUsed_CalculatesDifferentCode()
        {
            // ARRANGE
            var products = new Dictionary<FakeOptionCode, FakeProduct>();
            var optionCode1 = new FakeOptionCode("01", "02");
            var optionCode2 = new FakeOptionCode("01", "03");
            var product1 = FakeProductData.CreateEmptyProduct();
            var product2 = FakeProductData.CreateEmptyProduct();
            products.Add(optionCode1, product1);
            products.Add(optionCode2, product2);

            // ACT
            var actual = products.Count;

            // ASSERT
            actual.Should().Be(2);
        }

        /// <summary>
        /// Givens the is equal to when given null object returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenNullObject_ReturnsFalse()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = default(FakeOptionCode);

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = instance == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Givens the is equal to when given same type different reference returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeDifferentReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = new FakeOptionCode("01", "03");

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Givens the is equal to when given same type same reference returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeSameReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = instance;

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Givens the is equal to when given same type different reference same values returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsTrue()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = new FakeOptionCode("01", "02");

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Givens the is not equal to when given null object returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenNullObject_ReturnsTrue()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = default(FakeOptionCode);

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = instance != other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Givens the is not equal to when given same type different reference returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeDifferentReference_ReturnsTrue()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = new FakeOptionCode("01", "03");

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Givens the is not equal to when given same type same reference returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeSameReference_ReturnsFalse()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = instance;

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Givens the is not equal to when given same type different reference same values returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsFalse()
        {
            // ARRANGE
            var instance = new FakeOptionCode("01", "02");
            var other = new FakeOptionCode("01", "02");

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}
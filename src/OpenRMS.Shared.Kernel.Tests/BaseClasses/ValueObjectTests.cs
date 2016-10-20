using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Shared.Kernel.Tests.Fakes;

namespace OpenRMS.Shared.Kernel.Tests.BaseClasses
{
    [TestClass]
    public class ValueObjectTests
    {
        [TestMethod]
        public void Equals_WhenGivenNullObject_ReturnsFalse()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");

            // ACT
            var actual = instance.Equals(null);

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void Equals_WhenGivenDifferentType_ReturnsFalse()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            object other = new FakeProduct();

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void Equals_WhenGivenSameTypeDifferentReference_ReturnsFalse()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = new FakeOptionCode("01", "03");

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void Equals_WhenGivenSameTypeSameReference_ReturnsTrue()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = instance;

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void Equals_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsTrue()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = new FakeOptionCode("01", "02");

            // ACT
            var actual = instance.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void GetHashCode_WhenUsedSamePropertyValuesAreUsed_CalculatesSameCode()
        {
            // ARRANGE
            var products = new Dictionary<FakeOptionCode, FakeProduct>();
            var optionCode1 = new FakeOptionCode("01", "02");
            var optionCode2 = new FakeOptionCode("01", "02");
            var product1 = new FakeProduct();
            var product2 = new FakeProduct();
            products.Add(optionCode1, product1);

            // ACT
            Action action = () => products.Add(optionCode2, product2);

            // ASSERT
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void GetHashCode_WhenUsedDifferentPropertyValuesAreUsed_CalculatesDifferentCode()
        {
            // ARRANGE
            var products = new Dictionary<FakeOptionCode, FakeProduct>();
            var optionCode1 = new FakeOptionCode("01", "02");
            var optionCode2 = new FakeOptionCode("01", "03");
            var product1 = new FakeProduct();
            var product2 = new FakeProduct();
            products.Add(optionCode1, product1);
            products.Add(optionCode2, product2);

            // ACT
            var actual = products.Count;

            // ASSERT
            actual.Should().Be(2);
        }

        [TestMethod]
        public void IsEqualTo_WhenGivenNullObject_ReturnsFalse()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = instance == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void IsEqualTo_WhenGivenSameTypeDifferentReference_ReturnsFalse()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = new FakeOptionCode("01", "03");

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void IsEqualTo_WhenGivenSameTypeSameReference_ReturnsTrue()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = instance;

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void IsEqualTo_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsTrue()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = new FakeOptionCode("01", "02");

            // ACT
            var actual = instance == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void IsNotEqualTo_WhenGivenNullObject_ReturnsTrue()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = null;

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void IsNotEqualTo_WhenGivenSameTypeDifferentReference_ReturnsTrue()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = new FakeOptionCode("01", "03");

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void IsNotEqualTo_WhenGivenSameTypeSameReference_ReturnsFalse()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = instance;

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void IsNotEqualTo_WhenGivenSameTypeDifferentReferenceSameValues_ReturnsFalse()
        {
            // ARRANGE
            FakeOptionCode instance = new FakeOptionCode("01", "02");
            FakeOptionCode other = new FakeOptionCode("01", "02");

            // ACT
            var actual = instance != other;

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Shared.Kernel.Tests.Fakes;

namespace OpenRMS.Shared.Kernel.Tests.Tests.BaseClasses
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void Equals_WhenOtherIsSameTypeButNull_ReturnsFalse()
        {
            // ARRANGE
            var product = new FakeProduct(2);

            // ACT
            var actual = product.Equals(null);

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void Id_AfterConstructionWithNoId_ReturnsDefaultValueOfId()
        {
            // ARRANGE
            var product = new FakeProduct();

            // ACT
            var actual = product.Id;

            // ASSERT
            actual.Should().Be(default(int));
        }

        [TestMethod]
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


        [TestMethod]
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

        [TestMethod]
        public void IsEqualTo_WhenOneInstanceIsInstantiatedAndTheOtherIsNull_Returnsfalse()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7); ;
            FakeProduct other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = product == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void IsEqualTo_WhenBothInstanceAreInstantiatedWithDifferentIds_ReturnsFalse()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7); ;
            FakeProduct other = new FakeProduct(77);

            // ACT
            var actual = product == other;

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void IsEqualTo_WhenBothInstanceAreInstantiatedWithSameIds_ReturnsTrue()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7); ;
            FakeProduct other = new FakeProduct(7);

            // ACT
            var actual = product == other;

            // ASSERT
            actual.Should().BeTrue();
        }


        [TestMethod]
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

        [TestMethod]
        public void IsNotEqualTo_WhenOneInstanceIsInstantiatedAndTheOtherIsNull_ReturnsTrue()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7); ;
            FakeProduct other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = product != other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void IsNotEqualTo_WhenBothInstanceAreInstantiatedWithDifferentIds_ReturnsTrue()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7); ;
            FakeProduct other = new FakeProduct(77);

            // ACT
            var actual = product != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void IsNotEqualTo_WhenBothInstanceAreInstantiatedWithSameIds_ReturnFalse()
        {
            // ARRANGE
            FakeProduct product = new FakeProduct(7); ;
            FakeProduct other = new FakeProduct(7);

            // ACT
            var actual = product != other;

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void IsTransient_AfterConstructionWithNoId_ReturnsDefaultValueOfId()
        {
            // ARRANGE
            var product = new FakeProduct();

            // ACT
            var actual = product.IsTransient();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void IsTransient_AfterConstructionWithId_ReturnsValueOfId()
        {
            // ARRANGE
            var id = 187;
            var product = new FakeProduct(id);

            // ACT
            var actual = product.IsTransient();

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}
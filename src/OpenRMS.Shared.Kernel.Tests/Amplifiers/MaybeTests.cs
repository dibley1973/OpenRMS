using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.Tests.Fakes;

namespace OpenRMS.Shared.Kernel.Tests.Amplifiers
{
    [TestClass]
    public class HasValueTests
    {
        [TestMethod]
        public void Entity_AfterConstructionWithNoArgument_ThrowsException()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct>();

            // ACT
            Func<object> action = () => maybe.Value;

            // ASSERT

            Assert.ThrowsException<InvalidOperationException>(action);
        }

        [TestMethod]
        public void Entity_AfterConstructionWithNullArgument_ThrowsException()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct>(null);

            // ACT
            Func<object> action = () => maybe.Value;

            // ASSERT

            Assert.ThrowsException<InvalidOperationException>(action);
        }

        [TestMethod]
        public void Entity_AfterConstructionWithAnInstantiatedArgument_ReturnsTrue()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = new Maybe<FakeProduct>(product);

            // ACT
            var actual = maybe.Value;

            // ASSERT
            actual.Should().Be(product);
        }

        [TestMethod]
        public void HasValue_AfterConstructionWithNoArgument_ReturnsFalse()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct>();

            // ACT
            var actual = maybe.HasValue();

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void HasValue_AfterConstructionWithNullArgument_ReturnsFalse()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct>(null);

            // ACT
            var actual = maybe.HasValue();

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void HasValue_AfterConstructionWithAnInstantiatedArgument_ReturnsTrue()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = new Maybe<FakeProduct>(product);

            // ACT
            var actual = maybe.HasValue();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void GetEnumerator_AfterConstructionWithNoArgument_THEN()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct>();

            // ACT
            var actual = maybe.FirstOrDefault();

            // ASSERT
            actual.Should().BeNull();
        }

        [TestMethod]
        public void GetEnumerator_AfterConstructionWithNullArgument_ReturnsNoItemsInSequnce()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct>(null);

            // ACT
            var actual = maybe.FirstOrDefault();

            // ASSERT
            actual.Should().BeNull();
        }

        [TestMethod]
        public void GetEnumerator_AfterConstructionWithAnInstantiatedArgument_ReturnsEntityAsOnlyItemInSequnce()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = new Maybe<FakeProduct>(product);

            // ACT
            var actual = maybe.First();
            var actualCount = maybe.Count();

            // ASSERT
            actual.Should().NotBeNull();
            actual.Should().BeSameAs(product);
            actualCount.Should().Be(1);
        }

        [TestMethod]
        public void ImplicitOperator_GivenNullEntity_ReturnsEmptyMaybe()
        {
            // ARRANGE
            Maybe<FakeProduct> maybe = (FakeProduct)null;

            // ACT
            
            // ASSERT
            maybe.HasValue().Should().BeFalse();
        }

        [TestMethod]
        public void ImplicitOperator_GivenInstantiatedEntity_ReturnsFilledMaybe()
        {
            // ARRANGE
            var product = new FakeProduct();
            Maybe<FakeProduct> maybe = product;

            // ACT

            // ASSERT
            maybe.HasValue().Should().BeTrue();
            maybe.Value.Should().BeSameAs(product);
        }

        [TestMethod]
        public void ImplicitOperator_GivenMaybeWithNoEntity_ReturnsNull()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = new Maybe<FakeProduct>();

            // ACT
            FakeProduct actual = maybe;

            // ASSERT
            actual.Should().BeNull();
        }

        [TestMethod]
        public void ImplicitOperator_GivenMaybeWithEntity_ReturnsEntity()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = new Maybe<FakeProduct>(product);

            // ACT
            FakeProduct actual = maybe;

            // ASSERT
            actual.Should().NotBeNull();
            actual.Should().BeSameAs(product);
        }
    }
}
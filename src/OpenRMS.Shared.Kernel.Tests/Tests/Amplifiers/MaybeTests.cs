using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.Tests.Fakes;

namespace OpenRMS.Shared.Kernel.Tests.Tests.Amplifiers
{
    [TestClass]
    public class HasValueTests
    {
        [TestMethod]
        public void Entity_AfterConstructionWithNoArgument_ThrowsException()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct, int>();

            // ACT
            Func<object> action = () => maybe.Entity;

            // ASSERT

            Assert.ThrowsException<InvalidOperationException>(action);
        }

        [TestMethod]
        public void Entity_AfterConstructionWithNullArgument_ThrowsException()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct, int>(null);

            // ACT
            Func<object> action = () => maybe.Entity;

            // ASSERT

            Assert.ThrowsException<InvalidOperationException>(action);
        }

        [TestMethod]
        public void Entity_AfterConstructionWithAnInstantiatedArgument_ReturnsTrue()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = new Maybe<FakeProduct, int>(product);

            // ACT
            var actual = maybe.Entity;

            // ASSERT
            actual.Should().Be(product);
        }

        [TestMethod]
        public void HasValue_AfterConstructionWithNoArgument_ReturnsFalse()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct, int>();

            // ACT
            var actual = maybe.HasValue();

            // ASSERT
            actual.Should().BeFalse();
        }

        [TestMethod]
        public void HasValue_AfterConstructionWithNullArgument_ReturnsFalse()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct, int>(null);

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
            var maybe = new Maybe<FakeProduct, int>(product);

            // ACT
            var actual = maybe.HasValue();

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void GetEnumerator_AfterConstructionWithNoArgument_THEN()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct, int>();

            // ACT
            var actual = maybe.FirstOrDefault();

            // ASSERT
            actual.Should().BeNull();
        }

        [TestMethod]
        public void GetEnumerator_AfterConstructionWithNullArgument_ReturnsNoItemsInSequnce()
        {
            // ARRANGE
            var maybe = new Maybe<FakeProduct, int>(null);

            // ACT
            var actual = maybe.FirstOrDefault();

            // ASSERT
            actual.Should().BeNull();
        }

        [TestMethod]
        public void GetEnumerator_AfterConstructionWithAnInstantiatedArgument_ReturnsEntityAsFirstItemInSequnce()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = new Maybe<FakeProduct, int>(product);

            // ACT
            var actual = maybe.First();

            // ASSERT
            actual.Should().NotBeNull();
            actual.Should().BeSameAs(product);
        }

        [TestMethod]
        public void ImplicitOperator_GivenNullEntity_ReturnsEmptyMaybe()
        {
            // ARRANGE
            Maybe<FakeProduct, int> maybe = (FakeProduct)null;

            // ACT
            
            // ASSERT
            maybe.HasValue().Should().BeFalse();
        }

        [TestMethod]
        public void ImplicitOperator_GivenInstantiatedEntity_ReturnsFilledMaybe()
        {
            // ARRANGE
            var product = new FakeProduct();
            Maybe<FakeProduct, int> maybe = product;

            // ACT

            // ASSERT
            maybe.HasValue().Should().BeTrue();
            maybe.Entity.Should().BeSameAs(product);
        }

        [TestMethod]
        public void ImplicitOperator_GivenMaybeWithNoEntity_ReturnsNull()
        {
            // ARRANGE
            var product = new FakeProduct();
            var maybe = new Maybe<FakeProduct, int>();

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
            var maybe = new Maybe<FakeProduct, int>(product);

            // ACT
            FakeProduct actual = maybe;

            // ASSERT
            actual.Should().NotBeNull();
            actual.Should().BeSameAs(product);
        }
    }
}
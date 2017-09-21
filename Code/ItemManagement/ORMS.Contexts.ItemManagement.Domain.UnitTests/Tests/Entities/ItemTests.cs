//-----------------------------------------------------------------------
// <copyright file="ItemTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.UnitTests.Tests.Entities
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using ORMS.Contexts.ItemManagement.Domain.Entities;
    using ORMS.Shared.SharedKernel.CommonEntities;

    /// <summary>
    /// Tests the <see cref="Item"/>
    /// </summary>
    [TestFixture]
    public class ItemTests
    {
        /// <summary>
        /// Given the construction when supplied with default unique identifier then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithDefaultGuid_ThenThrowsException()
        {
            // ARRANGE
            var id = default(Guid);
            var name = new Name("Item 1");
            var description = "Item One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with empty unique identifier then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithEmptyGuid_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.Empty;
            var name = new Name("Item 1");
            var description = "Item One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with null name then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithNullName_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = default(Name);
            var description = "Item One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the name when constructorsupplied valid name then returns constructed value.
        /// </summary>
        [Test]
        public void GivenName_WhenConstructorSuppliedValidName_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = new Name("Item1");
            var description = "Item One";

            // ACT
            var actual = new Item(id, name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
        }

        /// <summary>
        /// Given the construction when supplied with null description then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithNullDescription_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = new Name("Item 1");
            var description = default(string);

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with empty description then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithEmptyDescription_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = new Name("Item 1");
            var description = string.Empty;

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with whitespace description then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithWhitespaceDescription_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = new Name("Item 1");
            var description = " ";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the description when constructor given valid value then returns constructed value.
        /// </summary>
        [Test]
        public void GivenDescription_WhenConstructorGivenValidValue_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = new Name("Item 1");
            var description = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";

            // ACT
            var actual = new Item(id, name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Description.Should().Be(description);
        }
    }
}
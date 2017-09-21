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
            string name = "Item 1";
            string description = "Item One";

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
            string name = "Item 1";
            string description = "Item One";

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
            string name = null;
            string description = "Item One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with empty name then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithEmptyName_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = string.Empty;
            string description = "Item One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with whitespace name then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithWhitespaceName_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = "   ";
            string description = "Item One";

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
        public void GivenName_WhenConstructorsuppliedValidName_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";
            string description = "Item One";

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
            string name = "Item 1";
            string description = null;

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
            string name = "Item 1";
            string description = string.Empty;

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
            string name = "Item 1";
            string description = " ";

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
            string name = "Item 1";
            string description = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";

            // ACT
            var actual = new Item(id, name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Description.Should().Be(description);
        }
    }
}
using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.Domain;

namespace OpenRMS.Contexts.ItemManagement.Tests.Tests.Domain
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public  void Construct_WhenGivenDefaultGuid_ThrowsException()
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

        [TestMethod]
        public void Construct_WhenGivenEmptyGuid_ThrowsException()
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

        [TestMethod]
        public void Construct_WhenGivenNullName_ThrowsException()
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

        [TestMethod]
        public void Construct_WhenGivenEmptyName_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = "";
            string description = "Item One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenWhitespaceName_ThrowsException()
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

        [TestMethod]
        public void Name_WhenConstructorGivenValidName_ReturnsConstructedValue()
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

        [TestMethod]
        public void Construct_WhenGivenNullDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string Description = "Item 1";
            string description = null;

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, Description, description,);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenEmptyDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string Description = "Item 1";
            string description = "";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, Description, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenWhitespaceDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string Description = "Item 1";
            string description = " ";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, Description, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Description_WhenConstructorGivenValidValue_ReturnsConstructedValue()
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
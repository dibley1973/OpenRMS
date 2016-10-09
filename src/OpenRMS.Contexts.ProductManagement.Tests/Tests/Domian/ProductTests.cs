using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ProductManagement.Domain;

namespace OpenRMS.Contexts.ProductManagement.Tests.Tests.Domian
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public  void Construct_WhenGivenDefaultGuid_ThrowsException()
        {
            // ARRANGE
            var id = default(Guid);
            string name = "Product 1";
            string description = "Product One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Product(id, name, description, null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenEmptyGuid_ThrowsException()
        {
            // ARRANGE
            var id = Guid.Empty;
            string name = "Product 1";
            string description = "Product One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Product(id, name, description, null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenNullName_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = null;
            string description = "Product One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Product(id, name, description, null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenEmptyName_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = "";
            string description = "Product One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Product(id, name, description, null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenWhitespaceName_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = "   ";
            string description = "Product One";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Product(id, name, description, null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Name_WhenConstructorGivenValidName_ReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";
            string description = "Product One";

            // ACT
            var actual = new Product(id, name, description, null);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
        }

        [TestMethod]
        public void Construct_WhenGivenNullDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string Description = "Product 1";
            string description = null;

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Product(id, Description, description, null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenEmptyDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string Description = "Product 1";
            string description = "";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Product(id, Description, description, null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenWhitespaceDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string Description = "Product 1";
            string description = " ";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Product(id, Description, description, null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Description_WhenConstructorGivenValidValue_ReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            string name = "Product 1";
            string description = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";

            // ACT
            var actual = new Product(id, name, description, null);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Description.Should().Be(description);
        }
    }
}
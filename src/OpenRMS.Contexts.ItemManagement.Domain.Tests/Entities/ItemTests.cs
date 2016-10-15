using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;

namespace OpenRMS.Contexts.ItemManagement.Domain.Tests.Entities
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public  void Construct_WhenGivenDefaultGuid_ThrowsException()
        {
            // ARRANGE
            var id = default(Guid);
            var code = new ItemCode("1");
            string name = "Item 1";

            // ACT
            Action action = () => new Item(id, code, name);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenEmptyGuid_ThrowsException()
        {
            // ARRANGE
            var id = Guid.Empty;
            var code = new ItemCode("1");
            string name = "Item 1";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, code, name);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }


        [TestMethod]
        public void Construct_WhenGivenEmptyItemCode_ThrowsException()
        {
            // ARRANGE
            var code = ItemCode.Empty;
            string name = "Item without a code";

            // ACT
            Action action = () => new Item(code: code, name: name);

            // ASSERT
            action.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void Construct_WhenGivenNullName_ThrowsException()
        {
            // ARRANGE
            var code = new ItemCode("1");
            
            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(code: code, name: null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenEmptyName_ThrowsException()
        {
            // ARRANGE
            var code = new ItemCode("1");
            string emptyName = "";
            
            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(code: code, name: emptyName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenWhitespaceName_ThrowsException()
        {
            // ARRANGE
            var code = new ItemCode("1");
            string nameWithOnlyWhitespace = "   ";
            
            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(code:code, name: nameWithOnlyWhitespace);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Name_WhenConstructorGivenValidName_ReturnsConstructedValue()
        {
            // ARRANGE
            var code = new ItemCode("1");
            string name = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";
            

            // ACT
            var actual = new Item(code: code, name: name);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
        }

        [TestMethod]
        public void ChangeDescription_WhenGivenNullDescription_ThrowsException()
        {
            // ARRANGE
            var item = new Item(code: new ItemCode("1"), name: "Item 1");

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => item.ChangeDescription(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ChangeDescription_WhenGivenValidValue_UpdatesTheItemDescription()
        {
            // ARRANGE
            var actualItem = new Item(code: new ItemCode("1"), name: "Item 1");
            var expectedDescription = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";
            // ACT
            actualItem.ChangeDescription(expectedDescription);

            // ASSERT
            actualItem.Description.Should().NotBeNull();
            actualItem.Description.Should().Be(expectedDescription);
        }
    }
}
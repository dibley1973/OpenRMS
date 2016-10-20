using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.BaseClasses;

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
            var code = new BusinessCode("1");
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
            var code = new BusinessCode("1");
            string name = "Item 1";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, code, name);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }


        [TestMethod]
        public void Construct_WhenGivenEmptyBusinessCode_ThrowsException()
        {
            // ARRANGE
            var code = BusinessCode.Empty;
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
            var code = new BusinessCode("1");
            
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
            var code = new BusinessCode("1");
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
            var code = new BusinessCode("1");
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
            var code = new BusinessCode("1");
            string name = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";
            

            // ACT
            var actual = new Item(code: code, name: name);

            // ASSERT
            actual.Name.Should().Be(name);
        }

        [TestMethod]
        public void Construction_WhenGivenValidItemCode_SetsItemCodeValueProperty()
        {
            // ARRANGE
            var code = new BusinessCode("SKU1");


            // ACT
            var actual = new Item(code: code, name: "Item 1 Test");

            // ASSERT
            actual.Code.Value.Should().Be("SKU1");
            actual.ItemCodeValue.Should().Be("SKU1");
        }

        [TestMethod]
        public void ChangeDescription_WhenGivenNullDescription_ThrowsException()
        {
            // ARRANGE
            var item = new Item(code: new BusinessCode("1"), name: "Item 1");

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
            var actualItem = new Item(code: new BusinessCode("1"), name: "Item 1");
            var expectedDescription = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";
            
            // ACT
            actualItem.ChangeDescription(expectedDescription);

            // ASSERT
            actualItem.Description.Should().Be(expectedDescription);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("    ")]
        public void ChangeName_WhenGivenInvalidName_ThrowsException(string invalidName)
        {
            // ARRANGE
            var item = new Item(code: new BusinessCode("1"), name: "Item 1");

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => item.ChangeName(invalidName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ChangeName_WhenGivenValidValue_UpdatesTheItemName()
        {
            // ARRANGE
            var actualItem = new Item(code: new BusinessCode("1"), name: "Item 1");
            var expectedName = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";

            // ACT
            actualItem.ChangeName(expectedName);

            // ASSERT
            actualItem.Name.Should().Be(expectedName);
        }

        
    }
}
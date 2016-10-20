using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.LocationManagement.Domain;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.LocationManagement.Domain.Tests.Entities
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public  void Construct_WhenGivenDefaultGuid_ThrowsException()
        {
            // ARRANGE
            var id = default(Guid);
            var code = new BusinessCode("1");
            string name = "Location 1";

            // ACT
            Action action = () => new Location(id, code, name);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void Construct_WhenGivenEmptyGuid_ThrowsException()
        {
            // ARRANGE
            var id = Guid.Empty;
            var code = new BusinessCode("1");
            string name = "Location 1";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Location(id, code, name);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }


        [TestMethod]
        public void Construct_WhenGivenEmptyBusinessCode_ThrowsException()
        {
            // ARRANGE
            var code = BusinessCode.Empty;
            string name = "Location without a code";

            // ACT
            Action action = () => new Location(code: code, name: name);

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
            Action action = () => new Location(code: code, name: null);

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
            Action action = () => new Location(code: code, name: emptyName);

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
            Action action = () => new Location(code:code, name: nameWithOnlyWhitespace);

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
            var actual = new Location(code: code, name: name);

            // ASSERT
            actual.Name.Should().Be(name);
        }

        [TestMethod]
        public void Construction_WhenGivenValidLocationCode_SetsLocationCodeValueProperty()
        {
            // ARRANGE
            var code = new BusinessCode("STORE1");


            // ACT
            var actual = new Location(code: code, name: "Location 1 Test");

            // ASSERT
            actual.Code.Value.Should().Be("STORE1");
            actual.LocationCodeValue.Should().Be("STORE1");
        }

        [TestMethod]
        public void ChangeDescription_WhenGivenNullDescription_ThrowsException()
        {
            // ARRANGE
            var item = new Location(code: new BusinessCode("1"), name: "Location 1");

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => item.ChangeDescription(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ChangeDescription_WhenGivenValidValue_UpdatesTheLocationDescription()
        {
            // ARRANGE
            var actualLocation = new Location(code: new BusinessCode("1"), name: "Location 1");
            var expectedDescription = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";
            
            // ACT
            actualLocation.ChangeDescription(expectedDescription);

            // ASSERT
            actualLocation.Description.Should().Be(expectedDescription);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("    ")]
        public void ChangeName_WhenGivenInvalidName_ThrowsException(string invalidName)
        {
            // ARRANGE
            var item = new Location(code: new BusinessCode("1"), name: "Location 1");

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => item.ChangeName(invalidName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ChangeName_WhenGivenValidValue_UpdatesTheLocationName()
        {
            // ARRANGE
            var actualLocation = new Location(code: new BusinessCode("1"), name: "Location 1");
            var expectedName = "ABCDEFGHIJKLMNOPQRSTUVWXZ abcdefghijklmnopqrstuvwxyz 1234567890";

            // ACT
            actualLocation.ChangeName(expectedName);

            // ASSERT
            actualLocation.Name.Should().Be(expectedName);
        }

        
    }
}
//-----------------------------------------------------------------------
// <copyright file="LocationTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.LocationManagement.Domain.UnitTests.Tests.Entities
{
    using System;
    using Constants.ResultErrorKeys;
    using Domain.Entities;
    using FluentAssertions;
    using NUnit.Framework;
    using Shared.SharedKernel.CommonEntities;

    /// <summary>
    /// Tests the Location /&gt;
    /// </summary>
    [TestFixture]
    public class LocationTests
    {
        /// <summary>
        /// Given the create with Id method when supplied with default unique identifier then result
        /// is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithDefaultGuid_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = default(Guid);
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;

            // ACT
            var actual = Location.Create(id, businessCode, name, locationState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(LocationErrorKeys.IdIsDefaultOrEmpty);
        }

        /// <summary>
        /// Given the create with Id method when supplied with empty unique identifier then then
        /// result is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithEmptyGuid_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = Guid.Empty;
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;

            // ACT
            var actual = Location.Create(id, businessCode, name, locationState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(LocationErrorKeys.IdIsDefaultOrEmpty);
        }

        /// <summary>
        /// Given the create with Id method when supplied with null businessCode then then result is
        /// failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithNullCode_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCode = default(Code);
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;

            // ACT ReSharper disable once ExpressionIsAlwaysNull
            var actual = Location.Create(id, businessCode, name, locationState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(LocationErrorKeys.BusinessCodeIsNull);
        }

        /// <summary>
        /// Given the create with Id method when supplied with null name then then result is failure
        /// is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithNullName_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var name = default(Name);
            var locationState = LocationState.Active;

            // ACT ReSharper disable once ExpressionIsAlwaysNull
            var actual = Location.Create(id, businessCode, name, locationState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(LocationErrorKeys.NameIsNull);
        }

        /// <summary>
        /// Given the create with Id method when supplied with null LocationState then result is
        /// failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithNullLocationState_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = default(LocationState);

            // ACT ReSharper disable once ExpressionIsAlwaysNull
            var actual = Location.Create(id, businessCode, name, locationState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(LocationErrorKeys.LocationStateIsNull);
        }

        /// <summary>
        /// Given the create without Id method when supplied with null name then then result is
        /// failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithoutId_WhenSuppliedWithNullName_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var name = default(Name);
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;

            // ACT ReSharper disable once ExpressionIsAlwaysNull
            var actual = Location.Create(businessCode, name);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(LocationErrorKeys.NameIsNull);
        }

        /// <summary>
        /// Given the create without Id method when supplied with null businessCode then then result
        /// is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithoutId_WhenSuppliedWithNullBusinessCode_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var businessCode = default(Code);
            ////var expectedErrorMessage = string.Format(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace, argumentName);

            // ACT ReSharper disable once ExpressionIsAlwaysNull
            var actual = Location.Create(businessCode, name);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(LocationErrorKeys.BusinessCodeIsNull);
        }

        /// <summary>
        /// Given the name when after creation method with Id supplied and supplied valid name then
        /// returns constructed value.
        /// </summary>
        [Test]
        public void GivenName_WhenAfterCreationWithIdAndSuppliedValidName_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;

            // ACT
            var actual = Location.Create(id, businessCode, name, locationState);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Name.Should().Be(name);
        }

        /// <summary>
        /// Given the name when after creation method without Id supplied valid name then returns
        /// constructed value.
        /// </summary>
        [Test]
        public void GivenName_WhenAfterCreationWithoutIdAndSuppliedValidName_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;

            // ACT
            var actual = Location.Create(businessCode, name);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Name.Should().Be(name);
        }

        /// <summary>
        /// Given the businessCode when after creation method with Id supplied valid businessCode
        /// then returns constructed value.
        /// </summary>
        [Test]
        public void GivenBusinessCode_WhenAfterCreationWithIdAndSuppliedValidBusinessCode_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;

            // ACT
            var actual = Location.Create(id, businessCode, name, locationState);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.BusinessCode.Should().Be(businessCode);
        }

        /// <summary>
        /// Given the businessCode when after creation method without Id supplied valid businessCode
        /// then returns constructed value.
        /// </summary>
        [Test]
        public void GivenBusinessCode_WhenAfterCreationWithoutIdAndSuppliedValidBusinessCode_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;

            // ACT
            var actual = Location.Create(businessCode, name);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.BusinessCode.Should().Be(businessCode);
        }

        /// <summary>
        /// Given the location state after creation with Active LocationState returns active location state.
        /// </summary>
        [Test]
        public void GivenLocationState_WhenCreationWithActiveLocationState_ReturnsActiveLocationState()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;

            // ACT
            var actual = Location.Create(id, businessCode, name, locationState);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.LocationState.Should().Be(LocationState.Active);
        }

        /// <summary>
        /// Given the location state after creation without LocationState returns created location state.
        /// </summary>
        [Test]
        public void GivenLocationState_WhenAfterCreationWithoutLocationStateArgument_ReturnsCreatedLocationState()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;

            // ACT
            var actual = Location.Create(businessCode, name);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.LocationState.Should().Be(LocationState.Created);
        }

        /// <summary>
        /// Given the change business code method when given null code throws exception.
        /// </summary>
        [Test]
        public void GivenChangeBusinessCode_WhenGivenNullCode_ThrowsException()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;

            // ACT
            Action action = () => location.ChangeBusinessCode(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change business code method when given valid value updates the location.
        /// </summary>
        [Test]
        public void GivenChangeBusinessCode_WhenGivenValidValue_UpdatesTheLocationName()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;
            var codeUpdatedResult = Code.Create("C0001");
            var codeUpdated = codeUpdatedResult.Value;

            // ACT
            location.ChangeBusinessCode(codeUpdated);

            // ASSERT
            location.BusinessCode.Should().Be(codeUpdated);
        }

        /// <summary>
        /// Given the change name method when given null name throws exception.
        /// </summary>
        [Test]
        public void GivenChangeName_WhenGivenNullName_ThrowsException()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;

            // ACT
            Action action = () => location.ChangeName(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change name method when given valid value updates the location.
        /// </summary>
        [Test]
        public void GivenChangeName_WhenGivenValidValue_UpdatesTheLocationName()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var nameUpdatedResul = Name.Create("Location 1 Deluxe");
            var nameUpdated = nameUpdatedResul.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;

            // ACT
            location.ChangeName(nameUpdated);

            // ASSERT
            location.Name.Should().Be(nameUpdated);
        }

        /// <summary>
        /// Given the change description method when given null description throws exception.
        /// </summary>
        [Test]
        public void GivenChangeDescription_WhenGivenNullDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;
            var locationResult = Location.Create(id, businessCode, name, locationState);
            var location = locationResult.Value;

            // ACT
            Action action = () => location.ChangeDescription(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change description method when given valid value updates the location description.
        /// </summary>
        [Test]
        public void GivenChangeDescription_WhenGivenValidValue_UpdatesTheLocationDescription()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var descriptionUpdatedResult = ShortDescription.Create("Location One Deluxe");
            var descriptionUpdated = descriptionUpdatedResult.Value;
            var locationState = LocationState.Active;
            var locationResult = Location.Create(id, businessCode, name, locationState);
            var location = locationResult.Value;

            // ACT
            location.ChangeDescription(descriptionUpdated);

            // ASSERT
            location.Description.Should().Be(descriptionUpdated);
        }

        /// <summary>
        /// Given the change LocationState method when given null LocationState throws exception.
        /// </summary>
        [Test]
        public void GivenChangeLocationState_WhenGivenNullLocationState_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;
            var locationResult = Location.Create(id, businessCode, name, locationState);
            var location = locationResult.Value;

            // ACT
            Action action = () => location.ChangeLocationState(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change LocationState method when given valid value updates the location LocationState.
        /// </summary>
        [Test]
        public void GivenChangeLocationState_WhenGivenValidValue_UpdatesTheLocationLocationState()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationState = LocationState.Active;
            var locationResult = Location.Create(id, businessCode, name, locationState);
            var location = locationResult.Value;

            // ACT
            location.ChangeLocationState(LocationState.Deactivated);

            // ASSERT
            location.LocationState.Should().Be(LocationState.Deactivated);
        }
    }
}
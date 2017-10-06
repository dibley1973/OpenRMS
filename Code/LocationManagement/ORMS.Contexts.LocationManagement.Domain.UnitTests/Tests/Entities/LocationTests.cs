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
    using System.Linq;
    using Constants.ResultErrorKeys;
    using Domain.Entities;
    using FluentAssertions;
    using NUnit.Framework;
    using Shared.SharedKernel.Amplifiers;
    using Shared.SharedKernel.CommonValueObjects;

    /// <summary>
    /// Tests the Location
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
        /// Givens the type of the location type when after construction then returns not set location.
        /// </summary>
        [Test]
        public void GivenLocationType_WhenAfterConstruction_ThenReturnsNotSetLocationType()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;

            // ACT
            var actual = location.LocationType;

            // ASSERT
            actual.Name.Should().Be(LocationType.NotSet.Name);
            actual.Id.Should().Be(LocationType.NotSet.Id);
        }

        /// <summary>
        /// Givens the type of the location type when after construction then returns not set location.
        /// </summary>
        [Test]
        public void GivenLocationType_WhenCallingSetLocationType_ThenReturnsNotSetLocationType()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;
            var expectedTypeResult = LocationType.Create(Identity.Create(1).Value, (Name)"Warehouse");
            var expectedType = expectedTypeResult.Value;
            location.ChangeLocationType(expectedType);

            // ACT
            var actual = location.LocationType;

            // ASSERT
            actual.Name.Should().Be(LocationType.NotSet.Name);
            actual.Id.Should().Be(LocationType.NotSet.Id);
        }

        /// <summary>
        /// Givens the parent when class instatiated then parent is empty maybe.
        /// </summary>
        [Test]
        public void GivenParent_WhenClassInstatiated_ThenParentIsEmptyMaybe()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;

            // ACT
            var actual = location.Parent;

            // ASSERT
            actual.Should().Be(Maybe<Location>.Empty);
        }

        /// <summary>
        /// Given the parent when accessed after changing parent returns parent.
        /// </summary>
        [Test]
        public void GivenParent_WhenAccessedAfterChangingParent_ReturnsParent()
        {
            // ARRANGE
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;

            var parentBusinessCodeResult = Code.Create("L2");
            var parentBusinessCode = parentBusinessCodeResult.Value;
            var parentNameResult = Name.Create("Location 2");
            var parentName = parentNameResult.Value;
            var parentLocationResult = Location.Create(parentBusinessCode, parentName);
            var parentLocation = parentLocationResult.Value;
            location.ChangeParent(parentLocation);

            // ACT
            var actual = location.Parent;

            // ASSERT
            actual.Value.Should().BeSameAs(parentLocation);
        }

        /// <summary>
        /// Given the parent when accessed after changing parent returns parent.
        /// </summary>
        [Test]
        public void GivenParent_WhenAccessedAfterChangingParentAndRemoving_ReturnsEmptyMaybe()
        {
            // ARRANGE
            var expected = Maybe<Location>.Empty;
            var businessCodeResult = Code.Create("L1");
            var businessCode = businessCodeResult.Value;
            var nameResult = Name.Create("Location 1");
            var name = nameResult.Value;
            var locationResult = Location.Create(businessCode, name);
            var location = locationResult.Value;

            var parentBusinessCodeResult = Code.Create("L2");
            var parentBusinessCode = parentBusinessCodeResult.Value;
            var parentNameResult = Name.Create("Location 2");
            var parentName = parentNameResult.Value;
            var parentLocationResult = Location.Create(parentBusinessCode, parentName);
            var parentLocation = parentLocationResult.Value;
            location.ChangeParent(parentLocation);
            location.RemoveParent();

            // ACT
            var actual = location.Parent;

            // ASSERT
            actual.Should().Be(expected);
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

        /// <summary>
        /// Given the has sub locations when after instantiation then returns false.
        /// </summary>
        [Test]
        public void GivenHasSubLocations_WhenAfterInstantiation_ThenReturnsFalse()
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
            var actual = location.HasSubLocations;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the has sub locations when after adding sub location then returns true.
        /// </summary>
        [Test]
        public void GivenHasSubLocations_WhenAfterAddingSubLocation_ThenReturnsTrue()
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

            var subBusinessCodeResult = Code.Create("L2");
            var subBusinessCode = subBusinessCodeResult.Value;
            var subNameResult = Name.Create("Location 2");
            var subName = subNameResult.Value;
            var subLocationResult = Location.Create(subBusinessCode, subName);
            var subLocation = subLocationResult.Value;
            location.AddSubLocation(subLocation);

            // ACT
            var actual = location.HasSubLocations;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the sub locations when after instantiation then returns empty maybe.
        /// </summary>
        [Test]
        public void GivenSubLocations_WhenAfterInstantiation_ThenReturnsEmptyMaybe()
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
            var actual = location.SubLocations;

            // ASSERT
            actual.Should().NotBeNull();
            actual.HasNoValue.Should().BeTrue();
        }

        /// <summary>
        /// Given the sub locations when after adding one sub location then returns added sub location.
        /// </summary>
        [Test]
        public void GivenSubLocations_WhenAfterAddingOneSubLocation_ThenReturnsAddedSubLocation()
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

            var subBusinessCodeResult = Code.Create("L2");
            var subBusinessCode = subBusinessCodeResult.Value;
            var subNameResult = Name.Create("Location 2");
            var subName = subNameResult.Value;
            var subLocationResult = Location.Create(subBusinessCode, subName);
            var subLocation = subLocationResult.Value;
            location.AddSubLocation(subLocation);

            // ACT
            var actual = location.SubLocations;

            // ASSERT
            actual.Should().NotBeNull();
            actual.HasValue.Should().BeTrue();
            actual.Value.Should().NotBeEmpty();
            actual.Value.Should().HaveCount(1);
            actual.Value[0].Should().Be(subLocation);
        }

        /// <summary>
        /// Given the sub locations when after adding two sub locations then returns a count of two.
        /// </summary>
        [Test]
        public void GivenSubLocations_WhenAfterAddingTwoSubLocation_ThenReturnsCountOfTwo()
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

            var subBusinessCodeResult1 = Code.Create("L2");
            var subBusinessCode1 = subBusinessCodeResult1.Value;
            var subNameResult1 = Name.Create("Location 2");
            var subName1 = subNameResult1.Value;
            var subLocationResult1 = Location.Create(subBusinessCode1, subName1);
            var subLocation1 = subLocationResult1.Value;
            location.AddSubLocation(subLocation1);

            var subBusinessCodeResult2 = Code.Create("L3");
            var subBusinessCode2 = subBusinessCodeResult2.Value;
            var subNameResult2 = Name.Create("Location 3");
            var subName2 = subNameResult2.Value;
            var subLocationResult2 = Location.Create(subBusinessCode2, subName2);
            var subLocation2 = subLocationResult2.Value;
            location.AddSubLocation(subLocation2);

            // ACT
            var actual = location.SubLocations;

            // ASSERT
            actual.Should().NotBeNull();
            actual.HasValue.Should().BeTrue();
            actual.Value.Should().NotBeEmpty();
            actual.Value.Should().HaveCount(2);
            actual.Value.First().Should().Be(subLocation1);
            actual.Value.Last().Should().Be(subLocation2);
        }
    }
}
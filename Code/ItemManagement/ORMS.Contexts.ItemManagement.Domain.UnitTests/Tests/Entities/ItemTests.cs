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
    using Constants.ResultErrorKeys;
    using Domain.Entities;
    using FluentAssertions;
    using NUnit.Framework;
    using Shared.SharedKernel.CommonEntities;

    /// <summary>
    /// Tests the <see cref="Item"/>
    /// </summary>
    [TestFixture]
    public class ItemTests
    {
        /// <summary>
        /// Given the create with Id method when supplied with default unique identifier then result is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithDefaultGuid_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = default(Guid);
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;

            // ACT
            var actual = Item.Create(id, name, description, itemState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(ItemErrorKeys.IdIsNullOrEmpty);
        }

        /// <summary>
        /// Given the create with Id method when supplied with empty unique identifier then then result is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithEmptyGuid_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = Guid.Empty;
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;

            // ACT
            var actual = Item.Create(id, name, description, itemState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(ItemErrorKeys.IdIsNullOrEmpty);
        }

        /// <summary>
        /// Given the create with Id method when supplied with null name then then result is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithNullName_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var name = default(Name);
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;

            // ACT
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = Item.Create(id, name, description, itemState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(ItemErrorKeys.NameIsNull);
        }

        /// <summary>
        /// Given the create with Id method when supplied with null description then then result is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithNullDescription_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var description = default(ShortDescription);
            var itemState = ItemState.Active;

            // ACT
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = Item.Create(id, name, description, itemState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(ItemErrorKeys.DescriptionIsNull);
        }

        /// <summary>
        /// Given the create with Id method when supplied with null ItemState then result is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithId_WhenSuppliedWithNullItemState_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = default(ItemState);

            // ACT
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = Item.Create(id, name, description, itemState);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(ItemErrorKeys.ItemStateIsNull);
        }

        /// <summary>
        /// Given the create without Id method when supplied with null name then then result is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithoutId_WhenSuppliedWithNullName_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var name = default(Name);
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = Item.Create(name, description);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(ItemErrorKeys.NameIsNull);
        }

        /// <summary>
        /// Given the create without Id method when supplied with null description then then result is failure is true.
        /// </summary>
        [Test]
        public void GivenCreateWithoutId_WhenSuppliedWithNullDescription_ThenResultIsFailureIsTrue()
        {
            // ARRANGE
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var description = default(ShortDescription);

            // ACT
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = Item.Create(name, description);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(ItemErrorKeys.DescriptionIsNull);
        }

        /// <summary>
        /// Given the name when after creation method with Id supplied and supplied valid name then returns constructed value.
        /// </summary>
        [Test]
        public void GivenName_WhenAfterCreationWithIdAndSuppliedValidName_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;

            // ACT
            var actual = Item.Create(id, name, description, itemState);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Name.Should().Be(name);
        }

        /// <summary>
        /// Given the name when after creation method without Id supplied valid name then returns constructed value.
        /// </summary>
        [Test]
        public void GivenName_WhenAfterCreationWithoutIdAndSuppliedValidName_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            var actual = Item.Create(name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Name.Should().Be(name);
        }

        /// <summary>
        /// Given the description when after creation method with Id supplied valid description then returns constructed value.
        /// </summary>
        [Test]
        public void GivenDescription_WhenAfterCreationWithIdAndSuppliedValidDescription_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;

            // ACT
            var actual = Item.Create(id, name, description, itemState);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Description.Should().Be(description);
        }

        /// <summary>
        /// Given the description when after creation method without Id supplied valid description then returns constructed value.
        /// </summary>
        [Test]
        public void GivenDescription_WhenAfterCreationWithoutIdAndSuppliedValidDescription_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            var actual = Item.Create(name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Description.Should().Be(description);
        }

        /// <summary>
        /// Given the item state after creation with Active ItemState returns active item state.
        /// </summary>
        public void GivenItemState_WhenCreationWithActiveItemState_ReturnsActiveItemState()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;

            // ACT
            var actual = Item.Create(id, name, description, itemState);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.ItemState.Should().Be(ItemState.Active);
        }

        /// <summary>
        /// Given the item state after creation without ItemState returns created item state.
        /// </summary>
        public void GivenItemState_WhenAfterCreationWithoutItemStateArgument_ReturnsCreatedItemState()
        {
            // ARRANGE
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            var actual = Item.Create(name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.IsSuccess.Should().BeTrue();
            actual.Value.ItemState.Should().Be(ItemState.Created);
        }

        /// <summary>
        /// Given the change code method when given null code throws exception.
        /// </summary>
        [Test]
        public void GivenChangeCode_WhenGivenNullCode_ThrowsException()
        {
            // ARRANGE
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemResult = Item.Create(name, description);
            var item = itemResult.Value;

            // ACT
            Action action = () => item.ChangeCode(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change code method when given valid value updates the item.
        /// </summary>
        [Test]
        public void GivenChangeCode_WhenGivenValidValue_UpdatesTheItemName()
        {
            // ARRANGE
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemResult = Item.Create(name, description);
            var item = itemResult.Value;
            var codeUpdatedResult = Code.Create("C0001");
            var codeUpdated = codeUpdatedResult.Value;

            // ACT
            item.ChangeCode(codeUpdated);

            // ASSERT
            item.Code.Should().Be(codeUpdated);
        }

        /// <summary>
        /// Given the change name method when given null name throws exception.
        /// </summary>
        [Test]
        public void GivenChangeName_WhenGivenNullName_ThrowsException()
        {
            // ARRANGE
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemResult = Item.Create(name, description);
            var item = itemResult.Value;

            // ACT
            Action action = () => item.ChangeName(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change name method when given valid value updates the item.
        /// </summary>
        [Test]
        public void GivenChangeName_WhenGivenValidValue_UpdatesTheItemName()
        {
            // ARRANGE
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var nameUpdatedResul = Name.Create("Item 1 Deluxe");
            var nameUpdated = nameUpdatedResul.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemResult = Item.Create(name, description);
            var item = itemResult.Value;

            // ACT
            item.ChangeName(nameUpdated);

            // ASSERT
            item.Name.Should().Be(nameUpdated);
        }

        /// <summary>
        /// Given the change description method when given null description throws exception.
        /// </summary>
        [Test]
        public void GivenChangeDescription_WhenGivenNullDescription_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;
            var itemResult = Item.Create(id, name, description, itemState);
            var item = itemResult.Value;

            // ACT
            Action action = () => item.ChangeDescription(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change description method when given valid value updates the item description.
        /// </summary>
        [Test]
        public void GivenChangeDescription_WhenGivenValidValue_UpdatesTheItemDescription()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var descriptionUpdatedResult = ShortDescription.Create("Item One Deluxe");
            var descriptionUpdated = descriptionUpdatedResult.Value;
            var itemState = ItemState.Active;
            var itemResult = Item.Create(id, name, description, itemState);
            var item = itemResult.Value;

            // ACT
            item.ChangeDescription(descriptionUpdated);

            // ASSERT
            item.Description.Should().Be(descriptionUpdated);
        }

        /// <summary>
        /// Given the change ItemState method when given null ItemState throws exception.
        /// </summary>
        [Test]
        public void GivenChangeItemState_WhenGivenNullItemState_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;
            var itemResult = Item.Create(id, name, description, itemState);
            var item = itemResult.Value;

            // ACT
            Action action = () => item.ChangeItemState(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the change ItemState method when given valid value updates the item ItemState.
        /// </summary>
        [Test]
        public void GivenChangeItemState_WhenGivenValidValue_UpdatesTheItemItemState()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var itemState = ItemState.Active;
            var itemResult = Item.Create(id, name, description, itemState);
            var item = itemResult.Value;

            // ACT
            item.ChangeItemState(ItemState.Deactivated);

            // ASSERT
            item.ItemState.Should().Be(ItemState.Deactivated);
        }
    }
}
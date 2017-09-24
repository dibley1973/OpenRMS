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
        /// Given the construction when supplied with default unique identifier then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithDefaultGuid_ThenThrowsException()
        {
            // ARRANGE
            var id = default(Guid);
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () =>
            {
                new Item(id, name, description);
            };

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
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

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
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, null, description);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the construction when supplied with null name then throws exception.
        /// </summary>
        [Test]
        public void GivenConstruction_WhenSuppliedWithNullItemState_ThenThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Item(id, name, description, null);

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
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            var actual = new Item(id, name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
        }

        /// <summary>
        /// Given the description when constructor given valid value then returns constructed value.
        /// </summary>
        [Test]
        public void GivenDescription_WhenConstructorGivenValidValue_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;

            // ACT
            var actual = new Item(id, name, description);

            // ASSERT
            actual.Should().NotBeNull();
            actual.Description.Should().Be(description);
        }

        /// <summary>
        /// Given the state of the item state when constructed returns created item.
        /// </summary>
        public void GivenItemState_WhenConstructed_ReturnsCreatedItemState()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var item = new Item(id, name, description);

            // ACT
            var actual = item.ItemState;

            // ASSERT
            actual.Should().Be(ItemState.Created);
        }

        /// <summary>
        /// Given the state of the item state when constructed returns created item.
        /// </summary>
        public void GivenItemState_WhenConstructedWithActiveItemState_ReturnsActiveItemState()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var item = new Item(id, name, description, ItemState.Active);

            // ACT
            var actual = item.ItemState;

            // ASSERT
            actual.Should().Be(ItemState.Active);
        }

        /// <summary>
        /// Given the change code method when given null name throws exception.
        /// </summary>
        [Test]
        public void GivenChangeCode_WhenGivenNullName_ThrowsException()
        {
            // ARRANGE
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var item = new Item(id, name, description);

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
            var id = Guid.NewGuid();
            var codeUpdatedResult = Code.Create("C0001");
            var codeUpdated = codeUpdatedResult.Value;
            var nameResult = Name.Create("Item 1");
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var item = new Item(id, nameResult.Value, description);

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
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var item = new Item(id, name, description);

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
            var id = Guid.NewGuid();
            var nameResult = Name.Create("Item 1");
            var name = nameResult.Value;
            var nameUpdatedResul = Name.Create("Item 1 Deluxe");
            var nameUpdated = nameUpdatedResul.Value;
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var item = new Item(id, name, description);

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
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var item = new Item(id, nameResult.Value, description);

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
            var descriptionResult = ShortDescription.Create("Item One");
            var description = descriptionResult.Value;
            var descriptionUpdatedResult = ShortDescription.Create("Item One Deluxe");
            var descriptionUpdated = descriptionUpdatedResult.Value;
            var item = new Item(id, nameResult.Value, description);

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
            var item = new Item(id, name, description);

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
            var item = new Item(id, name, description);

            // ACT
            item.ChangeItemState(ItemState.Deactivated);

            // ASSERT
            item.ItemState.Should().Be(ItemState.Deactivated);
        }
    }
}
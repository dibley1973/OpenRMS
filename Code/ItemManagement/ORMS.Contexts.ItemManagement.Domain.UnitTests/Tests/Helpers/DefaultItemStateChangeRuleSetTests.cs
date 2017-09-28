//-----------------------------------------------------------------------
// <copyright file="DefaultItemStateChangeRuleSetTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.UnitTests.Tests.Helpers
{
    using Domain.Entities;
    using Domain.Helpers;
    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="DefaultItemStateChangeRuleSet"/>
    /// </summary>
    [TestFixture]
    public class DefaultItemStateChangeRuleSetTests
    {
        /// <summary>
        /// Given the can change function when supplied with invalid state options then retursn false.
        /// </summary>
        [Test]
        public void GivenCanChange_WhenSuppliedWithInvalidStateOptions_ThenRetursnFalse()
        {
            // ARRANGE
            var currentState = ItemState.Created;
            var newState = ItemState.Deactivated;
            var ruleSet = new DefaultItemStateChangeRuleSet();

            // ACT
            var actual = ruleSet.CanChange(currentState, newState);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the can change function when supplied with Created to Active then retursn true.
        /// </summary>
        [Test]
        public void GivenCanChange_WhenSuppliedWithCreatedToActive_ThenReturnsTrue()
        {
            // ARRANGE
            var currentState = ItemState.Created;
            var newState = ItemState.Active;
            var ruleSet = new DefaultItemStateChangeRuleSet();

            // ACT
            var actual = ruleSet.CanChange(currentState, newState);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the can change function when supplied with Active to Deactivated then retursn true.
        /// </summary>
        [Test]
        public void GivenCanChange_WhenSuppliedWithActiveToDeactivated_ThenReturnsTrue()
        {
            // ARRANGE
            var currentState = ItemState.Active;
            var newState = ItemState.Deactivated;
            var ruleSet = new DefaultItemStateChangeRuleSet();

            // ACT
            var actual = ruleSet.CanChange(currentState, newState);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the can change function when supplied with Active to Discontinued then retursn true.
        /// </summary>
        [Test]
        public void GivenCanChange_WhenSuppliedWithActiveToDiscontinued_ThenReturnsTrue()
        {
            // ARRANGE
            var currentState = ItemState.Active;
            var newState = ItemState.Discontinued;
            var ruleSet = new DefaultItemStateChangeRuleSet();

            // ACT
            var actual = ruleSet.CanChange(currentState, newState);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the can change function when supplied with Deactivated to Active then retursn true.
        /// </summary>
        [Test]
        public void GivenCanChange_WhenSuppliedWithDeactivatedToActive_ThenReturnsTrue()
        {
            // ARRANGE
            var currentState = ItemState.Deactivated;
            var newState = ItemState.Active;
            var ruleSet = new DefaultItemStateChangeRuleSet();

            // ACT
            var actual = ruleSet.CanChange(currentState, newState);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the can change function when supplied with Deactivated to Discontinued then retursn true.
        /// </summary>
        [Test]
        public void GivenCanChange_WhenSuppliedWithDeactivatedToDiscontinued_ThenReturnsTrue()
        {
            // ARRANGE
            var currentState = ItemState.Deactivated;
            var newState = ItemState.Discontinued;
            var ruleSet = new DefaultItemStateChangeRuleSet();

            // ACT
            var actual = ruleSet.CanChange(currentState, newState);

            // ASSERT
            actual.Should().BeTrue();
        }
    }
}
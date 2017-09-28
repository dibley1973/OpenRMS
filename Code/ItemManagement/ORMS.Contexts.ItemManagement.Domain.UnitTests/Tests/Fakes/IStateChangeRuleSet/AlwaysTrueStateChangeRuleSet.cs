//-----------------------------------------------------------------------
// <copyright file="AlwaysTrueStateChangeRuleSet.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.UnitTests.Tests.Fakes.IStateChangeRuleSet
{
    using Domain.Entities;
    using Shared.SharedKernel.Contracts;

    /// <summary>
    /// A fake state change rule set that always returns <c>true</c>.
    /// </summary>
    /// <seealso cref="IStateChangeRuleSet{ItemState}" />
    public class AlwaysTrueStateChangeRuleSet : IStateChangeRuleSet<ItemState>
    {
        /// <summary>
        /// Determines whether there is a rule to allow the specified current
        /// state to change to the specified new state.
        /// </summary>
        /// <param name="currentState">State of the current.</param>
        /// <param name="newState">The new state.</param>
        /// <returns>
        /// Always returns <c>true</c> regardless of states provided.
        /// </returns>
        public bool CanChange(ItemState currentState, ItemState newState)
        {
            return true;
        }
    }
}
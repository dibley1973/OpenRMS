//-----------------------------------------------------------------------
// <copyright file="DefaultItemStateChangeRuleSet.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.Helpers
{
    using System.Collections.Generic;
    using Entities;
    using Shared.SharedKernel.Contracts;

    /// <summary>
    /// Represents a set of rules
    /// </summary>
    public class DefaultItemStateChangeRuleSet : IStateChangeRuleSet<ItemState>
    {
        private readonly Dictionary<ItemState, List<ItemState>> _ruleSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultItemStateChangeRuleSet"/> class.
        /// </summary>
        public DefaultItemStateChangeRuleSet()
        {
            _ruleSet = new Dictionary<ItemState, List<ItemState>>
            {
                { ItemState.Created, new List<ItemState> { ItemState.Active } },
                { ItemState.Active, new List<ItemState> { ItemState.Deactivated, ItemState.Discontinued } },
                { ItemState.Deactivated, new List<ItemState> { ItemState.Active, ItemState.Discontinued } }
            };
        }

        /// <summary>
        /// Determines whether there is a rule to allow the specified current
        /// state to change to the specified new state.
        /// </summary>
        /// <param name="currentState">State of the current.</param>
        /// <param name="newState">The new state.</param>
        /// <seealso cref="ItemState"/>
        /// <returns>
        ///   <c>true</c> if the currentState can change to the newState; otherwise, <c>false</c>.
        /// </returns>
        public bool CanChange(ItemState currentState, ItemState newState)
        {
            var currentStateDoesNotExistInRules = !_ruleSet.ContainsKey(currentState);
            if (currentStateDoesNotExistInRules) return false;

            var currentRuleSet = _ruleSet[currentState];

            var ruleDoesNotExist = !currentRuleSet.Contains(newState);
            if (ruleDoesNotExist) return false;

            return true;
        }
    }
}

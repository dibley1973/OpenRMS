//-----------------------------------------------------------------------
// <copyright file="IStateChangeRuleSet{TState}.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Contracts
{
    /// <summary>
    /// Defines the expected members for a state change ruleset
    /// </summary>
    /// <typeparam name="TState">The type of the state.</typeparam>
    public interface IStateChangeRuleSet<in TState>
    {
        /// <summary>
        /// Determines whether there is a rule to allow the specified current
        /// state to change to the specified new state.
        /// </summary>
        /// <param name="currentState">State of the current.</param>
        /// <param name="newState">The new state.</param>
        /// <returns>
        ///   <c>true</c> if the currentState can change to the newState; otherwise, <c>false</c>.
        /// </returns>
        bool CanChange(TState currentState, TState newState);
    }
}
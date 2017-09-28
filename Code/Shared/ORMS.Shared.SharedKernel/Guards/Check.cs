//-----------------------------------------------------------------------
// <copyright file="Check.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Guards
{
    using System;
    using System.Diagnostics;
    using Amplifiers;
    using Constants.ErrorKeys;

    /// <summary>
    /// Contains guard-clause implementation which return <see cref="Result"/> objects.
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Checks if the specified value is not null, and returns a <see cref="Result" /> indicating the state.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>
        /// Returns a <see cref="Result" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsNotNullResult(object value, string argumentName)
        {
            return value == null
                ? Result.Fail(CheckErrorKeys.ArgumentIsNull, argumentName)
                : Result.Ok();
        }

        /// <summary>
        /// Checks if the specified value is not null or empty, and returns a <see cref="Result" /> indicating the state.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>
        /// Returns a <see cref="Result" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsNotNullOrEmpty(string value, string argumentName)
        {
            return string.IsNullOrEmpty(value)
                ? Result.Fail(CheckErrorKeys.ArgumentIsNullOrEmpty, argumentName)
                : Result.Ok();
        }

        /// <summary>
        /// Checks if the specified value is not null, empty or white space, and returns a <see cref="Result" /> indicating the state.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>
        /// Returns a <see cref="Result" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsNotNullEmptyOrWhiteSpace(string value, string argumentName)
        {
            return string.IsNullOrWhiteSpace(value)
                ? Result.Fail(CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace, argumentName)
                : Result.Ok();
        }
    }
}
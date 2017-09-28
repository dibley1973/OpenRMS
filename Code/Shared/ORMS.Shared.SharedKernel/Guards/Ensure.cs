//-----------------------------------------------------------------------
// <copyright file="Ensure.cs" company="Chesil Media">
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
    using Constants.ErrorKeys;

    /// <summary>
    /// Contains guard-clause implementation
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        /// Ensures the specified value is not null, and throws an exception if it is.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNull(object value, string argumentName)
        {
            if (value == null) throw new ArgumentNullException(argumentName, EnsureErrorKeys.ArgumentIsNull);
        }

        /// <summary>
        /// Ensures the specified value is not null or empty, and throws an exception if it is.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNullOrEmpty(string value, string argumentName)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(argumentName, EnsureErrorKeys.ArgumentIsNotNullOrEmpty);
        }

        /// <summary>
        /// Ensures the specified value is not null, empty or white space and throws an exception if it is.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNullEmptyOrWhiteSpace(string value, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(argumentName, EnsureErrorKeys.ArgumentIsNotNullEmptyOrWhiteSpace);
        }
    }
}
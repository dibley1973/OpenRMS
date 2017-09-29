//-----------------------------------------------------------------------
// <copyright file="ErrorKeyBase.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Constants.ErrorKeys
{
    using Amplifiers;
    using Guards;

    /// <summary>
    /// The base class all error key classes should inherit from
    /// </summary>
    public abstract class ErrorKeyBase
    {
        /// <summary>
        /// The format string to use when formatting error keys and argument names
        /// </summary>
        public static readonly string FormatString = string.Concat("{0}", Delimiter, "{1}");

        /// <summary>
        /// The delimiter used for formatting
        /// </summary>
        protected const char Delimiter = ':';

        /// <summary>
        /// The expected element count
        /// </summary>
        protected const int ExpectedElementCount = 2;

        /// <summary>
        /// Tries to parses the specofoed formatted key. If it succeeds then a tuple containing the
        /// key and argument name is wrapped in a success result and returned. If it fails then a
        /// fail result is returned.
        /// </summary>
        /// <param name="formattedValue">The formatted value.</param>
        /// <returns>
        /// Returns a <see cref="Result{T}"/> that wraps a <see cref="ErrorKeyAndArgumentName"/> with
        /// the information parsed.
        /// </returns>
        public static Result<ErrorKeyAndArgumentName> TryParseFormattedKey(string formattedValue)
        {
            var formatElements = formattedValue.Split(Delimiter);
            var formatElementCount = formatElements.Length;
            if (formatElementCount != ExpectedElementCount)
            {
                return Result.Fail<ErrorKeyAndArgumentName>($"Incorrect number of elements. Expected {ExpectedElementCount}, got {formatElementCount}.");
            }

            var key = formatElements[0];
            var argumentName = formatElements[1];
            var resultValue = ErrorKeyAndArgumentName.Create(key, argumentName);

            return Result.Ok(resultValue);
        }
    }
}
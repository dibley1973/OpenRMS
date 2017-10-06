//-----------------------------------------------------------------------
// <copyright file="ArgumentName.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Guards
{
    using System;
    using Amplifiers;
    using BaseClasses;
    using Constants.ErrorKeys;

    /// <summary>
    /// Represents the name of an argument
    /// </summary>
    /// <seealso cref="ORMS.Shared.SharedKernel.BaseClasses.NameBase"/>
    public class ArgumentName : NameBase
    {
        /// <summary>
        /// The maximum number of characters this instance can be.
        /// </summary>
        public new const byte MaximumCharacterLength = 255;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentName"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if value is null, empty or white space.
        /// </exception>
        protected ArgumentName(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="ArgumentName"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ArgumentName(string value)
        {
            var nameResult = Create(value);
            Func<string> errorMessageCallback = () => nameResult.Error;

            Ensure.IsNotInvalidCast(nameResult.IsSuccess, errorMessageCallback);

            return nameResult.Value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="ArgumentName"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(ArgumentName name)
        {
            return name.Value;
        }

        /// <summary>
        /// If the specified value is valid then creates and returns a new instance of the <see
        /// cref="ArgumentName"/> class using the value and wraps it in an Ok <see cref="Result"/>;
        /// otherwise creates a fail <see cref="Result{ArgumentName}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Result{Name}"/>.</returns>
        /// Thrown if value length exceeds
        /// <see cref="MaximumCharacterLength"/>
        /// .
        public static Result<ArgumentName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Result.Fail<ArgumentName>(NameErrorKeys.IsNullEmptyOrWhiteSpace);
            if (value.Length > MaximumCharacterLength) return Result.Fail<ArgumentName>(NameErrorKeys.IsTooLong);

            return Result.Ok(CreateInternal(value));
        }

        /// <summary>
        /// Internal method to create a <see cref="ArgumentName"/> object.
        /// Warning: This function bypasses argument validation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="ArgumentName"/>.</returns>
        private static ArgumentName CreateInternal(string value)
        {
            return new ArgumentName(value);
        }
    }
}
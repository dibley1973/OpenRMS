//-----------------------------------------------------------------------
// <copyright file="ResultCommonLogic.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Amplifiers
{
    using System;
    using System.Diagnostics;
    using Guards;

    /// <summary>
    /// Encapsulates the common logic for the results
    /// </summary>
    internal sealed class ResultCommonLogic
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _error;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultCommonLogic"/> class.
        /// </summary>
        /// <param name="isFailure">if set to <c>true</c> [is failure].</param>
        /// <param name="error">The error.</param>
        /// <exception cref="ArgumentNullException">
        /// error - There must be error message for failure.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// There should be no error message for success. - error
        /// </exception>
        [DebuggerStepThrough]
        public ResultCommonLogic(bool isFailure, string error)
        {
            if (isFailure)
            {
                Ensure.IsNotNullEmptyOrWhiteSpace(error, "There must be error message for failure.");
                ////if (string.IsNullOrEmpty(error))
                ////    throw new ArgumentNullException(nameof(error), "There must be error message for failure.");
            }
            else
            {
                if (error != null)
                    throw new ArgumentException("There should be no error message for success.", nameof(error));
            }

            IsFailure = isFailure;
            _error = error;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is failure.
        /// </summary>
        /// <value><c>true</c> if this instance is failure; otherwise, <c>false</c>.</value>
        public bool IsFailure { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is success.
        /// </summary>
        /// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
        public bool IsSuccess => !IsFailure;

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>The error.</value>
        /// <exception cref="InvalidOperationException">There is no error message for success.</exception>
        public string Error
        {
            [DebuggerStepThrough]
            get
            {
                Ensure.IsNotInvalidOperation(IsFailure, "There is no error message for success.");

                return _error;
            }
        }
    }
}
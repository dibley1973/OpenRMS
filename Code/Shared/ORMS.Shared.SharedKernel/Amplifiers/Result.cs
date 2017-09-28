//-----------------------------------------------------------------------
// <copyright file="Result.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Amplifiers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Indicates the success of a request.
    /// </summary>
    /// <remarks>
    /// If this class needs to implement `ISerializable` then refer to:
    /// https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result.cs
    /// </remarks>
    public struct Result
    {
        private static readonly Result OkResult = new Result(false, null);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> struct.
        /// </summary>
        /// <param name="isFailure">if set to <c>true</c> [is failure].</param>
        /// <param name="error">The error.</param>
        [DebuggerStepThrough]
        private Result(bool isFailure, string error)
        {
            _logic = new ResultCommonLogic(isFailure, error);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is failure.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is failure; otherwise, <c>false</c>.
        /// </value>
        public bool IsFailure => _logic.IsFailure;

        /// <summary>
        /// Gets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess => _logic.IsSuccess;

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Error => _logic.Error;

        /// <summary>
        /// Creates and returns an Ok <see cref="Result"/>
        /// </summary>
        /// <returns>A newly created Ok <see cref="Result"/>.</returns>
        [DebuggerStepThrough]
        public static Result Ok()
        {
            return OkResult;
        }

        /// <summary>
        /// Creates and returns a fail <see cref="Result"/> with the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>A newly created fail <see cref="Result"/>.</returns>
        [DebuggerStepThrough]
        public static Result Fail(string error)
        {
            return new Result(true, error);
        }

        /// <summary>
        /// Creates and returns a fail <see cref="Result" /> with the specified error.
        /// </summary>
        /// <param name="errorFormatString">A composite format error string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>
        /// A newly created fail <see cref="Result" />.
        /// </returns>
        [DebuggerStepThrough]
        public static Result Fail(string errorFormatString, params object[] args)
        {
            var message = string.Format(errorFormatString, args);
            return Result.Fail(message);
        }

        /// <summary>
        /// Creates and returns an Oks <see cref="Result{T}"/> using the specified value.
        /// </summary>
        /// <typeparam name="T">Represents the type of the value the result wraps.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A newly created fail <see cref="Result{T}"/></returns>
        [DebuggerStepThrough]
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(false, value, null);
        }

        /// <summary>
        /// Creates and returns a fail <see cref="Result{T}"/> with the specified error.
        /// </summary>
        /// <typeparam name="T">>Represents the type of the value the result would wrap.</typeparam>
        /// <param name="error">A message which represents the error which prevented a result being returned.</param>
        /// <returns>A newly created fail <see cref="Result{T}"/></returns>
        [DebuggerStepThrough]
        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(true, default(T), error);
        }

        /// <summary>
        /// Returns first failure in the list of <paramref name="results"/>. If there is no failure returns success.
        /// </summary>
        /// <param name="results">List of results.</param>
        /// <returns>The first fail <see cref="Result"/> if found, otherwise a success <see cref="Result"/></returns>
        [DebuggerStepThrough]
        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                    return Fail(result.Error);
            }

            return Ok();
        }

        /// <summary>
        /// Returns a failure which is combined from all failures in the <paramref name="results"/> array.
        /// Error messages are separated by <paramref name="errorMessagesSeparator"/>.
        /// If there is no failure returns success.
        /// </summary>
        /// <param name="errorMessagesSeparator">Separator for error messages.</param>
        /// <param name="results">List of results.</param>
        /// <returns>A fail <see cref="Result"/> if any fails exist, or a success <see cref="Result"/></returns>
        [DebuggerStepThrough]
        public static Result Combine(string errorMessagesSeparator, params Result[] results)
        {
            List<Result> failedResults = results.Where(x => x.IsFailure).ToList();

            if (!failedResults.Any())
                return Ok();

            string errorMessage = string.Join(errorMessagesSeparator, failedResults.Select(x => x.Error).ToArray());
            return Fail(errorMessage);
        }

        /// <summary>
        /// Returns a failure which is combined from all failures in the <paramref name="results"/> array.
        /// If there is no failure returns success.
        /// </summary>
        /// <param name="results">List of results.</param>
        /// <returns>A fail <see cref="Result"/> if any fails exist, or a success <see cref="Result"/></returns>
        [DebuggerStepThrough]
        public static Result Combine(params Result[] results)
        {
            return Combine(", ", results);
        }

        /// <summary>
        /// Returns a failure which is combined from all failures in the <paramref name="results" /> array.
        /// If there is no failure returns success.
        /// </summary>
        /// <typeparam name="T">>Represents the type of the value the result wraps.</typeparam>
        /// <param name="results">List of results.</param>
        /// <returns>
        /// A fail <see cref="Result" /> if any fails exist, or a success <see cref="Result" />
        /// </returns>
        [DebuggerStepThrough]
        public static Result Combine<T>(params Result<T>[] results)
        {
            return Combine(", ", results);
        }

        /// <summary>
        /// Returns a failure which is combined from all failures in the <paramref name="results"/> array.
        /// Error messages are separated by <paramref name="errorMessagesSeparator"/>.
        /// If there is no failure returns success.
        /// </summary>
        /// <typeparam name="T">>Represents the type of the value the result wraps.</typeparam>
        /// <param name="errorMessagesSeparator">Separator for error messages.</param>
        /// <param name="results">List of results.</param>
        /// <returns>A fail <see cref="Result"/> if any fails exist, or a success <see cref="Result"/></returns>
        [DebuggerStepThrough]
        public static Result Combine<T>(string errorMessagesSeparator, params Result<T>[] results)
        {
            Result[] untyped = results.Select(result => (Result)result).ToArray();

            return Combine(errorMessagesSeparator, untyped);
        }
    }

    /// <summary>
    /// Indicates the success of a request, and wraps the resultant object
    /// in the case of a successful call.
    /// </summary>
    /// <typeparam name="T">The type which the result wraps</typeparam>
    /// <remarks>
    /// If this class needs to implement `ISerializable` then refer to:
    /// https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result.cs
    /// </remarks>
    public struct Result<T>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> struct.
        /// </summary>
        /// <param name="isFailure">if set to <c>true</c> is the result is a failure.</param>
        /// <param name="value">The value.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="ArgumentNullException">value</exception>
        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, string error)
        {
            if (!isFailure && value == null)
                throw new ArgumentNullException(nameof(value));

            _logic = new ResultCommonLogic(isFailure, error);
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is failure.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is failure; otherwise, <c>false</c>.
        /// </value>
        public bool IsFailure => _logic.IsFailure;

        /// <summary>
        /// Gets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess => _logic.IsSuccess;

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Error => _logic.Error;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        /// <exception cref="InvalidOperationException">There is no value for failure.</exception>
        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException("There is no value for failure.");

                return _value;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Result{T}"/> to <see cref="Result"/>.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Result(Result<T> result)
        {
            return result.IsSuccess
                ? Result.Ok()
                : Result.Fail(result.Error);
        }
    }
}

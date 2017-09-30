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
        /// Checks if the specified value is not null, and returns a <see cref="Result"/> indicating
        /// the state.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>Returns a <see cref="Result"/>.</returns>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsNotNull(object value, ArgumentName argumentName)
        {
            return value == null
                ? Result.Fail(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNull, argumentName.Value)
                : Result.Ok();
        }

        /// <summary>
        /// Checks if the specified value is not null, and returns a <see cref="Result"/> indicating
        /// the state.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errorMesasge">The error mesasge.</param>
        /// <returns>Returns a <see cref="Result"/>.</returns>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsNotNull(object value, string errorMesasge)
        {
            return value == null
                ? Result.Fail(errorMesasge)
                : Result.Ok();
        }

        /// <summary>
        /// Checks if the specified value is not null or empty, and returns a <see cref="Result"/>
        /// indicating the state.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>Returns a <see cref="Result"/>.</returns>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsNotNullOrEmpty(string value, ArgumentName argumentName)
        {
            return string.IsNullOrEmpty(value)
                ? Result.Fail(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNullOrEmpty, argumentName)
                : Result.Ok();
        }

        /// <summary>
        /// Checks if the specified value is not null, empty or white space, and returns a <see
        /// cref="Result"/> indicating the state.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>Returns a <see cref="Result"/>.</returns>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsNotNullEmptyOrWhiteSpace(string value, ArgumentName argumentName)
        {
            return string.IsNullOrWhiteSpace(value)
                ? Result.Fail(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace, argumentName)
                : Result.Ok();
        }

        /// <summary>
        /// Checks whether the first specified <see cref="IEquatable{T}"/> is equal to the second
        /// <see cref="IEquatable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Defines the type to check and the type the result wraps</typeparam>
        /// <param name="first">The first <see cref="IEquatable{T}"/> item.</param>
        /// <param name="second">The second <see cref="IEquatable{T}"/> item.</param>
        /// <param name="errorMessage">
        /// The error message which the <see cref="Result{T}"/> carries in the event that the first
        /// is not equal to the second.
        /// </param>
        /// <returns>Returns a <see cref="Result{T}"/></returns>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsEqual<T>(IEquatable<T> first, IEquatable<T> second, string errorMessage)
        {
            return first.Equals(second)
                ? Result.Ok()
                : Result.Fail(errorMessage);
        }

        /// <summary>
        /// Checks whether the first specified <see cref="IEquatable{T}"/> is not equal to the second
        /// <see cref="IEquatable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Defines the type to check and the type the result wraps</typeparam>
        /// <param name="first">The first <see cref="IEquatable{T}"/> item.</param>
        /// <param name="second">The second <see cref="IEquatable{T}"/> item.</param>
        /// <param name="errorMessage">
        /// The error message which the <see cref="Result{T}"/> carries in the event that the first
        /// is equal to the second.
        /// </param>
        /// <returns>Returns a <see cref="Result{T}"/></returns>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static Result IsNotEqual<T>(IEquatable<T> first, IEquatable<T> second, string errorMessage)
        {
            return !first.Equals(second)
                ? Result.Ok()
                : Result.Fail(errorMessage);
        }

        /// <summary>
        /// Determines whether the specified callBack predicate returns <c>true</c>, if it does then
        /// a success result is returned, otherwise a fail result is returned.
        /// </summary>
        /// <param name="callBackPredicate">
        /// The predicate which this function should call to determine what result to return.
        /// </param>
        /// <param name="errorMessage">
        /// The error message which the <see cref="Result"/> carries in the event that the callback
        /// returns <c>false</c>.
        /// </param>
        /// <returns>Returns a <see cref="Result"/></returns>
        public static Result IsTrue(Func<bool> callBackPredicate, string errorMessage)
        {
            return callBackPredicate()
                ? Result.Ok()
                : Result.Fail(errorMessage);
        }

        /// <summary>
        /// Determines whether the specified callBack predicate returns <c>false</c>, if it does then
        /// a success result is returned, otherwise a fail result is returned.
        /// </summary>
        /// <param name="callBackPredicate">
        /// The predicate which this function should call to determine what result to return.
        /// </param>
        /// <param name="errorMessage">
        /// The error message which the <see cref="Result"/> carries in the event that the callback
        /// returns <c>true</c>.
        /// </param>
        /// <returns>Returns a <see cref="Result"/></returns>
        public static Result IsFalse(Func<bool> callBackPredicate, string errorMessage)
        {
            return !callBackPredicate()
                ? Result.Ok()
                : Result.Fail(errorMessage);
        }
    }
}
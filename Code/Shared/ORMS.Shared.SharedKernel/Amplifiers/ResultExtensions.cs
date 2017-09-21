//-----------------------------------------------------------------------
// <copyright file="ResultExtensions.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Amplifiers
{
    using System;

    /// <summary>
    /// Extensions for the <see cref="Result"/> class.
    /// </summary>
    public static class ResultExtensions
    {
        // TODO: Uncomment other extensions as required but write tests to cover them!
        // Ref:
        // https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/ResultExtensions.cs

        ////public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, K> func)
        ////{
        ////    if (result.IsFailure) return Result.Fail<K>(result.Error);

        ////    return Result.Ok(func(result.Value));
        ////}

        ////public static Result<T> OnSuccess<T>(this Result result, Func<T> func)
        ////{
        ////    if (result.IsFailure) return Result.Fail<T>(result.Error);

        ////    return Result.Ok(func());
        ////}

        ////public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, Result<K>> func)
        ////{
        ////    if (result.IsFailure) return Result.Fail<K>(result.Error);

        ////    return func(result.Value);
        ////}

        ////public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> func)
        ////{
        ////    if (result.IsFailure) return Result.Fail<T>(result.Error);

        ////    return func();
        ////}

        ////public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<Result<K>> func)
        ////{
        ////    if (result.IsFailure) return Result.Fail<K>(result.Error);

        ////    return func();
        ////}

        ////public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> func)
        ////{
        ////    if (result.IsFailure) return Result.Fail(result.Error);

        ////    return func(result.Value);
        ////}

        ////public static Result OnSuccess(this Result result, Func<Result> func)
        ////{
        ////    if (result.IsFailure) return result;

        ////    return func();
        ////}

        ////public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
        ////{
        ////    if (result.IsFailure) return Result.Fail<T>(result.Error);

        ////    if (!predicate(result.Value)) return Result.Fail<T>(errorMessage);

        ////    return Result.Ok(result.Value);
        ////}

        ////public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
        ////{
        ////    if (result.IsFailure) return Result.Fail(result.Error);

        ////    if (!predicate()) return Result.Fail(errorMessage);

        ////    return Result.Ok();
        ////}

        ////public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> func)
        ////{
        ////    if (result.IsFailure) return Result.Fail<K>(result.Error);

        ////    return Result.Ok(func(result.Value));
        ////}

        ////public static Result<T> Map<T>(this Result result, Func<T> func)
        ////{
        ////    if (result.IsFailure) return Result.Fail<T>(result.Error);

        ////    return Result.Ok(func());
        ////}

        ////public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        ////{
        ////    if (result.IsSuccess)
        ////    {
        ////        action(result.Value);
        ////    }

        ////    return result;
        ////}

        ////public static Result OnSuccess(this Result result, Action action)
        ////{
        ////    if (result.IsSuccess)
        ////    {
        ////        action();
        ////    }

        ////    return result;
        ////}

        ////public static T OnBoth<T>(this Result result, Func<Result, T> func)
        ////{
        ////    return func(result);
        ////}

        ////public static K OnBoth<T, K>(this Result<T> result, Func<Result<T>, K> func)
        ////{
        ////    return func(result);
        ////}

        /// <summary>
        /// Calls the specified action upon failure of this instance.
        /// </summary>
        /// <typeparam name="T">The type which the result wraps</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="action">The action.</param>
        /// <returns>Returns this instance of the result</returns>
        public static Result<T> OnFailure<T>(this Result<T> result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        /// <summary>
        /// Calls the specified action upon failure of this instance.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="action">The action.</param>
        /// <returns>Returns this instance of the result</returns>
        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        /// <summary>
        /// Calls the specified action upon failure of this instance.
        /// </summary>
        /// <typeparam name="T">The type which the result wraps</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="action">The action to be called if the result is a failure.</param>
        /// <returns>Returns this instance of the result</returns>
        public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        ////public static Result OnFailure(this Result result, Action<string> action)
        ////{
        ////    if (result.IsFailure)
        ////    {
        ////        action(result.Error);
        ////    }

        ////    return result;
        ////}
    }
}
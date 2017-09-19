//-----------------------------------------------------------------------
// <copyright file="CombineMethodTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.Amplifiers.ResultTests
{
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.Amplifiers;

    /// <summary>
    /// Tests the combine methods for the <see cref="Result"/>
    /// </summary>
    public class CombineMethodTests
    {
        /// <summary>
        /// Given the first failure or success where non generic result list is Ok-Fail-Fail then first failed resultis returned.
        /// </summary>
        [Test]
        public void GivenFirstFailureOrSuccess_WhereNonGenericResultListIsOkFailFail_ThenFirstFailedResultisReturned()
        {
            // ARRANGE
            var result1 = Result.Ok();
            var result2 = Result.Fail("Failure 1");
            var result3 = Result.Fail("Failure 2");

            // ACT
            var result = Result.FirstFailureOrSuccess(result1, result2, result3);

            // ASSERT
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Failure 1");
        }

        /// <summary>
        /// Given the first failure or success where non generic result list is all ok then is success is true.
        /// </summary>
        [Test]
        public void GivenFirstFailureOrSuccess_WhereNonGenericResultListIsAllOk_ThenIsSuccessIsTrue()
        {
            // ARRANGE
            var result1 = Result.Ok();
            var result2 = Result.Ok();
            var result3 = Result.Ok();

            // ACT
            var result = Result.FirstFailureOrSuccess(result1, result2, result3);

            // ASSERT
            result.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the combine method when combined results include errors then combines all errors together.
        /// </summary>
        [Test]
        public void GivenCombine_WhenCombinedResultsIncludeErrors_ThenCombinesAllErrorsTogether()
        {
            // ARRANGE
            var result1 = Result.Ok();
            var result2 = Result.Fail("Failure 1");
            var result3 = Result.Fail("Failure 2");

            // ACT
            var result = Result.Combine(";", result1, result2, result3);

            // ASSERT
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1;Failure 2");
        }

        /// <summary>
        /// Given the combine method when combined results are all ok then returns no failures.
        /// </summary>
        [Test]
        public void GivenCombine_WhenCombinedResultsAreAllOk_ThenReturnsNoFailures()
        {
            // ARRANGE
            var result1 = Result.Ok();
            var result2 = Result.Ok();
            var result3 = Result.Ok("Some string");

            // ACT
            var result = Result.Combine(";", result1, result2, result3);

            // ASSERT
            result.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the combine method when combined array of generic results then returns success.
        /// </summary>
        [Test]
        public void GivenCombine_WhenCombinedArrayOfGenericResults_ThenReturnsSuccess()
        {
            // ARRANGE
            Result<string>[] results = { Result.Ok(string.Empty), Result.Ok(string.Empty) };

            // ACT
            var result = Result.Combine(";", results);

            // ASSERT
            result.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the combine method when combined array of generic results where one is a failure then returns failure.
        /// </summary>
        [Test]
        public void GivenCombine_WhenCombinedArrayOfGenericResultsWhereOneIsAFailure_ThenReturnsFailure()
        {
            // ARRANGE
            Result<string>[] results = { Result.Ok(string.Empty), Result.Fail<string>("error") };

            // ACT
            var result = Result.Combine(";", results);

            // ASSERT
            result.IsSuccess.Should().BeFalse();
        }
    }
}
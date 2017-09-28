//-----------------------------------------------------------------------
// <copyright file="CheckTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.Guards
{
    using System.Text;
    using Constants.ErrorKeys;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.Guards;

    /// <summary>
    /// Tests the guard clauses>
    /// </summary>
    [TestFixture]
    public class CheckTests
    {
        /// <summary>
        /// Given the ensure is not null when passed a null object then returns fail result.
        /// </summary>
        [Test]
        public void GivenIsNotNullResult_WhenPassedANullObject_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            var actual = Check.IsNotNullResult(null, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CheckErrorKeys.ArgumentIsNull);
        }

        /// <summary>
        /// Given the ensure is not null when passed a not-null object then returns success result.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNull_WhenPassedANotNullObject_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var argumentName = "arg1";
            var argumentValue = new StringBuilder();

            // ACT
            var actual = Check.IsNotNullResult(argumentValue, argumentName);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the ensure is not null empty when passed null string then returns fail result.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmpty_WhenPassedNullString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            var actual = Check.IsNotNullOrEmpty(null, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CheckErrorKeys.ArgumentIsNullOrEmpty);
        }

        /// <summary>
        /// Given the ensure is not null empty when passed empty string then returns fail result.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmpty_WhenPassedEmptyString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = string.Empty;

            // ACT
            var actual = Check.IsNotNullOrEmpty(value, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CheckErrorKeys.ArgumentIsNullOrEmpty);
        }

        /// <summary>
        /// Given the ensure is not null or empty when passed populated string then returns success result.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullOrEmpty_WhenPassedPopulatedString_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string('A', 5);

            // ACT
            var actual = Check.IsNotNullOrEmpty(value, argumentName);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed null string then returns fail result.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedNullString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            var actual = Check.IsNotNullEmptyOrWhiteSpace(null, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed empty string then returns fail result.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedEmptyString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = string.Empty;

            // ACT
            var actual = Check.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed white space string then returns fail result.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedWhiteSpaceString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string(' ', 5);

            // ACT
            var actual = Check.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed populated string then returns success result.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedPopulatedString_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string('A', 5);

            // ACT
            var actual = Check.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }
    }
}

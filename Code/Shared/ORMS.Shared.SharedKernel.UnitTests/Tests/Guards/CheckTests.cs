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
    using System;
    using System.Text;
    using Constants.ErrorKeys;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.Guards;

    /// <summary>
    /// Tests the guard clauses&gt;
    /// </summary>
    [TestFixture]
    public class CheckTests
    {
        /// <summary>
        /// Given the Check function is not null when passed a null object then returns fail result.
        /// </summary>
        [Test]
        public void GivenIsNotNullResult_WhenPassedANullObject_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var expectedErrorMessage = string.Format(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNull, argumentName.Value);

            // ACT
            var actual = Check.IsNotNull(null, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(expectedErrorMessage);
        }

        /// <summary>
        /// Given the Check function is not null when passed a not-null object then returns success result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotNull_WhenPassedANotNullObject_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var argumentValue = new StringBuilder();

            // ACT
            var actual = Check.IsNotNull(argumentValue, argumentName);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the Check function is not null empty when passed null string then returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotNullEmpty_WhenPassedNullString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var expectedErrorMessage = string.Format(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNullOrEmpty, argumentName);

            // ACT
            var actual = Check.IsNotNullOrEmpty(null, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(expectedErrorMessage);
        }

        /// <summary>
        /// Given the Check function is not null empty when passed empty string then returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotNullEmpty_WhenPassedEmptyString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var value = string.Empty;
            var expectedErrorMessage = string.Format(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNullOrEmpty, argumentName);

            // ACT
            var actual = Check.IsNotNullOrEmpty(value, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(expectedErrorMessage);
        }

        /// <summary>
        /// Given the Check function is not null or empty when passed populated string then returns
        /// success result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotNullOrEmpty_WhenPassedPopulatedString_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var value = new string('A', 5);

            // ACT
            var actual = Check.IsNotNullOrEmpty(value, argumentName);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the Check function is not null empty or white space when passed null string then
        /// returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotNullEmptyOrWhiteSpace_WhenPassedNullString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var expectedErrorMessage = string.Format(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace, argumentName);

            // ACT
            var actual = Check.IsNotNullEmptyOrWhiteSpace(null, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(expectedErrorMessage);
        }

        /// <summary>
        /// Given the Check function is not null empty or white space when passed empty string then
        /// returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotNullEmptyOrWhiteSpace_WhenPassedEmptyString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var value = string.Empty;
            var expectedErrorMessage = string.Format(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace, argumentName);

            // ACT
            var actual = Check.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(expectedErrorMessage);
        }

        /// <summary>
        /// Given the Check function is not null empty or white space when passed white space string
        /// then returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotNullEmptyOrWhiteSpace_WhenPassedWhiteSpaceString_ThenReturnsFailResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var value = new string(' ', 5);
            var expectedErrorMessage = string.Format(ErrorKeyBase.FormatString, CheckErrorKeys.ArgumentIsNullEmptyOrWhiteSpace, argumentName);

            // ACT
            var actual = Check.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(expectedErrorMessage);
        }

        /// <summary>
        /// Given the Check function is not null, empty or white space when passed populated string
        /// then returns success result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotNullEmptyOrWhiteSpace_WhenPassedPopulatedString_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var argumentName = (ArgumentName)"arg1";
            var value = new string('A', 5);

            // ACT
            var actual = Check.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the check is equal when both items are equal returns success result.
        /// </summary>
        [Test]
        public void GivenCheckIsEqual_WhenBothItemsAreEqual_ReturnsSuccessResult()
        {
            // ARRANGE
            var item1 = Guid.Empty;
            var item2 = Guid.Empty;
            var errorMessage = "NotEqual";

            // ACT
            var actual = Check.IsEqual(item1, item2, errorMessage);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the check is equal when both items are not equal returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsEqual_WhenBothItemsAreNotEqual_ReturnsFailResult()
        {
            // ARRANGE
            var item1 = Guid.NewGuid();
            var item2 = Guid.NewGuid();
            var errorMessage = "NotEqual";

            // ACT
            var actual = Check.IsEqual(item1, item2, errorMessage);

            // ASSERT
            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(errorMessage);
        }

        /// <summary>
        /// Given the check is not equal when both items are equal returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotEqual_WhenBothItemsAreEqual_ReturnsFailResult()
        {
            // ARRANGE
            var item1 = Guid.Empty;
            var item2 = Guid.Empty;
            var errorMessage = "NotEqual";

            // ACT
            var actual = Check.IsNotEqual(item1, item2, errorMessage);

            // ASSERT
            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(errorMessage);
        }

        /// <summary>
        /// Given the check is not equal when both items are not equal returns success result.
        /// </summary>
        [Test]
        public void GivenCheckIsNotEqual_WhenBothItemsAreNotEqual_ReturnsSuccessResult()
        {
            // ARRANGE
            var item1 = Guid.NewGuid();
            var item2 = Guid.NewGuid();
            var errorMessage = "NotEqual";

            // ACT
            var actual = Check.IsNotEqual(item1, item2, errorMessage);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the check is true when both items are equal returns success result.
        /// </summary>
        [Test]
        public void GivenCheckIsTrue_WhenBothItemsAreEqual_ReturnsSuccessResult()
        {
            // ARRANGE
            var item1 = Guid.Empty;
            var item2 = Guid.Empty;
            var errorMessage = "NotTrue";
            Func<bool> isTrueCallback = () => { return item1 == item2; };

            // ACT
            var actual = Check.IsTrue(isTrueCallback, errorMessage);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the check is true when both items are not equal returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsTrue_WhenBothItemsAreNotEqual_ReturnsFailResult()
        {
            // ARRANGE
            var item1 = Guid.NewGuid();
            var item2 = Guid.NewGuid();
            var errorMessage = "NotTrue";
            Func<bool> isTrueCallback = () => { return item1 == item2; };

            // ACT
            var actual = Check.IsTrue(isTrueCallback, errorMessage);

            // ASSERT
            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(errorMessage);
        }

        /// <summary>
        /// Given the check is false when both items are equal returns fail result.
        /// </summary>
        [Test]
        public void GivenCheckIsFalse_WhenBothItemsAreEqual_ReturnsFailResult()
        {
            // ARRANGE
            var item1 = Guid.Empty;
            var item2 = Guid.Empty;
            var errorMessage = "NotFalse";
            Func<bool> isFalseCallback = () => { return item1 == item2; };

            // ACT
            var actual = Check.IsFalse(isFalseCallback, errorMessage);

            // ASSERT
            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(errorMessage);
        }

        /// <summary>
        /// Given the check is false when both items are not equal returns success result.
        /// </summary>
        [Test]
        public void GivenCheckIsFalse_WhenBothItemsAreNotEqual_ReturnsSuccessResult()
        {
            // ARRANGE
            var item1 = Guid.NewGuid();
            var item2 = Guid.NewGuid();
            var errorMessage = "NotFalse";
            Func<bool> isFalseCallback = () => { return item1 == item2; };

            // ACT
            var actual = Check.IsFalse(isFalseCallback, errorMessage);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }
    }
}
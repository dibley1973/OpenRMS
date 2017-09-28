//-----------------------------------------------------------------------
// <copyright file="EnsureTests.cs" company="Chesil Media">
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
    /// Tests the guard clauses>
    /// </summary>
    [TestFixture]
    public class EnsureTests
    {
        private const string ParameterNameSuffix = "\r\nParameter name: arg1";

        /// <summary>
        /// Given the ensure is not null when passed a null object then throws an exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNull_WhenPassedANullObject_ThenThrowsException()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            Action action = () => Ensure.IsNotNull(null, argumentName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNull + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null when passed a not-null object then does not throw and exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNull_WhenPassedANotNullObject_ThenDoesNotThrowException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var argumentValue = new StringBuilder();

            // ACT
            Action action = () => Ensure.IsNotNull(argumentValue, argumentName);

            // ASSERT
            action.ShouldNotThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the ensure is not null or empty when passed null string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullOrEmpty_WhenPassedNullString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            Action action = () => Ensure.IsNotNullOrEmpty(null, argumentName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNotNullOrEmpty + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null or empty when passed empty string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullOrEmpty_WhenPassedEmptyString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = string.Empty;

            // ACT
            Action action = () => Ensure.IsNotNullOrEmpty(value, argumentName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNotNullOrEmpty + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null or empty when passed populated string then does not throw exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullOrEmpty_WhenPassedPopulatedString_ThenDoesNotThrowException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string('A', 5);

            // ACT
            Action action = () => Ensure.IsNotNullOrEmpty(value, argumentName);

            // ASSERT
            action.ShouldNotThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed null string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedNullString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            Action action = () => Ensure.IsNotNullEmptyOrWhiteSpace(null, argumentName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNotNullEmptyOrWhiteSpace + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed empty string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedEmptyString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = string.Empty;

            // ACT
            Action action = () => Ensure.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNotNullEmptyOrWhiteSpace + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed white space string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedWhiteSpaceString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string(' ', 5);

            // ACT
            Action action = () => Ensure.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNotNullEmptyOrWhiteSpace + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed populated string then does not thow exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedPopulatedString_ThenDoesNotThowException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string('A', 5);

            // ACT
            Action action = () => Ensure.IsNotNullEmptyOrWhiteSpace(value, argumentName);

            // ASSERT
            action.ShouldNotThrow<ArgumentNullException>();
        }
    }
}
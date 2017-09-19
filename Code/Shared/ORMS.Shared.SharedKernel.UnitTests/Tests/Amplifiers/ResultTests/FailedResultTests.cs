//-----------------------------------------------------------------------
// <copyright file="SuccessfulResultTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.Amplifiers.ResultTests
{
    using System;
    using Fakes;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.Amplifiers;

    /// <summary>
    /// Tests the <see cref="Result"/>class.
    /// </summary>
    internal class FailedResultTests
    {
        /// <summary>
        /// Givens a non generic result when fail then error message should match supplied message.
        /// </summary>
        [Test]
        public void GivenANonGenericResult_WhenFail_ThenErrorMessageShouldMatchSuppliedMessage()
        {
            // ARRANGE
            Result result = Result.Fail("Error message");

            // ASSERT
            result.Error.Should().Be("Error message");
        }

        /// <summary>
        /// Givens a non generic result when fail then failure should be true.
        /// </summary>
        [Test]
        public void GivenANonGenericResult_WhenFail_ThenFailureShouldBeTrue()
        {
            // ARRANGE
            Result result = Result.Fail("Error message");

            // ASSERT
            result.IsFailure.Should().Be(true);
        }

        /// <summary>
        /// Givens a non generic result when fail then success should be false.
        /// </summary>
        [Test]
        public void GivenANonGenericResult_WhenFail_ThenSuccessShouldBeFalse()
        {
            // ARRANGE
            Result result = Result.Fail("Error message");

            // ASSERT
            result.IsSuccess.Should().Be(false);
        }

        [Test]
        public void Can_create_a_generic_version()
        {
            Result<FakeProduct> result = Result.Fail<FakeProduct>("Error message");

            result.Error.Should().Be("Error message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Test]
        public void Cannot_access_Value_property()
        {
            Result<FakeProduct> result = Result.Fail<FakeProduct>("Error message");

            Action action = () => { FakeProduct myClass = result.Value; };

            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void Cannot_create_without_error_message()
        {
            Action action1 = () => { Result.Fail(null); };
            Action action2 = () => { Result.Fail(string.Empty); };
            Action action3 = () => { Result.Fail<FakeProduct>(null); };
            Action action4 = () => { Result.Fail<FakeProduct>(string.Empty); };

            action1.ShouldThrow<ArgumentNullException>();
            action2.ShouldThrow<ArgumentNullException>();
            action3.ShouldThrow<ArgumentNullException>();
            action4.ShouldThrow<ArgumentNullException>();
        }
    }
}

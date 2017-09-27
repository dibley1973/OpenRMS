//-----------------------------------------------------------------------
// <copyright file="ExtensionTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.Amplifiers.ResultTests
{
    using Fakes;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.Amplifiers;

    /// <summary>
    /// Tests the <see cref="Result"/> extensions.
    /// </summary>
    public class ExtensionTests
    {
        private static readonly string _errorMessage = "this failed";

        /// <summary>
        /// Given the on failure when non-generic result is fail then should execute action.
        /// </summary>
        [Test]
        public void GivenOnFailure_WhenNonGenericResultIsFail_ThenShouldExecuteAction()
        {
            // ARRANGE
            bool myBool = false;
            var myResult = Result.Fail(_errorMessage);

            // ACT
            myResult.OnFailure(() => myBool = true);

            // ASSERT
            myBool.Should().Be(true);
        }

        /// <summary>
        /// Given the on failure when generic result is fail then should execute action.
        /// </summary>
        [Test]
        public void GivenOnFailure_WhenGenericResultIsFail_ThenShouldExecuteAction()
        {
            // ARRANGE
            var myBool = false;
            var myResult = Result.Fail<FakeEntity>(_errorMessage);

            // ACT
            myResult.OnFailure(() => myBool = true);

            // ASSERT
            myBool.Should().Be(true);
        }

        /// <summary>
        /// Given the on failure when generic result is fail then should execute action withresult.
        /// </summary>
        [Test]
        public void GivenOnFailure_WhenGenericResultIsFail_ThenShouldExecuteActionWithresult()
        {
            // ARRANGE
            var myError = string.Empty;
            var myResult = Result.Fail<FakeEntity>(_errorMessage);

            // ACT
            myResult.OnFailure(error => myError = error);

            // ASSERT
            myError.Should().Be(_errorMessage);
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="NameTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.CommonEntities
{
    using System;
    using Constants.ResultErrorKeys;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.CommonEntities;

    /// <summary>
    /// Test for <see cref="Name"/> structure
    /// </summary>
    [TestFixture]
    public class NameTests
    {
        /// <summary>
        /// Given the create method when called with null value then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithNullValue_ThenReturnsFailResult()
        {
            // ARRANGE

            // ACT
            var actual = Name.Create(null);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(NameErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the Create method when called with empty string then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithEmptyValue_ThenReturnsFailResult()
        {
            // ARRANGE

            // ACT
            var actual = Name.Create(string.Empty);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(NameErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the Create method when called with white space then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithWhiteSpace_ThenReturnsFailResult()
        {
            // ARRANGE

            // ACT
            var actual = Name.Create("  ");

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(NameErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the Create method when called with value longer than maximum length then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueLongerThanMaximumLength_ThenReturnsFailResult()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength + 1);

            // ACT
            var actual = Name.Create(value);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(NameErrorKeys.IsTooLong);
        }

        /// <summary>
        /// Given the Create method when called with value at maximum length returns success result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueAtMaximumLength_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength);

            // ACT
            var actual = Name.Create(value);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the Create method when called with value less than maximum length returns success result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueLessThanMaximumLength_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength - 1);

            // ACT
            var actual = Name.Create(value);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the value when read after valid construction then returns constructed value.
        /// </summary>
        [Test]
        public void GivenValue_WhenReadAfterValidConstruction_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength - 1);
            var nameResult = Name.Create(value);
            var name = nameResult.Value;

            // ACT
            var actual = name.Value;

            // ASSERT
            actual.Should().Be(value);
        }

        /// <summary>
        /// Given the equals method, when same value strings then returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSameValueStrings_ThenReturnsTrue()
        {
            // ARRANGE
            var name1Result = Name.Create("Name");
            var name1 = name1Result.Value;
            var name2Result = Name.Create("Name");
            var name2 = name2Result.Value;

            // ACT
            var actual = name1.Equals(name2);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the equals method, when different value strings then returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenDifferentValueStrings_ThenReturnsFalse()
        {
            // ARRANGE
            var name1Result = Name.Create("Name1");
            var name1 = name1Result.Value;
            var name2Result = Name.Create("Name2");
            var name2 = name2Result.Value;

            // ACT
            var actual = name1.Equals(name2);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given  the get hash code, when same value strings then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValueStrings_ThenReturnsTrue()
        {
            // ARRANGE
            var name1Result = Name.Create("Name");
            var name1 = name1Result.Value;
            var name2Result = Name.Create("Name");
            var name2 = name2Result.Value;

            // ACT
            var actual = name1.GetHashCode().Equals(name2.GetHashCode());

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given  the get hash code, when different value strings then returns false.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenDifferentValueStrings_ThenReturnsFalse()
        {
            // ARRANGE
            var name1Result = Name.Create("Name1");
            var name1 = name1Result.Value;
            var name2Result = Name.Create("Name2");
            var name2 = name2Result.Value;

            // ACT
            var actual = name1.GetHashCode().Equals(name2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the explicit string operator when cast from string at maximum length then created name with same value.
        /// </summary>
        [Test]
        public void GivenExplicitStringOperator_WhenCastFromStringAtMaximumLength_ThenCreatedNameWithSameValue()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength);

            // ACT
            var actual = (Name)value;

            // ASSERT
            actual.Value.Should().Be(value);
        }

        /// <summary>
        /// Given the explicit string operator when cast from string over maximum length then throws exception.
        /// </summary>
        [Test]
        public void GivenExplicitStringOperator_WhenCastFromStringOverMaximumLength_ThrowsException()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength + 1);

            // ReSharper disable once NotAccessedVariable
            var name = default(Name);

            // ACT
            Action actual = () =>
            {
                name = (Name)value;
            };

            // ASSERT
            actual.ShouldThrow<InvalidCastException>();
        }

        /// <summary>
        /// Given the implicit string operator when cast to string then created name with same value.
        /// </summary>
        [Test]
        public void GivenImplicitStringOperator_WhenCastToString_ThenCreatedNameWithSameValue()
        {
            // ARRANGE
            var value = "Name";
            var nameResult = Name.Create(value);
            var name = nameResult.Value;

            // ACT
            string actual = name;

            // ASSERT
            actual.Should().Be(value);
        }
    }
}
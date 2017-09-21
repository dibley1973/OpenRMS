//-----------------------------------------------------------------------
// <copyright file="CodeTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.UnitTests.Tests.CommonEntities
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using SharedKernel.CommonEntities;

    /// <summary>
    /// Test for <see cref="Code"/> structure
    /// </summary>
    [TestFixture]
    public class CodeTests
    {
        /// <summary>
        /// Given creation when called with null value throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithNullValue_ThenThrowsException()
        {
            // ARRANGE

            // ACT
            Action actual = () => Code.Create(null);

            // ASSERT
            actual.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given creation when called with empty string throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithEmptyValue_ThenThrowsException()
        {
            // ARRANGE

            // ACT
            Action actual = () => Code.Create(string.Empty);

            // ASSERT
            actual.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given creation when called with white space throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithWhiteSpace_ThenThrowsException()
        {
            // ARRANGE

            // ACT
            Action actual = () => Code.Create("  ");

            // ASSERT
            actual.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given creation when called with value longer than maximum length throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueLongerThanMaximumLength_ThenThrowsException()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength + 1);

            // ACT
            Action actual = () => Code.Create(value);

            // ASSERT
            actual.ShouldThrow<ArgumentOutOfRangeException>();
        }

        /// <summary>
        /// Given creation when called with value longer at maximum length throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueAtMaximumLength_ThenThrowsException()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength);

            // ACT
            Action actual = () => Code.Create(value);

            // ASSERT
            actual.ShouldNotThrow();
        }

        /// <summary>
        /// Given creation when called with value less than maximum length throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueLessThanMaximumLength_ThenThrowsException()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength - 1);

            // ACT
            Action actual = () => Code.Create(value);

            // ASSERT
            actual.ShouldNotThrow();
        }

        /// <summary>
        /// Given the value when read after valid construction then returns constructed value.
        /// </summary>
        [Test]
        public void GivenValue_WhenReadAfterValidConstruction_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength - 1);
            var name = Code.Create(value);

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
            var name1 = Code.Create("Code");
            var name2 = Code.Create("Code");

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
            var name1 = Code.Create("Code1");
            var name2 = Code.Create("Code2");

            // ACT
            var actual = name1.Equals(name2);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Givens the get hash code, when same value strings then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValueStrings_ThenReturnsTrue()
        {
            // ARRANGE
            var name1 = Code.Create("Code");
            var name2 = Code.Create("Code");

            // ACT
            var actual = name1.GetHashCode().Equals(name2.GetHashCode());

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Givens the get hash code, when different value strings then returns false.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenDifferentValueStrings_ThenReturnsFalse()
        {
            // ARRANGE
            var name1 = Code.Create("Code1");
            var name2 = Code.Create("Code2");

            // ACT
            var actual = name1.GetHashCode().Equals(name2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the explicit string operator when cast from string then created name with same value.
        /// </summary>
        [Test]
        public void GivenExplicitStringOperator_WhenCastFromString_ThenCreatedCodeWithSameValue()
        {
            // ARRANGE
            var value = "Code";
            ////var name = default(Code);

            // ACT
            var actual = (Code)value;

            // ASSERT
            actual.Value.Should().Be(value);
        }

        /// <summary>
        /// Given the implicit string operator when cast to string then created name with same value.
        /// </summary>
        [Test]
        public void GivenImplicitStringOperator_WhenCastToString_ThenCreatedCodeWithSameValue()
        {
            // ARRANGE
            var value = "Code";
            var name = Code.Create(value);

            // ACT
            string actual = name;

            // ASSERT
            actual.Should().Be(value);
        }
    }
}

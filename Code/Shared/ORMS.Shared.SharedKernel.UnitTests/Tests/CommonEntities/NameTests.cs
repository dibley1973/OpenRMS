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
    using FluentAssertions;
    using NUnit.Framework;
    using ORMS.Shared.SharedKernel.CommonEntities;

    /// <summary>
    /// Test for <see cref="Name"/> structure
    /// </summary>
    [TestFixture]
    public class NameTests
    {
        /// <summary>
        /// Given the constructor when called with null value throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenCalledWithNullValue_ThenThrowsException()
        {
            // ARRANGE

            // ACT
            Action actual = () => new Name(null);

            // ASSERT
            actual.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the constructor when called with empty string throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenCalledWithEmptyValue_ThenThrowsException()
        {
            // ARRANGE

            // ACT
            Action actual = () => new Name(string.Empty);

            // ASSERT
            actual.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the constructor when called with white space throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenCalledWithWhiteSpace_ThenThrowsException()
        {
            // ARRANGE

            // ACT
            Action actual = () => new Name("  ");

            // ASSERT
            actual.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the constructor when called with value longer than maximum length throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenCalledWithValueLongerThanMaximumLength_ThenThrowsException()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength + 1);

            // ACT
            Action actual = () => new Name(value);

            // ASSERT
            actual.ShouldThrow<ArgumentOutOfRangeException>();
        }

        /// <summary>
        /// Given the constructor when called with value longer at maximum length throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenCalledWithValueAtMaximumLength_ThenThrowsException()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength);

            // ACT
            Action actual = () => new Name(value);

            // ASSERT
            actual.ShouldNotThrow();
        }

        /// <summary>
        /// Given the constructor when called with value less than maximum length throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenCalledWithValueLessThanMaximumLength_ThenThrowsException()
        {
            // ARRANGE
            var value = new string('A', Name.MaximumCharacterLength - 1);

            // ACT
            Action actual = () => new Name(value);

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
            var value = new string('A', Name.MaximumCharacterLength - 1);
            var name = new Name(value);

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
            var name1 = new Name("Name");
            var name2 = new Name("Name");

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
            var name1 = new Name("Name1");
            var name2 = new Name("Name2");

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
            var name1 = new Name("Name");
            var name2 = new Name("Name");

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
            var name1 = new Name("Name1");
            var name2 = new Name("Name2");

            // ACT
            var actual = name1.GetHashCode().Equals(name2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the explicit string operator when cast from string then created name with same value.
        /// </summary>
        [Test]
        public void GivenExplicitStringOperator_WhenCastFromString_ThenCreatedNameWithSameValue()
        {
            // ARRANGE
            var value = "Name";
            ////var name = default(Name);

            // ACT
            var actual = (Name)value;

            // ASSERT
            actual.Value.Should().Be(value);
        }

        /// <summary>
        /// Given the implicit string operator when cast to string then created name with same value.
        /// </summary>
        [Test]
        public void GivenImplicitStringOperator_WhenCastToString_ThenCreatedNameWithSameValue()
        {
            // ARRANGE
            var value = "Name";
            var name = new Name(value);

            // ACT
            string actual = name;

            // ASSERT
            actual.Should().Be(value);
        }
    }
}

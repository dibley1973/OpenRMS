using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Shared.Kernel.Amplifiers;

namespace OpenRMS.Shared.Kernel.Tests.Tests.Amplifiers
{
    [TestClass]
    public class HasValueTests
    {
        [TestMethod]
        public void HasValue_AfterConstructionWithNoArgument_ReturnsFalse()
        {
            // ARRANGE
            var maybe = new Maybe<Fakes.FakeProduct, int>();

            // ACT
            var actual = maybe.HasValue();

            // ASSERT
            actual.Should().Be(false);
        }
    }
}
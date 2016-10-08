using FluentAssertions;
using OpenRMS.Contexts.ProductManagement.Domain;
using Xunit;

namespace OpenRMS.Contexts.ProductManagementTests.Domain
{
    public class ProductShould
    {
        [Fact]
        public void Given_Instantiation_With_NameAndDescription_CreatesProductWithIdentity()
        {
            // ARRANGE

            // ACT
            var actual = new Product("Product 1","Description 1");

            // ASSERT
            actual.Id.Should().NotBeEmpty();
        }
    }
}

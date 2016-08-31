using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORMS.Shared.SharedKernel.Entities;

namespace ORMS.Shared.SharedKernel.UnitTests.Tests
{
    [TestClass]
    public class EntityOfTTests
    {
        public class EntityA : Entity<Int64>
        {
            public EntityA(long id) : base(id)
            {
            }
        }
        public class EntityB : Entity<Int32>
        {
            public EntityB(int id) : base(id)
            {
            }
        }

        [TestMethod]
        public void Equals_WhenGivenObjectOfDifferentType_ReturnsFalse()
        {
            // ARRANGE
            var entity1 = new EntityA(2);
            var entity2 = new EntityB(2) as object;

            // ACT
            var actual = entity1.Equals(entity2);

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}

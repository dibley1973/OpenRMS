using OpenRMS.Shared.Kernel.BaseClasses;
using System;

namespace OpenRMS.Shared.Kernel.Tests.Fakes
{
    public class FakeProduct : Entity
    {
        public string Name { get; set; }

        public FakeProduct() : base() { }

        public FakeProduct(Guid id) : base(id) { }
    }
}
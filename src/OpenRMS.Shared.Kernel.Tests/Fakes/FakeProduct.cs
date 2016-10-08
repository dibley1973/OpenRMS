using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Tests.Fakes
{
    public class FakeProduct : Entity<int>
    {
        public string Name { get; set; }
    }
}
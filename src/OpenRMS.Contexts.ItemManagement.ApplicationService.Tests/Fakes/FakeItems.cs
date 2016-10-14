using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes
{
    public class FakeItems : List<Item>
    {
        public FakeItems()
        {
            Add(Item1);
        }

        public static Item Item1
        {
            get { return new Item("Item 1 Name", "Item 1 Description"); }
        }

        public static Item Item2
        {
            get { return new Item("Item 2 Name", "Item 2 Description"); }
        }

        public static Item Item3
        {
            get { return new Item(Item3Id, "Item 3 Name", "Item 3 Description"); }
        }

        public static Guid Item3Id
        {
            get { return Guid.NewGuid(); }
        }
    }
}

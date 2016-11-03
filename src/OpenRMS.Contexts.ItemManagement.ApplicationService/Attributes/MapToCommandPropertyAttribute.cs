using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Attributes
{
    public class MapToCommandPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public MapToCommandPropertyAttribute(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            PropertyName = propertyName;
        }

    }
}

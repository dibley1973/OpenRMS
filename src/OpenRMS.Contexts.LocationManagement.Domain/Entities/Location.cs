using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.LocationManagement.Domain.Entities
{
    /// <summary>
    /// Represents an item.
    /// </summary>
    public class Location : AggregateRoot
    {
        #region EF Backing Properties

        //TODO: (J.Collinson 20/10/2016) - Remove once EF7 supports value objects
        public string LocationCodeValue
        {
            get { return Code.Value; }
            private set
            {
                if (Code != BusinessCode.Empty)
                    throw new InvalidOperationException(string.Format("The {0} property cannot be changed. It is provided for data binding operations only", nameof(LocationCodeValue)));

                Code = value;
            }
        }

        #endregion

        #region Properties

        public BusinessCode Code { get; private set; } = BusinessCode.Empty;
        public string Name { get; private set; }
        public string Description { get; private set; }

        #endregion

        #region Construct

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        private Location() : base() { }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name">The name of the location.</param>
        public Location(BusinessCode code, string name)
            : this(Guid.NewGuid(), code, name)
        { }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the location.</param>
        /// <param name="code"></param>
        /// <param name="name">The name of the location.</param>
        public Location(Guid id, BusinessCode code, string name)
            : base(id)
        {
            if (code == BusinessCode.Empty) throw new ArgumentException("The Location Code must be set.  An empty code is not permissable", nameof(code));

            Code = code;
            ChangeName(name);
        }

        #endregion

        /// <summary>
        /// Changes the locations name.
        /// </summary>
        /// <param name="name">The new name of the location.</param>
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        /// <summary>
        /// Changes the locations description.
        /// </summary>
        /// <param name="description">The new description of the location.</param>
        public void ChangeDescription(string description)
        {
            if (description == null)
                throw new ArgumentNullException(nameof(description));

            Description = description;
        }

    }
}

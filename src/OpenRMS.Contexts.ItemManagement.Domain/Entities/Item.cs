using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.Domain.Entities
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Item : AggregateRoot
    {
        #region EF Backing Properties

        //TODO: (J.Adjare 18/10/2016) - Remove once EF7 supports value objects
        public string ItemCodeValue
        {
            get { return Code.Value; }
            private set
            {
                if(Code!=ItemCode.Empty)
                    throw new InvalidOperationException(string.Format("The {0} property cannot be changed. It is provided for data binding operations only", nameof(ItemCodeValue)));

                Code = value;
            }
        }

        #endregion

        #region Properties

        public ItemCode Code { get; private set; } = ItemCode.Empty;
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        #endregion

        #region Construct

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        private Item() : base() { }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name">The name of the product.</param>
        public Item(ItemCode code, string name)
            : this(Guid.NewGuid(), code, name)
        {}

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product.</param>
        /// <param name="code"></param>
        /// <param name="name">The name of the product.</param>
        public Item(Guid id, ItemCode code, string name)
            : base(id)
        {
            if(code == ItemCode.Empty) throw new ArgumentException("The Item Code must be set.  An empty code is not permissable",nameof(code));

            Code = code;
            ChangeName(name);
        }

        #endregion

        public ValidationResult CanChangeName(string name)
        {
            //TODO: Consider localisation concerns and general problem that the domain should not be concerned about localisation - will probably need to use ErrorCodes or Keys (e.g. resource file key)
            return new ValidationResult(string.IsNullOrWhiteSpace(name) == false,
                "name must not be null, empty or whitespace");
        }

        /// <summary>
        /// Changes the products name.
        /// </summary>
        /// <param name="name">The new name of the product.</param>
        public void ChangeName(string name)
        {
            var canChangeName = CanChangeName(name);

            if (canChangeName.IsValid == false)
                throw new ArgumentException(canChangeName.ErrorMessage, nameof(name));

            Name = name;
        }


        public ValidationResult CanChangeDescription(string description)
        {
            //TODO: Consider localisation concerns and general problem that the domain should not be concerned about localisation - will probably need to use ErrorCodes or Keys (e.g. resource file key)
            return new ValidationResult(description!=null,
                "description must not be null, empty strings are permitted");
        }

        /// <summary>
        /// Changes the products description.
        /// </summary>
        /// <param name="description">The new description of the product.</param>
        public void ChangeDescription(string description)
        {
            var canChangeDescription = CanChangeDescription(description);
            if(canChangeDescription.IsValid==false)
                throw new ArgumentException(canChangeDescription.ErrorMessage, nameof(description));

            Description = description;
        }

    }

    //TODO: This is just here as a temporary measure whilst working out the best route
    public class ValidationResult
    {
        public ValidationResult(bool isValid)
        {
            IsValid = isValid;
        }

        public ValidationResult(bool isValid, string errorMessage) : this(isValid)
        {
            if(errorMessage==null) throw new ArgumentNullException(nameof(errorMessage));
            if(!isValid) ErrorMessage = errorMessage;
        }

        public bool IsValid { get; }

        public string ErrorMessage { get; } = string.Empty;

        public static implicit operator bool(ValidationResult validationResult)
        {
            return validationResult.IsValid;
        }
    }
}

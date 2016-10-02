using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Services;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Handlers
{
    public class UpdateProductHandler : ICommandHandler<UpdateProductCommand, Product>
    {
        private readonly IRepository<Product, Guid> _repository;

        public UpdateProductHandler(IRepository<Product, Guid> repository)
        {
            _repository = repository;
        }

        public Product Execute(UpdateProductCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var result = _repository.GetForId(command.Id);
            //product.SetValues(command.Name, command.Description);

            if (!result.HasValue()) throw new InvalidOperationException("Cannot update product");

            _repository.Update(result.Entity);
            //_repository.Save();

            return result.Entity;
        }
    }
}

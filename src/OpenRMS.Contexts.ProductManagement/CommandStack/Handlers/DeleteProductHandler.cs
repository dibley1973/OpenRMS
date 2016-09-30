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
    public class DeleteProductHandler : ICommandHandler<DeleteProductCommand, Product>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product Execute(DeleteProductCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var product = _repository.GetForId(command.Id);

            _repository.Delete(product);
            //_repository.Save();

            return product;
        }
    }
}

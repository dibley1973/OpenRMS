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
        private readonly IRepository<Product, Guid> _repository;

        public DeleteProductHandler(IRepository<Product, Guid> repository)
        {
            _repository = repository;
        }

        public Product Execute(DeleteProductCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var result = _repository.GetForId(command.Id);

            if (!result.HasValue()) throw new InvalidOperationException("Cannot delete product");
            
            _repository.Delete(result.Entity);
            //_repository.Save();
            

            return result.Entity;
        }
    }
}

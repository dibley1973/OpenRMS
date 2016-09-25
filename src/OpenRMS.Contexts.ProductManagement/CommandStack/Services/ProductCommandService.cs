using System;
using System.Collections.Generic;
using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using OpenRMS.Contexts.ProductManagement.CommandStack.Handlers;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ProductManagement.Domain;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Services
{
    public class ProductCommandService : IProductCommandService
    {
        private ICommandHandler<CreateProductCommand, Product> _createProductHandler;
        private ICommandHandler<UpdateProductCommand, Product> _updateProductHandler;
        private ICommandHandler<DeleteProductCommand, Product> _deleteProductHandler;

        public ProductCommandService(
            ICommandHandler<CreateProductCommand, Product> createProductHandler,
            ICommandHandler<UpdateProductCommand, Product> updateProductHandler,
            ICommandHandler<DeleteProductCommand, Product> deleteProductHandler)
        {
            _createProductHandler = createProductHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
        }

        public Guid CreateProduct(CreateProductCommand command)
        {
            var product = _createProductHandler.Execute(command);
            return product.Id;
        }

        public void UpdateProduct(UpdateProductCommand command)
        {
            _updateProductHandler.Execute(command);
        }

        public void DeleteProduct(DeleteProductCommand command)
        {
            _deleteProductHandler.Execute(command);
        }
    }
}

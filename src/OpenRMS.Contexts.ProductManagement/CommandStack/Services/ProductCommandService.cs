using System;
using System.Collections.Generic;
using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using OpenRMS.Contexts.ProductManagement.CommandStack.Handlers;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ProductManagement.Domain;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Services
{
    /// <summary>
    /// A service that allows various product commands to be executed.
    /// </summary>
    public class ProductCommandService : IProductCommandService
    {
        private ICommandHandler<CreateProductCommand, Product> _createProductHandler;
        private ICommandHandler<UpdateProductCommand> _updateProductHandler;
        private ICommandHandler<DeleteProductCommand> _deleteProductHandler;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="createProductHandler">A handler of commands that create products.</param>
        /// <param name="updateProductHandler">A handler of commands that update products.</param>
        /// <param name="deleteProductHandler">A handler of commands that delete products.</param>
        public ProductCommandService(
            ICommandHandler<CreateProductCommand, Product> createProductHandler,
            ICommandHandler<UpdateProductCommand> updateProductHandler,
            ICommandHandler<DeleteProductCommand> deleteProductHandler)
        {
            _createProductHandler = createProductHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
        }

        /// <summary>
        /// Executes a create product command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The id of the created product.</returns>
        public Guid CreateProduct(CreateProductCommand command)
        {
            var product = _createProductHandler.Execute(command);
            return product.Id;
        }

        /// <summary>
        /// Executes an update product command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void UpdateProduct(UpdateProductCommand command)
        {
            _updateProductHandler.Execute(command);
        }

        /// <summary>
        /// Executes a delete product command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void DeleteProduct(DeleteProductCommand command)
        {
            _deleteProductHandler.Execute(command);
        }
    }
}

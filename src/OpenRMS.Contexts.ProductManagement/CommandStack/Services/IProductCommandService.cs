using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using System;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Services
{
    /// <summary>
    /// An interface that provides access to a service of product commands.
    /// </summary>
    public interface IProductCommandService
    {
        Guid CreateProduct(CreateProductCommand command);
        void UpdateProduct(UpdateProductCommand command);
        void DeleteProduct(DeleteProductCommand command);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenRMS.Contexts.ProductManagement.CommandStack.Services;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.Api.Models;
using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;

namespace OpenRMS.Contexts.ProductManagement.Api.Controllers
{
    [Route("productmanagement/[controller]")]
    public class ProductsController : Controller
    {
        // TODO: This controller accesses the repository directly - is this acceptable? If we are
        // following CQRS then no. If we're not then is this still correct?

        private IProductCommandService _productCommandService;
        private IProductRepository _productRepository;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="productCommandService">A service that can execute product commands.</param>
        /// <param name="productRepository">A repository of products.</param>
        public ProductsController(IProductCommandService productCommandService, IProductRepository productRepository)
        {
            _productCommandService = productCommandService;
            _productRepository = productRepository;
        }

        // GET products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        // GET products/5
        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return _productRepository.GetForId(id);
        }

        // POST products
        [HttpPost]
        public Guid Post([FromBody]CreateProductModel model)
        {
            var command = new CreateProductCommand(model.Name, model.Description);
            return _productCommandService.CreateProduct(command);
        }

        // PUT products/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UpdateProductModel model)
        {
            var command = new UpdateProductCommand(model.Id, model.Name, model.Description);
            _productCommandService.UpdateProduct(command);
        }

        // DELETE products/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var command = new DeleteProductCommand(id);
            _productCommandService.DeleteProduct(command);
        }
    }
}

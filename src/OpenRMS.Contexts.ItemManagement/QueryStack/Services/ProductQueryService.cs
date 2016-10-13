using System.Collections.Generic;
using OpenRMS.Contexts.ItemManagement.QueryStack.Dto;
using OpenRMS.Contexts.ItemManagement.QueryStack.Queries;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.QueryStack.Services
{
    public class ProductQueryService : IProductQueryService
    {
        private IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>> _getAllProductsHandler;
        private IQueryHandler<GetProductForIdQuery, ProductDto> _getProductForIdHandler;
        private IQueryHandler<SearchProductsQuery, IEnumerable<ProductDto>> _searchProductsHandler;

        public ProductQueryService(
            IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>> getAllProductsHandler,
            IQueryHandler<GetProductForIdQuery, ProductDto> getProductForIdHandler,
            IQueryHandler<SearchProductsQuery, IEnumerable<ProductDto>> searchProductsHandler)
        {
            _getAllProductsHandler = getAllProductsHandler;
            _getProductForIdHandler = getProductForIdHandler;
            _searchProductsHandler = searchProductsHandler;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _getAllProductsHandler.Execute(new GetAllProductsQuery());
        }

        public ProductDto GetForId(GetProductForIdQuery query)
        {
            return _getProductForIdHandler.Execute(query);
        }

        public IEnumerable<ProductDto> Search(SearchProductsQuery query)
        {
            return _searchProductsHandler.Execute(query);
        }
    }
}

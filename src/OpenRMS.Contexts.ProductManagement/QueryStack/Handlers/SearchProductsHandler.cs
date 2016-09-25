using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Queries;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.QueryStack.Handlers
{
    public class SearchProductsHandler : IQueryHandler<SearchProductsQuery, IEnumerable<ProductDto>>
    {
        private IDataSource<ProductDto> _dataSource;

        public SearchProductsHandler(IDataSource<ProductDto> dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<ProductDto> Execute(SearchProductsQuery query)
        {
            return _dataSource.Query().Where(product =>
                product.Name.Contains(query.Keyword) || product.Description.Contains(query.Keyword));
        }
    }
}

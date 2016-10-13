using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.ItemManagement.QueryStack.Dto;
using OpenRMS.Contexts.ItemManagement.QueryStack.Queries;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.QueryStack.Handlers
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

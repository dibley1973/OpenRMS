using System.Collections.Generic;
using OpenRMS.Contexts.ItemManagement.QueryStack.Dto;
using OpenRMS.Contexts.ItemManagement.QueryStack.Queries;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.QueryStack.Handlers
{
    public class GetAllProductsHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private IDataSource<ProductDto> _dataSource;

        public GetAllProductsHandler(IDataSource<ProductDto> dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<ProductDto> Execute(GetAllProductsQuery query)
        {
            return _dataSource.GetAll();
        }
    }
}

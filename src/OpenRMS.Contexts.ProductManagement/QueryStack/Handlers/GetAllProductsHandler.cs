using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Queries;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.QueryStack.Handlers
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

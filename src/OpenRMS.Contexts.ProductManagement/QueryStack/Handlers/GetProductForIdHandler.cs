using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Queries;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.QueryStack.Handlers
{
    public class GetProductForIdHandler : IQueryHandler<GetProductForIdQuery, ProductDto>
    {
        private IDataSource<ProductDto> _dataSource;

        public GetProductForIdHandler(IDataSource<ProductDto> dataSource)
        {
            _dataSource = dataSource;
        }

        public ProductDto Execute(GetProductForIdQuery query)
        {
            return _dataSource.GetForId(query.Id);
        }
    }
}

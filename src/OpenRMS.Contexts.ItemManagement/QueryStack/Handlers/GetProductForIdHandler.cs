using OpenRMS.Contexts.ItemManagement.QueryStack.Dto;
using OpenRMS.Contexts.ItemManagement.QueryStack.Queries;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.QueryStack.Handlers
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

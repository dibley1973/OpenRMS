using System.Collections.Generic;
using OpenRMS.Contexts.ItemManagement.QueryStack.Dto;
using OpenRMS.Contexts.ItemManagement.QueryStack.Queries;

namespace OpenRMS.Contexts.ItemManagement.QueryStack.Services
{
    public interface IProductQueryService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetForId(GetProductForIdQuery query);
        IEnumerable<ProductDto> Search(SearchProductsQuery query);
    }
}

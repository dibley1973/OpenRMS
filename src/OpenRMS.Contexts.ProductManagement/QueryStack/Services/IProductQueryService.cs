using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.QueryStack.Services
{
    public interface IProductQueryService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetForId(GetProductForIdQuery query);
        IEnumerable<ProductDto> Search(SearchProductsQuery query);
    }
}

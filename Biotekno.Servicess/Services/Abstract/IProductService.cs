using Biotekno.Entities.CQRS.Product;
using Biotekno.Entities.DTOs;
using Biotekno.Entities.Entities;
using Biotekno.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Servicess.Services.Abstract
{
    public interface IProductService
    {
        Task<ServiceResult<List<ProductDTO>>> GetListProduct(ProductQuery product, CancellationToken cancellationToken);
    }
}

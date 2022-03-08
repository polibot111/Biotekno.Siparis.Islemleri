using Biotekno.Entities.CQRS.Product;
using Biotekno.Entities.DTOs;
using Biotekno.Servicess.Services.Abstract;
using Biotekno.Servicess.Services.Concrete;
using Biotekno.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biotekno.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private ILogger<ProductController> _logger;
        public ProductController(IServiceProvider serviceProvider, ILogger<ProductController> logger)
        {
            _productService = serviceProvider.GetService<ProductService>();
            _logger = logger;
        }

        [HttpGet]
        public async Task<ServiceResult<List<ProductDTO>>> GetProduct(ProductQuery product, CancellationToken cancellationToken)
        {
            return await _productService.GetListProduct(product, cancellationToken);
        }
    }
}

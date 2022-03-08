using AutoMapper;
using Biotekno.Data.Abstract;
using Biotekno.Entities.CQRS.Product;
using Biotekno.Entities.DTOs;
using Biotekno.Entities.Entities;
using Biotekno.Servicess.Services.Abstract;
using Biotekno.Shared.Utilities.Results.Concrete;
using Biotekno.Shared.Utilities.Results.Enum;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Servicess.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ServiceResult<List<ProductDTO>>> GetListProduct(ProductQuery product, CancellationToken cancellationToken)
        {
            ServiceResult<List<ProductDTO>> service = new ServiceResult<List<ProductDTO>>();
            List<ProductDTO> productDTOs = new List<ProductDTO>(); 
            try
            {
                var products = await _productRepository.GetAllAsync(x=>x.Category == product.Category,null);
                var productsDTOs = _mapper.Map<List<ProductDTO>>(products);
                service.Data = productDTOs;
                service.ResultMessage = "Success";
                service.ErrorCode = "200";
                service.Status = Status.Success;

                return service;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                }
                w32ex = ex.InnerException as Win32Exception;
                service.ResultMessage = "Success";
                service.ErrorCode = $"{w32ex.ErrorCode}";
                service.Status = Status.Failed;
                return service;
            }
         
        }
    }
}

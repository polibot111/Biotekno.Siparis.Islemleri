using Biotekno.Entities.CQRS.Order;
using Biotekno.Servicess.Services.Abstract;
using Biotekno.Servicess.Services.Concrete;
using Biotekno.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biotekno.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private ILogger<OrderController> _logger;
        public OrderController(IServiceProvider serviceProvider, ILogger<OrderController> logger)
        {
            _orderService = serviceProvider.GetService<OrderService>();
            _logger = logger;
        }

        [HttpPost]
        public async Task<ServiceResult<OrderInsertCommand>> InsertOrder(OrderInsertCommand orderInsertCommand, CancellationToken cancellationToken)
        {
            return await _orderService.CreateOrder(orderInsertCommand, cancellationToken);
        }
    }
}

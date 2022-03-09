using AutoMapper;
using Biotekno.Data.Abstract;
using Biotekno.Entities.CQRS.Order;
using Biotekno.Servicess.Services.Abstract;
using Biotekno.Shared.RabbitMQ;
using Biotekno.Shared.Utilities.Results.Concrete;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Servicess.Services.Concrete
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ILogger<OrderService> _logger;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, ILogger<OrderService> logger, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResult<OrderInsertCommand>> CreateOrder(OrderInsertCommand orderInsertCommand, CancellationToken cancellationToken)
        {
            ServiceResult<OrderInsertCommand> result = new ServiceResult<OrderInsertCommand>();

            try
            {
                if (orderInsertCommand.ProductDetails.Count != 0)
                {
                    var orderDetail = new Entities.Entities.OrderDetail();
                    foreach (var item in orderInsertCommand.ProductDetails)
                    {
                        var order = new Entities.Entities.Order();

                        order.CustomerGSM = orderInsertCommand.CustomerGSM;
                        order.CustomerName = orderInsertCommand.CustomerName;
                        order.CustomerEmail = orderInsertCommand.CustomerEmail;
                        order.OrderDetail.ProductId = item.ProductId;
                        order.OrderDetail.Product.Unit = item.Amount;
                        order.OrderDetail.Product.UnitPrice = item.UnitPrica;

                        var orderKey = _orderRepository.AddAsync(order);

                        _orderRepository.SaveChanges();


                        orderDetail.ProductId = item.ProductId;
                        orderDetail.OrderId = order.Id;
                        orderDetail.UnitPrice = item.UnitPrica;

                        _orderDetailRepository.AddAsync(orderDetail);

                        _orderDetailRepository.SaveChanges();

                    }




                }
                result.Data = orderInsertCommand;
                result.Status = Shared.Utilities.Results.Enum.Status.Success;
                result.ErrorCode = "200";
                result.ResultMessage = "Başarıyla Tamamlandı";

                MailSender.MailQueueSender("Sipariş Detayı","Siparişiniz Başarıyla Alındı.");

                return result;
            }
            catch (Exception ex)
            {

                var w32ex = ex as Win32Exception;
                if (w32ex == null)
                {
                    w32ex = ex.InnerException as Win32Exception;
                }
                w32ex = ex.InnerException as Win32Exception;
                result.ResultMessage = ex.ToString();
                result.ErrorCode = $"{w32ex.ErrorCode}";
                result.Status = Shared.Utilities.Results.Enum.Status.Failed;
                return result;
            }

        }
    }
}

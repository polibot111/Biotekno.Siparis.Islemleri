using Biotekno.Entities.CQRS.Order;
using Biotekno.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Servicess.Services.Abstract
{
    public interface IOrderService
    {
        Task<ServiceResult<OrderInsertCommand>> CreateOrder(OrderInsertCommand orderInsertCommand, CancellationToken cancellationToken);
    }
}

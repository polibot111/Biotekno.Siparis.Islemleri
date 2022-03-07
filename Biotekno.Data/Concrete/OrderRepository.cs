using Biotekno.Data.Abstract;
using Biotekno.Entities.Entities;
using Biotekno.Shared.Concrete.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Data.Concrete
{
    public class OrderRepository : EfEntityRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
    }
}

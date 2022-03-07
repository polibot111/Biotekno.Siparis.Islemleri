using Biotekno.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Entities.CQRS.Order
{
    public class OrderInsertCommand
    {

        public class ProductDetail
        {
            public int ProductId { get; set; }
            public decimal UnitPrica { get; set; }
            public int Amount { get; set; }
        }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; }
        public int TotalAmount { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }



    }
}

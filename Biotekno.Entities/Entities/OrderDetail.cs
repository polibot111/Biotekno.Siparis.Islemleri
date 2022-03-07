using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Entities.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }

        //R.L
        public virtual Product Product { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

    }
}

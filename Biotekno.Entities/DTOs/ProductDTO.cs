using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Biotekno.Entities.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

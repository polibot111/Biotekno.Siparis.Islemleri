using Biotekno.Entities.Entities;
using Biotekno.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Data.Abstract
{
    public interface IProductRepository: IEntityRepository<Product>
    {
    }
}

using Biotekno.Shared.Utilities.Results.Abstract;
using Biotekno.Shared.Utilities.Results.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Shared.Utilities.Results.Concrete
{
    public class ServiceResult<T> : IServiceResult<T>
    {
        public T Data { get; set; }

        public string ResultMessage { get; set; }

        public Status Status { get; set; }

        public string ErrorCode { get; set; }
    }
}

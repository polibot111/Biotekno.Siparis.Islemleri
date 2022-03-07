using Biotekno.Shared.Utilities.Results.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Shared.Utilities.Results.Abstract
{
    public interface IServiceResult<T>
    {
        public T Data { get; }

        public string ResultMessage { get; }

        public Status Status { get; }
        public string ErrorCode { get; }
    }
}

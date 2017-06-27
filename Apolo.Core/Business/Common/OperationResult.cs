using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Business.Common
{
    public class OperationResult
    {
        public bool WasSuccessful { get; set; } = true;
        public string ErrorMessage { get; set; }

        public object RequestedObject { get; set; }
    }
}

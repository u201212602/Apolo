using Apolo.Core.Business.Common;
using Apolo.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Business
{
    public class SecurityService
    {
        ApoloContext context = new ApoloContext();

        public OperationResult GetUser(string username)
        {
            return new OperationResult { RequestedObject = context.Users.SingleOrDefault(x => x.Username == username) };
        }
    }
}

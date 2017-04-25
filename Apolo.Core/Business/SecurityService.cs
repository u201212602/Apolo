using Apolo.Core.Business.Common;
using Apolo.Core.Data;
using Apolo.Core.Model;
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

        public OperationResult GetUserByUsername(string username)
        {
            return new OperationResult { RequestedObject = context.Users.SingleOrDefault(x => x.Username == username) };
        }

        public OperationResult GetUserByID(int id)
        {
            return new OperationResult { RequestedObject = context.Users.SingleOrDefault(x => x.ID == id) };
        }

        public OperationResult GetAllPatients()
        {
            return new OperationResult { RequestedObject = context.Users.Where(x => x.Role == Constants.Roles.PATIENT).ToList() };
        }
    }
}

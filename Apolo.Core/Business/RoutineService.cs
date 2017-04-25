using Apolo.Core.Business.Common;
using Apolo.Core.Data;
using System.Linq;

namespace Apolo.Core.Business
{
    public class RoutineService
    {
        ApoloContext context = new ApoloContext();

        public OperationResult GetRoutinesForUsername(string username)
        {
            return new OperationResult { RequestedObject = context.Routines.Where( x => x.Patient.Username == username ).ToList() };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Model.Treatment
{
    public class WorkUnitEdition
    {
        public int ID { get; set; }
        public string Rationale { get; set; }
        public DateTime DateTime { get; set; }

        public int WorkUnitID { get; set; }
        public virtual WorkUnit WorkUnit { get; set; }
    }
}

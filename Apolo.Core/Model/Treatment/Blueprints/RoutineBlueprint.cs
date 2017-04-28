using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Model.Treatment.Blueprints
{
    public class RoutineBlueprint
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInWeeks { get; set; }
        public string Category { get; set; }


        public virtual ICollection<WorkWeekBlueprint> WorkWeekBlueprints { get; set; } = new List<WorkWeekBlueprint>();
    }
}

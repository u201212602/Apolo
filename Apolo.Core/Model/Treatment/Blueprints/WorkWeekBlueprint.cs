using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Model.Treatment.Blueprints
{
    public class WorkWeekBlueprint
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int DurationInDays { get; set; }


        public int RoutineBlueprintID { get; set; }
        public virtual RoutineBlueprint RoutineBlueprint { get; set; }

        public virtual ICollection<WorkDayBlueprint> WorkDays { get; set; } = new List<WorkDayBlueprint>();
    }
}

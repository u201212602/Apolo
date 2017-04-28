using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Model.Treatment.Blueprints
{
    public class WorkDayBlueprint
    {
        public int ID { get; set; }
        public int Number { get; set; }


        public int WorkWeekBlueprintID { get; set; }
        public virtual WorkWeekBlueprint WorkWeekBlueprint { get; set; }

        public virtual ICollection<WorkUnitBlueprint> WorkUnitBlueprints { get; set; } = new List<WorkUnitBlueprint>();
    }
}

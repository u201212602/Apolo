using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Model.Treatment.Blueprints
{
    public class WorkUnitBlueprint
    {
        public int ID { get; set; }
        public string Game { get; set; }
        public int DurationInMinutes { get; set; }
        public string Difficulty { get; set; }


        public int WorkDayBlueprintId { get; set; }
        public virtual WorkDayBlueprint WorkDayBlueprint { get; set; }
    }
}

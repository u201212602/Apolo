using System;
using System.Collections.Generic;

namespace Apolo.Core.Model.Treatment
{
    public class WorkDay
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }



        public int WorkWeekID { get; set; }
        public virtual WorkWeek WorkWeek { get; set; }

        public virtual ICollection<WorkUnit> WorkUnits { get; set; } = new List<WorkUnit>();

        public bool IsFinished
        {
            get
            {
                foreach (var workUnit in WorkUnits)
                    if (!workUnit.IsFinished)
                        return false;

                return true;
            }
        }
    }
}

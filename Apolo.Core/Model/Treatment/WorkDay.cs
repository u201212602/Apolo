using System;
using System.Collections.Generic;

namespace Apolo.Core.Model.Treatment
{
    public class WorkDay
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }



        public int RoutineID { get; set; }
        public virtual Routine Routine { get; set; }

        public virtual ICollection<WorkUnit> WorkUnits { get; set; } = new List<WorkUnit>();


        public bool IsFinished()
        {
            foreach(var workUnit in WorkUnits)
                if (!workUnit.IsFinished())
                    return false;

            return true;
        }
    }
}

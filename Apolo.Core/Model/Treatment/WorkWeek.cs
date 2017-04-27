using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Model.Treatment
{
    public class WorkWeek
    {
        public int ID { get; set; }


        public int Number { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }



        public int RoutineID { get; set; }

        public virtual Routine Routine { get; set; }


        public virtual ICollection<WorkDay> WorkDays { get; set; } = new List<WorkDay>();



        public bool IsFinished
        {
            get
            {
                foreach (var workDay in WorkDays)
                    if (!workDay.IsFinished)
                        return false;

                return true;
            }
        }
    }
}

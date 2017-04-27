using Apolo.Core.Model.Security;
using System;
using System.Collections.Generic;

namespace Apolo.Core.Model.Treatment
{
    public class Routine
    {
        public int ID { get; set; }

        public DateTime StartDate { get; set; }

        public int DurationInWeeks { get; set; }

        public string Purpose { get; set; }


        public int PatientID { get; set; }
        public virtual User Patient { get; set; }

        public int TherapistID { get; set; }
        public virtual User Therapist { get; set; }

        public virtual ICollection<WorkWeek> WorkWeeks { get; set; } = new List<WorkWeek>();


        
        public bool IsFinished
        {
            get
            {
                foreach (var workWeek in WorkWeeks)
                    if (!workWeek.IsFinished)
                        return false;

                return true;
            }
        }

        public int EllapsedPercentage
        {
            get
            {
                int diffDays = (DateTime.Now - StartDate).Days;
                double value = diffDays / (DurationInWeeks * 7.0) * 100.0;
                value = value >= 100.0 ? 100.0 : value;
                return (int)value;
            }
        }
    }
}

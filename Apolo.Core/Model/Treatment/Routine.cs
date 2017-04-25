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

        public virtual ICollection<WorkDay> WorkDays { get; set; }
    }
}

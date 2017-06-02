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

        public string Goal { get; set; }

        public string Details { get; set; }


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
                int totalDays = 0;

                foreach(var workWeek in WorkWeeks)
                {
                    totalDays += workWeek.WorkDays.Count;
                }

                return FinishedDaysCount / totalDays * 100;
            }
        }

        public int FinishedWeeksCount
        {
            get
            {
                int result = 0;

                foreach(var workWeek in WorkWeeks)
                {
                    foreach(var workDay in workWeek.WorkDays)
                    {
                        if(!workDay.IsFinished)
                        {
                            return result;
                        }
                    }
                    result++;
                }

                return result;
            }
        }

        public int FinishedDaysCount
        {
            get
            {
                int result = 0;

                foreach(var workWeek in WorkWeeks)
                {
                    foreach(var workDay in workWeek.WorkDays)
                    {
                        if(workDay.IsFinished)
                        {
                            result++;
                        }
                    }
                }

                return result;
            }
        }
    }
}

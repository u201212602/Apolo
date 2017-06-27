using System.Collections.Generic;
using System.Linq;

namespace Apolo.Core.Model.Treatment
{
    public class WorkUnit
    {
        public int ID { get; set; }
        public int Number { get; set; }

        public string Game { get; set; }

        public string Difficulty { get; set; }

        public int DurationInMinutes { get; set; }

        public int FinalScore { get; set; }

        public bool IsFinished { get; set; }



        public int WorkDayID { get; set; }
        public virtual WorkDay WorkDay { get; set; }
        public virtual ICollection<WorkUnitEdition> WorkUnitEditions { get; set; } = new List<WorkUnitEdition>();

        public List<WorkUnitEdition> DescendingWorkUnitEditions
        {
            get
            {
                List<WorkUnitEdition> result = new List<WorkUnitEdition>();
                foreach (WorkUnitEdition workUnitEdition in WorkUnitEditions)
                {
                    result.Add(workUnitEdition);
                }
                result.OrderByDescending(x => x.DateTime);
                return result;
            }
        }

        #region Completion Info/Stats
        public double LowAccelY { get; set; }
        public double HighAccelY { get; set; }
        public double AvgAccelY { get; set; }

        public double LowRomY { get; set; }
        public double HighRomY { get; set; }
        public double AvgRomY { get; set; }

        public double LowPod0 { get; set; }
        public double HighPod0 { get; set; }
        public double AvgPod0 { get; set; }

        public double LowPod1 { get; set; }
        public double HighPod1 { get; set; }
        public double AvgPod1 { get; set; }

        public double LowPod2 { get; set; }
        public double HighPod2 { get; set; }
        public double AvgPod2 { get; set; }

        public double LowPod3 { get; set; }
        public double HighPod3 { get; set; }
        public double AvgPod3 { get; set; }

        public double LowPod4 { get; set; }
        public double HighPod4 { get; set; }
        public double AvgPod4 { get; set; }

        public double LowPod5 { get; set; }
        public double HighPod5 { get; set; }
        public double AvgPod5 { get; set; }

        public double LowPod6 { get; set; }
        public double HighPod6 { get; set; }
        public double AvgPod6 { get; set; }

        public double LowPod7 { get; set; }
        public double HighPod7 { get; set; }
        public double AvgPod7 { get; set; }
        #endregion
    }
}

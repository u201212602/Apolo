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
                foreach(WorkUnitEdition workUnitEdition in WorkUnitEditions)
                {
                    result.Add(workUnitEdition);
                }
                result.OrderByDescending(x => x.DateTime);
                return result;
            }
        }
    }
}

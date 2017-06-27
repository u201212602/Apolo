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

        public double AverageAccelerationY
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AverageAccelerationY;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }

        public double AverageRomY
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AverageRomY;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }

        public double AveragePod0
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AveragePod0;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }

        public double AveragePod1
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AveragePod1;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }

        public double AveragePod2
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AveragePod2;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }
        public double AveragePod3
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AveragePod3;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }
        public double AveragePod4
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AveragePod4;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }
        public double AveragePod5
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AveragePod5;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }
        public double AveragePod6
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AveragePod6;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }
        public double AveragePod7
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach (var workDay in WorkDays)
                    if (workDay.IsFinished)
                    {
                        res += workDay.AveragePod7;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }
    }
}

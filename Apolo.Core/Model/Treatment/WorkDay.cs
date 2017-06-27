using System;
using System.Collections.Generic;

namespace Apolo.Core.Model.Treatment
{
    public class WorkDay
    {
        public int ID { get; set; }
        public int Number { get; set; }
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

        public double AverageAccelerationY
        {
            get
            {
                double res = 0.0;
                int completedUnits = 0;
                foreach(var workUnit in WorkUnits)
                    if(workUnit.IsFinished)
                    {
                        res += workUnit.AvgAccelY;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgRomY;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgPod0;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgPod1;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgPod2;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgPod3;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgPod4;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgPod5;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgPod6;
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
                foreach (var workUnit in WorkUnits)
                    if (workUnit.IsFinished)
                    {
                        res += workUnit.AvgPod7;
                        completedUnits++;
                    }
                return res / completedUnits;
            }
        }
    }
}

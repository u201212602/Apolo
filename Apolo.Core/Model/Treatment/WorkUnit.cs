namespace Apolo.Core.Model.Treatment
{
    public class WorkUnit
    {
        public int ID { get; set; }

        public string Game { get; set; }

        public string Difficulty { get; set; }

        public int DurationInMinutes { get; set; }

        public int FinalScore { get; set; }
    
        public bool IsFinished { get; set; }



        public int WorkDayID { get; set; }
        public virtual WorkDay WorkDay { get; set; }

        
    }
}

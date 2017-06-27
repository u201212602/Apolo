using Apolo.Core.Model.Security;
using Apolo.Core.Model.Treatment;
using Apolo.Core.Model.Treatment.Blueprints;
using System.Data.Entity;

namespace Apolo.Core.Data
{
    public class ApoloContext : DbContext
    {
        public ApoloContext() : base("ApoloContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Routine>()
                .HasRequired(r => r.Patient)
                .WithMany(t => t.PrescribedRoutines)
                .HasForeignKey(r => r.PatientID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Routine>()
                .HasRequired(r => r.Therapist)
                .WithMany(t => t.SupervisedRoutines)
                .HasForeignKey(r => r.TherapistID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkWeek>()
                .HasRequired(x => x.Routine)
                .WithMany(x => x.WorkWeeks)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<WorkDay>()
                .HasRequired(x => x.WorkWeek)
                .WithMany(x => x.WorkDays)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<WorkUnit>()
                .HasRequired(x => x.WorkDay)
                .WithMany(x => x.WorkUnits)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<WorkUnitEdition>()
                .HasRequired(x => x.WorkUnit)
                .WithMany(x => x.WorkUnitEditions)
                .WillCascadeOnDelete(true);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<RoutineBlueprint> RoutineBlueprints { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<WorkUnit> WorkUnits { get; set; }
        public DbSet<WorkWeek> WorkWeeks { get; set; }
    }
}

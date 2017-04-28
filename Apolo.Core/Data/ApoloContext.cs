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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<RoutineBlueprint> RoutineBlueprints {get;set;}
    }
}

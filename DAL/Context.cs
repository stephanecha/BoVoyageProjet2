using System.Data.Entity;
using Class;

namespace DAL
{
    public class Context : DbContext
    {
        public DbSet<AgenceVoyage> AgencesVoyages { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Assurance> Assurances { get; set; }

        public DbSet<DossierReservation> DossiersReservations { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DossierReservation>()
                .HasMany(c => c.Assurances)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("IdDossierReservation");
                    x.MapRightKey("IdAssurance");
                    x.ToTable("AssurancesDossiersReservations");
                });

            base.OnModelCreating(modelBuilder);
        }*/
    }
}

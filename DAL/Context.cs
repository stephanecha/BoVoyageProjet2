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
    }
}

using System;

namespace Class
{
    public class Voyage
    {
        public int Id { get; set; }
        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public int PlacesDisponibles { get; set; }
        public decimal PrixParPersonne { get; set; }

        public int IdDestination { get; set; }
        public int IdAgenceVoyage { get; set; }

        public void Reserver(int places)
        {

        }

    }
}

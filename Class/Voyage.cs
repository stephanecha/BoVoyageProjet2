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

        //Implementation du constructeur par defaut nécéssaire à Entity
        public Voyage() { }

        public Voyage(DateTime dateAller, DateTime dateRetour, int placesDisponibles, decimal prixParPersonne)
        {
            
            DateAller = dateAller;
            DateRetour = dateRetour;
            PlacesDisponibles = placesDisponibles;
            PrixParPersonne = prixParPersonne;
        }

        public void Reserver(int places)
        {

        }



    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Class
{
    public class Voyage
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAller { get; set; }

        [Required]
        public DateTime DateRetour { get; set; }

        [Required]
        public int PlacesDisponibles { get; set; }

        [Required]
        public decimal PrixParPersonne { get; set; }

        public int IdDestination { get; set; }

        [ForeignKey("IdDestination")]
        public virtual Destination destination { get; set; }

        public int IdAgenceVoyage { get; set; }

        [ForeignKey("IdAgenceVoyage")]
        public virtual AgenceVoyage agenceVoyage { get; set; }

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

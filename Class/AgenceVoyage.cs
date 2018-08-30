using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Class
{
    [Table("AgencesVoyages")]
    public class AgenceVoyage
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public virtual ICollection<Voyage> Voyages { get; set; } 

        public AgenceVoyage (string nom)
        {
            Nom = Nom;
        }
    }
}

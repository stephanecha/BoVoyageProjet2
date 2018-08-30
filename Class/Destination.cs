using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Class
{
    public class Destination
    {
        public int Id { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string Pays { get; set; }

        [Required]
        public string Region { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Voyage> Voyages { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public Destination() { }


        public Destination(string continent, string pays, string region, string description = null)
        {
            Continent = continent;
            Pays = pays;
            Region = region;
            Description = description;
        }
    }
}

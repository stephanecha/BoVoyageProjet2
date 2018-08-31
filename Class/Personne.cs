using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Class
{
    public abstract class Personne
    {
        public int Id { get; set; }

        [Required]
        public string Civilite { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DateNaissance.Year;
                return age;
            }
        }
    }
}

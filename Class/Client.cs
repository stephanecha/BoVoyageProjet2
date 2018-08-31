using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Class
{
    public class Client : Personne
    {
        [Required]
        public string Email { get; set; }

        public virtual ICollection<DossierReservation> DossiersReservations { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public Client() { }

        public Client(string civilite, string nom, string prenom, DateTime dateNaissance, string email,
                      string adresse, string telephone)
        {
            Civilite = civilite;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Email = email;
            Adresse = adresse;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"{Nom} {Prenom}";
        }
    }
}

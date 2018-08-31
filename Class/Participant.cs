using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Class
{
    public class Participant : Personne
    {
        [Required]
        public int NumeroUnique { get; set; }

        [NotMapped]
        public double Reduction
        {
            get
            {
                if (Age < 12)
                    return 0.6d;
                else
                    return 1.0d;
            }
        }

        public int IdDossierReservation { get; set; }

        [ForeignKey("IdDossierReservation")]
        public virtual DossierReservation DossierReservation { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public Participant() { }

        public Participant(string civilite, string nom, string prenom, DateTime dateNaissance, int numeroUnique,
                           string adresse, string telephone)
        {
            base.Civilite = civilite;
            //base est optionel
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            //NumeroUnique = numeroUnique;
            Adresse = adresse;
            Telephone = telephone;
        }
    }
}

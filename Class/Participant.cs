using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public sealed class Participant : Personne
    {
        public int NumeroUnique { get; set; }
        public float Reduction { get; set; }
        public int IdDossierReservation { get; set; }

        public Participant(string civilite, string nom, string prenom, DateTime dateNaissance, int numeroUnique,float reduction)
        {
            base.Civilite = civilite;
                //base est optionel
                Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            NumeroUnique = numeroUnique;
            Reduction = reduction;

        }
    }
}

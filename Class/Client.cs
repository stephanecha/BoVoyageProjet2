using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public sealed class Client : Personne
    {
        public string Email { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public Client() { }

        public Client(string civilite, string nom, string prenom, DateTime dateNaissance, string email)
        {
            Civilite = civilite;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Email = email;

        }
    }
}

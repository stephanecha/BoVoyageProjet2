﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public abstract class Personne
    {
        public int Id { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Age { get; }
    }
}

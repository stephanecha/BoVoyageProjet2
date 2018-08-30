using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public enum TypeAssurance : byte
    {
        Annulation = 1
    }
    public class Assurance
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }
        public TypeAssurance TypeAssurance { get; set; }

        public Assurance(TypeAssurance typeAssurance, decimal montant)
        {
            TypeAssurance = typeAssurance;
            Montant = montant;
        }
    }
}

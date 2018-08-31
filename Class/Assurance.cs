using System.ComponentModel.DataAnnotations;

namespace Class
{
    public enum TypeAssurance : byte
    {
        Annulation = 1
    }

    public class Assurance
    {
        public int Id { get; set; }

        [Required]
        public decimal Montant { get; set; }

        [Required]
        [EnumDataType(typeof(TypeAssurance))]
        public TypeAssurance TypeAssurance { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public Assurance() { }

        public Assurance(TypeAssurance typeAssurance, decimal montant)
        {
            TypeAssurance = typeAssurance;
            Montant = montant;
        }
    }
}

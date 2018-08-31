using System.Collections.Generic;
using Class;

namespace Service
{
    public interface IServiceAssurance
    {
        IEnumerable<Assurance> ListerAssurance();

        Assurance ChoisirAssurance(int id);

        IEnumerable<Assurance> FiltrerAssurance(decimal minMontant = 0.0m, decimal maxMontant = decimal.MaxValue);
        IEnumerable<Assurance> FiltrerAssurance(TypeAssurance typeAssurance);

        void AjouterAssurance(Assurance assurance);

        void ModifierAssurance(Assurance assurance);

        void SupprimerAssurance(Assurance assurance);
        void SupprimerAssurance(int id);
    }
}

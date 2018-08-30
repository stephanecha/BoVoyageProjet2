using System.Collections.Generic;
using Class;
using DAL;

namespace Service
{
    public class ServiceAssurance : IServiceAssurance
    {
        private IDALAssurance dalAssurance;

        public ServiceAssurance()
        {

        }

        public void AjouterAssurance(Assurance assurance)
        {
            dalAssurance.AjouterAssurance(assurance);
        }

        public Assurance ChoisirAssurance(int id)
        {
            return dalAssurance.ChoisirAssurance(id);
        }

        public IEnumerable<Assurance> FiltrerAssurance(decimal minMontant = 0.0M, decimal maxMontant = decimal.MaxValue)
        {
            return dalAssurance.FiltrerAssurance(minMontant, maxMontant);
        }

        public IEnumerable<Assurance> FiltrerAssurance(TypeAssurance typeAssurance)
        {
            return dalAssurance.FiltrerAssurance(typeAssurance);
        }

        public IEnumerable<Assurance> ListerAssurance()
        {
            return dalAssurance.ListerAssurance();
        }

        public void ModifierAssurance(Assurance assurance)
        {
            dalAssurance.ModifierAssurance(assurance);
        }

        public void SupprimerAssurance(Assurance assurance)
        {
            dalAssurance.SupprimerAssurance(assurance);
        }
    }
}

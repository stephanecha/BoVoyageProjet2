using System.Collections.Generic;
using Class;
using DAL;

namespace Service
{
    public class ServiceAgenceVoyage : IServiceAgenceVoyage
    {
        private IDALAgenceVoyage dalAgenceVoyage;


        public ServiceAgenceVoyage()
        {
            dalAgenceVoyage = new DALAgenceVoyage();
        }

        public void AjouterAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            dalAgenceVoyage.AjouterAgenceVoyage(agenceVoyage);
        }

        public AgenceVoyage ChoisirAgenceVoyage(int id)
        {
            return dalAgenceVoyage.ChoisirAgenceVoyage(id);
        }

        public IEnumerable<AgenceVoyage> FiltrerAgenceVoyage(string filtre)
        {
            return dalAgenceVoyage.FiltrerAgenceVoyage(filtre);
        }

        public IEnumerable<AgenceVoyage> ListerAgenceVoyage()
        {
            return dalAgenceVoyage.ListerAgenceVoyage();
        }

        public void ModifierAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            dalAgenceVoyage.ModifierAgenceVoyage(agenceVoyage);
        }

        public void SupprimerAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            dalAgenceVoyage.SupprimerAgenceVoyage(agenceVoyage);
        }
    }
}

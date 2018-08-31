using System.Collections.Generic;
using Class;
using DAL;

namespace Service
{
    public class ServiceDossierReservation : IServiceDossierReservation
    {
        private IDALDossierReservation dalDossierReservation;

        public ServiceDossierReservation()
        {

        }

        public void AjouterDossierReservation(DossierReservation dossierReservation)
        {
            dalDossierReservation.AjouterDossierReservation(dossierReservation);
        }

        public DossierReservation ChoisirDossierReservation(int id)
        {
            return dalDossierReservation.ChoisirDossierReservation(id);
        }

        public IEnumerable<DossierReservation> FiltrerDossierReservation(RaisonAnnulationDossier raisonAnnulationDossier)
        {
            return dalDossierReservation.FiltrerDossierReservation(raisonAnnulationDossier);
        }

        public IEnumerable<DossierReservation> FiltrerDossierReservation(EtatDossierReservation etatDossierReservation)
        {
            return dalDossierReservation.FiltrerDossierReservation(etatDossierReservation);
        }

        public IEnumerable<DossierReservation> ListerDossierReservation()
        {
            return dalDossierReservation.ListerDossierReservation();
        }

        public void ModifierDossierReservation(DossierReservation dossierReservation)
        {
            dalDossierReservation.ModifierDossierReservation(dossierReservation);
        }

        public void SupprimerDossierReservation(DossierReservation dossierReservation)
        {
            dalDossierReservation.SupprimerDossierReservation(dossierReservation);
        }

        public void SupprimerDossierReservation(int id)
        {
            dalDossierReservation.SupprimerDossierReservation(id);
        }
    }
}

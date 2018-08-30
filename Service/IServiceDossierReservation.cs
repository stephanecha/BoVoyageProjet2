using System.Collections.Generic;
using Class;

namespace Service
{
    public interface IServiceDossierReservation
    {
        IEnumerable<DossierReservation> ListerDossierReservation();

        DossierReservation ChoisirDossierReservation(int id);

        IEnumerable<DossierReservation> FiltrerDossierReservation(RaisonAnnulationDossier raisonAnnulationDossier);
        IEnumerable<DossierReservation> FiltrerDossierReservation(EtatDossierReservation etatDossierReservation);

        void AjouterDossierReservation(DossierReservation dossierReservation);

        void ModifierDossierReservation(DossierReservation dossierReservation);

        void SupprimerDossierReservation(DossierReservation dossierReservation);
    }
}

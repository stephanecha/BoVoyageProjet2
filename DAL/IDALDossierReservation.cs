using System.Collections.Generic;
using Class;

namespace DAL
{
    public interface IDALDossierReservation
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

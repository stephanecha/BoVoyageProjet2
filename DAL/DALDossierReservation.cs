using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;

namespace DAL
{
    public class DALDossierReservation : IDALDossierReservation
    {
        public void AjouterDossierReservation(DossierReservation dossierReservation)
        {
            using (Context context = new Context())
            {
                context.DossiersReservations.Add(dossierReservation);
                context.SaveChanges();
            }
        }

        public DossierReservation ChoisirDossierReservation(int id)
        {
            using (Context context = new Context())
            {
                return context.DossiersReservations.Single(x => x.Id == id); // MANQUE LES ASSURANCES
            }
        }

        public IEnumerable<DossierReservation> FiltrerDossierReservation(RaisonAnnulationDossier raisonAnnulationDossier)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DossierReservation> FiltrerDossierReservation(EtatDossierReservation etatDossierReservation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DossierReservation> ListerDossierReservation()
        {
            using (Context context = new Context())
            {
                return context.DossiersReservations
                    .Include("Client")
                    .Include("Voyage")
                    .Include(x => x.Voyage.Destination)
                    .ToList();
            }
        }

        public void ModifierDossierReservation(DossierReservation dossierReservation)
        {
            using (Context context = new Context())
            {
                context.DossiersReservations.Attach(dossierReservation);
                context.Entry(dossierReservation).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SupprimerDossierReservation(DossierReservation dossierReservation)
        {
            using (Context context = new Context())
            {
                context.DossiersReservations.Attach(dossierReservation);
                context.DossiersReservations.Remove(dossierReservation);
                context.SaveChanges();
            }
        }

        public void SupprimerDossierReservation(int id)
        {
            using (Context context = new Context())
            {
                DossierReservation dossierReservation = context.DossiersReservations.Single(x => x.Id == id);
                context.DossiersReservations.Remove(dossierReservation);
                context.SaveChanges();
            }
        }
    }
}

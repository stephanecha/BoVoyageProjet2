using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;

namespace DAL
{
    public class DALVoyage : IDALVoyage
    {
        public void AjouterVoyage(Voyage voyage)
        {
            using (Context context = new Context())
            {
                context.Voyages.Add(voyage);
                context.SaveChanges();
            }
        }

        public Voyage ChoisirVoyage(int id)
        {
            using (Context context = new Context())
            {
                return context.Voyages.Single(x => x.Id == id);
            }
        }

        public IEnumerable<Voyage> FiltrerVoyage(Destination destination)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Voyage> FiltrerVoyage(DateTime dateAller, DateTime dateRetour)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Voyage> FiltrerVoyage(int minPlacesDisponibles)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Voyage> FiltrerVoyage(decimal maxPrixParPersonne)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Voyage> ListerVoyage()
        {
            using (Context context = new Context())
            {
                return context.Voyages.ToList();
            }
        }

        public void ModifierVoyage(Voyage voyage)
        {
            using (Context context = new Context())
            {
                context.Voyages.Attach(voyage);
                context.Entry(voyage).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SupprimerVoyage(Voyage voyage)
        {
            using (Context context = new Context())
            {
                context.Voyages.Attach(voyage);
                context.Voyages.Remove(voyage);
                context.SaveChanges();
            }
        }
    }
}

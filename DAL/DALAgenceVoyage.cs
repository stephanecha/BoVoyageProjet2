using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Class;

namespace DAL
{
    public class DALAgenceVoyage : IDALAgenceVoyage
    {
        public void AjouterAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            using (Context context = new Context())
            {
                context.AgencesVoyages.Add(agenceVoyage);
                context.SaveChanges();
            }
        }

        public AgenceVoyage ChoisirAgenceVoyage(int id)
        {
            using (Context context = new Context())
            {
                return context.AgencesVoyages.Single(x => x.Id == id);
            }
        }

        public IEnumerable<AgenceVoyage> FiltrerAgenceVoyage(string filtre)
        {
            using (Context context = new Context())
            {
                return context.AgencesVoyages
                                    .Where(x => x.Nom.Contains(filtre))
                                    .ToList();
            }
        }

        public IEnumerable<AgenceVoyage> ListerAgenceVoyage()
        {
            using (Context context = new Context())
            {
                return context.AgencesVoyages.ToList();
            }
        }

        public void ModifierAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            using (Context context = new Context())
            {
                context.AgencesVoyages.Attach(agenceVoyage);
                context.Entry(agenceVoyage).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SupprimerAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            using (Context context = new Context())
            {
                context.AgencesVoyages.Attach(agenceVoyage);
                context.AgencesVoyages.Remove(agenceVoyage);
                context.SaveChanges();
            }
        }
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Class;

namespace DAL
{
    public class DALDestination : IDALDestination
    {
        public void AjouterDestination(Destination destination)
        {
            using (Context context = new Context())
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }

        public Destination ChoisirDestination(int id)
        {
            using (Context context = new Context())
            {
                return context.Destinations.Single(x => x.Id == id);
            }
        }

        public IEnumerable<Destination> FiltrerDestination(string filtre)
        {
            using (Context context = new Context())
            {
                return context.Destinations
                                    .Where(x => x.Continent.Contains(filtre)
                                     || x.Pays.Contains(filtre)
                                     || x.Region.Contains(filtre)
                                     )
                                    .ToList();
            }
        }

        public IEnumerable<Destination> ListerDestination()
        {
            using (Context context = new Context())
            {
                return context.Destinations.ToList();
            }
        }

        public void ModifierDestination(Destination destination)
        {
            using (Context context = new Context())
            {
                context.Destinations.Attach(destination);
                context.Entry(destination).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SupprimerDestination(Destination destination)
        {
            using (Context context = new Context())
            {
                context.Destinations.Attach(destination);
                context.Destinations.Remove(destination);
                context.SaveChanges();
            }
        }

        public void SupprimerDestination(int id)
        {
            using (Context context = new Context())
            {
                Destination destination = context.Destinations.Single(x => x.Id == id);
                context.Destinations.Attach(destination);
                context.Destinations.Remove(destination);
                context.SaveChanges();
            }
        }
    }
}

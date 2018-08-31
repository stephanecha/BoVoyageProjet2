using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Class;

namespace DAL
{
    public class DALClient : IDALClient
    {
        public void AjouterClient(Client client)
        {
            using (Context context = new Context())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        public Client ChoisirClient(int id)
        {
            using (Context context = new Context())
            {
                return context.Clients.Single(x => x.Id == id);
            }
        }

        public IEnumerable<Client> FiltrerClient(string filtre)
        {
            using (Context context = new Context())
            {
                return context.Clients
                                    .Where(x => x.Nom.Contains(filtre)
                                     || x.Prenom.Contains(filtre)
                                     )
                                    .ToList();
            }
        }

        public IEnumerable<Client> ListerClient()
        {
            using (Context context = new Context())
            {
                return context.Clients.ToList();
            }
        }

        public void ModifierClient(Client client)
        {
            using (Context context = new Context())
            {
                context.Clients.Attach(client);
                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SupprimerClient(Client client)
        {
            using (Context context = new Context())
            {
                context.Clients.Attach(client);
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }

        public void SupprimerClient(int id)
        {
            using (Context context = new Context())
            {
                Client client = context.Clients.Single(x => x.Id == id);
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }
    }
}

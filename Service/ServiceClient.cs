using System.Collections.Generic;
using Class;
using DAL;

namespace Service
{
    public class ServiceClient : IServiceClient
    {
        private IDALClient dalClient;

        public ServiceClient()
        {

        }

        public void AjouterClient(Client client)
        {
            dalClient.AjouterClient(client);
        }

        public Client ChoisirClient(int id)
        {
            return dalClient.ChoisirClient(id);
        }

        public IEnumerable<Client> FiltrerClient(string filtre)
        {
            return dalClient.FiltrerClient(filtre);
        }

        public IEnumerable<Client> FiltrerClient(int age)
        {
            return dalClient.FiltrerClient(age);
        }

        public IEnumerable<Client> ListerClient()
        {
            return dalClient.ListerClient();
        }

        public void ModifierClient(Client client)
        {
            dalClient.ModifierClient(client);
        }

        public void SupprimerClient(Client client)
        {
            dalClient.SupprimerClient(client);
        }
    }
}

using System.Collections.Generic;
using Class;

namespace Service
{
    public interface IServiceClient
    {
        IEnumerable<Client> ListerClient();

        Client ChoisirClient(int id);

        IEnumerable<Client> FiltrerClient(string filtre);
        IEnumerable<Client> FiltrerClient(int age);

        void AjouterClient(Client client);

        void ModifierClient(Client client);

        void SupprimerClient(Client client);
        void SupprimerClient(int id);
    }
}

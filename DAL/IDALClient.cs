using System.Collections.Generic;
using Class;

namespace DAL
{
    public interface IDALClient
    {
        IEnumerable<Client> ListerClient();

        Client ChoisirClient(int id);

        IEnumerable<Client> FiltrerClient(string filtre);

        void AjouterClient(Client client);

        void ModifierClient(Client client);

        void SupprimerClient(Client client);
        void SupprimerClient(int id);
    }
}

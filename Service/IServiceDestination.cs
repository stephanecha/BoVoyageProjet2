using Class;
using System.Collections.Generic;

namespace Service
{
    public interface IServiceDestination
    {
        IEnumerable<Destination> ListerDestination();

        Destination ChoisirDestination(int id);

        IEnumerable<Destination> FiltrerDestination(string filtre);

        void AjouterDestination(Destination destination);

        void ModifierDestination(Destination destination);

        void SupprimerDestination(Destination destination);
        void SupprimerDestination(int id);
    }
}

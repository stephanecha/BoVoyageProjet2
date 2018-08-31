using System.Collections.Generic;
using Class;

namespace Service
{
    public interface IServiceAgenceVoyage
    {
        IEnumerable<AgenceVoyage> ListerAgenceVoyage();

        AgenceVoyage ChoisirAgenceVoyage(int id);

        IEnumerable<AgenceVoyage> FiltrerAgenceVoyage(string filtre);

        void AjouterAgenceVoyage(AgenceVoyage agenceVoyage);

        void ModifierAgenceVoyage(AgenceVoyage agenceVoyage);

        void SupprimerAgenceVoyage(AgenceVoyage agenceVoyage);
        void SupprimerAgenceVoyage(int id);
    }
}

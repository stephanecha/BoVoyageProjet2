using Class;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface IServiceVoyage
    {
        IEnumerable<Voyage> ListerVoyage();

        Voyage ChoisirVoyage(int id);

        IEnumerable<Voyage> FiltrerVoyage(Destination destination);
        IEnumerable<Voyage> FiltrerVoyage(DateTime dateAller, DateTime dateRetour);
        IEnumerable<Voyage> FiltrerVoyage(int minPlacesDisponibles);
        IEnumerable<Voyage> FiltrerVoyage(decimal maxPrixParPersonne);

        void AjouterVoyage(Voyage voyage);

        void ModifierVoyage(Voyage voyage);

        void SupprimerVoyage(Voyage voyage);
        void SupprimerVoyage(int id);
    }
}

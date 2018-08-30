using System;
using System.Collections.Generic;
using Class;
using DAL;

namespace Service
{
    public class ServiceVoyage : IServiceVoyage
    {
        private IDALVoyage dalVoyage;

        public ServiceVoyage()
        {

        }

        public void AjouterVoyage(Voyage voyage)
        {
            dalVoyage.AjouterVoyage(voyage);
        }

        public Voyage ChoisirVoyage(int id)
        {
            return dalVoyage.ChoisirVoyage(id);
        }

        public IEnumerable<Voyage> FiltrerVoyage(Destination destination)
        {
            return dalVoyage.FiltrerVoyage(destination);
        }

        public IEnumerable<Voyage> FiltrerVoyage(DateTime dateAller, DateTime dateRetour)
        {
            return dalVoyage.FiltrerVoyage(dateAller, dateRetour);
        }

        public IEnumerable<Voyage> FiltrerVoyage(int minPlacesDisponibles)
        {
            return dalVoyage.FiltrerVoyage(minPlacesDisponibles);
        }

        public IEnumerable<Voyage> FiltrerVoyage(decimal maxPrixParPersonne)
        {
            return dalVoyage.FiltrerVoyage(maxPrixParPersonne);
        }

        public IEnumerable<Voyage> ListerVoyage()
        {
            return dalVoyage.ListerVoyage();
        }

        public void ModifierVoyage(Voyage voyage)
        {
            dalVoyage.ModifierVoyage(voyage);
        }

        public void SupprimerVoyage(Voyage voyage)
        {
            dalVoyage.SupprimerVoyage(voyage);
        }
    }
}

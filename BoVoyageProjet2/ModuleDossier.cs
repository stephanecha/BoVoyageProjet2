using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using Class;
using Service;

namespace BoVoyageProjet2APP
{
    public class ModuleDossier : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageDossiers =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroUnique, "N° Unique", 20),
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroCarteBancaire, "N° CB", 20),
                InformationAffichage.Creer<DossierReservation>(x=>x.PrixParPersonne, "Prix/Pers", 15),
                InformationAffichage.Creer<DossierReservation>(x=>x.Etat, "Etat", 15),
                InformationAffichage.Creer<DossierReservation>(x=>x.Client, "Client", 20),
                InformationAffichage.Creer<DossierReservation>(x=>x.Voyage, "Voyage", 50)
            };

        private IEnumerable<DossierReservation> liste = new List<DossierReservation>();

        public ModuleDossier(Application application, string nomModule)
            : base(application, nomModule)
        {

        }

        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Afficher")
            {
                FonctionAExecuter = this.AfficherListe
            });
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void AfficherListe()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            try
            {
                ServiceDossierReservation service = new ServiceDossierReservation();
                this.liste = service.ListerDossierReservation();
                ConsoleHelper.AfficherListe(this.liste, strategieAffichageDossiers);
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'affichage des Dossiers de Réservation!");
            }
        }

    }
}

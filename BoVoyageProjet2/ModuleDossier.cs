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
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossierReservation>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroUnique, "NumeroUnique", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroCarteBancaire, "Numero de Carte Bancaire", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.PrixParPersonne, "Prix Par Personne", 15),
                InformationAffichage.Creer<DossierReservation>(x=>x.PrixTotal, "PrixTotal", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.EtatDossierReservation, "EtatDossierReservation", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.RaisonAnnulationDossier, "RaisonAnnulationDossier", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.IdClient, "IdClient", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.IdVoyage, "IdVoyage", 10),
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
                FonctionAExecuter = this.Afficher
            });
            menu.AjouterElement(new ElementMenu("2", "Nouveau")
            {
                FonctionAExecuter = this.Nouveau
            });
            menu.AjouterElement(new ElementMenu("3", "Modifier")
            {
                FonctionAExecuter = this.Modifier
            });
            menu.AjouterElement(new ElementMenu("4", "Supprimer")
            {
                FonctionAExecuter = this.Supprimer
            });
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Supprimer()
        {
            throw new NotImplementedException();
        }

        private void Modifier()
        {
            throw new NotImplementedException();
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var dossierReservation = new DossierReservation
            (
                numeroCarteBancaire: ConsoleSaisie.SaisirChaineObligatoire("numeroCarteBancaire ?"),
                idClient : ConsoleSaisie.SaisirEntierObligatoire("idClient ?"),
                idVoyage : ConsoleSaisie.SaisirEntierObligatoire("idVoyage ?")
            );

            ServiceDossierReservation service = new ServiceDossierReservation();
            service.AjouterDossierReservation(dossierReservation);
        }
    }
}

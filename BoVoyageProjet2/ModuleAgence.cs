using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using Class;
using Service;

namespace BoVoyageProjet2APP
{
    public class ModuleAgence : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Nom, "Nom", 10),
            };

        private IEnumerable<AgenceVoyage> liste = new List<AgenceVoyage>();

        public ModuleAgence(Application application, string nomModule)
            : base(application, nomModule)
        {

        }

        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Afficher")
            {
                FonctionAExecuter = this.AfficherListe
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
            ConsoleHelper.AfficherEntete("Destination à supprimer");

            ServiceAgenceVoyage  service = new ServiceAgenceVoyage();

            this.liste = service.ListerAgenceVoyage();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);

           // service.SupprimerAgenceVoyage(ConsoleSaisie.SaisirEntierObligatoire("Id Agence à supprimer ?"));
        }

        private void Modifier()
        {
            throw new NotImplementedException();
        }

        private void AfficherListe()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
            ConsoleHelper.AfficherEntete("Afficher");
            ServiceAgenceVoyage service = new ServiceAgenceVoyage();

            this.liste = service.ListerAgenceVoyage();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var AgenceVoyage = new AgenceVoyage
            (
                nom : ConsoleSaisie.SaisirChaineObligatoire("Nom ?")
            );

            //this.liste.Add(AgenceVoyage);
        }
    }
}

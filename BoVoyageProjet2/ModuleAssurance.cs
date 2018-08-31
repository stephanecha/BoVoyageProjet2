using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using Class;
using Service;


namespace BoVoyageProjet2APP
{
    public class ModuleAssurance : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Assurance>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Assurance>(x=>x.TypeAssurance, "Type", 10),
                InformationAffichage.Creer<Assurance>(x=>x.Montant, "Montant", 10),
            };

        private IEnumerable<Assurance> liste = new List<Assurance>();

        public ModuleAssurance(Application application, string nomModule)
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
            ConsoleHelper.AfficherEntete("Assurance à supprimer");

            ServiceAssurance service = new ServiceAssurance();

            this.liste = service.ListerAssurance();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);

            service.SupprimerAssurance(ConsoleSaisie.SaisirEntierObligatoire("Id Assurance à supprimer ?"));
        }

        private void Modifier()
        {
            throw new NotImplementedException();
        }

        private void AfficherListe()
        {
            ConsoleHelper.AfficherEntete("Afficher");
            ServiceAssurance service = new ServiceAssurance();

            this.liste = service.ListerAssurance();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");
            
            var assurance = new Assurance
            (
                typeAssurance: (TypeAssurance)ConsoleSaisie.SaisirEntierObligatoire("Type assurance (id) ?"),
                montant: ConsoleSaisie.SaisirDecimalObligatoire("Montant ?")
            );
            ServiceAssurance service = new ServiceAssurance();
            service.AjouterAssurance(assurance);
        }
    }
}

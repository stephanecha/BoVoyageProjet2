using System;
using System.Linq;
using System.Collections.Generic;
//using BoVoyage.Framework.Exemple.Metier;
using BoVoyage.Framework.UI;
using Class;
using Service;


namespace BoVoyageProjet2APP
{
    public class ModuleDestination : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Destination>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Destination>(x=>x.Continent, "Continent", 10),
                InformationAffichage.Creer<Destination>(x=>x.Pays, "Pays", 10),
                InformationAffichage.Creer<Destination>(x=>x.Description, "Description", 10),
            };


        private  IEnumerable<Destination> liste = new List<Destination>();

        public ModuleDestination(Application application, string nomModule)
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
            ConsoleHelper.AfficherEntete("Destination à supprimer");
      
            ServiceDestination service = new ServiceDestination();

            this.liste = service.ListerDestination();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);

            service.SupprimerDestination(ConsoleSaisie.SaisirEntierObligatoire("Id Destination à supprimer ?"));


        }

        private void Modifier()
        {
            throw new NotImplementedException();
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher");
            ServiceDestination service = new ServiceDestination();

            this.liste = service.ListerDestination();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");
            
            var destination = new Destination
            (
                continent: ConsoleSaisie.SaisirChaineObligatoire("continent ?"),
                pays: ConsoleSaisie.SaisirChaineObligatoire("pays ?"),
                region: ConsoleSaisie.SaisirChaineObligatoire("region ?"),
                description: ConsoleSaisie.SaisirChaineObligatoire("description ?")
            );
            ServiceDestination service = new ServiceDestination();
            service.AjouterDestination(destination);
        }
    }
}

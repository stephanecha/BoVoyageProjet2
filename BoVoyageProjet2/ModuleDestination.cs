using System;
using System.Collections.Generic;
//using BoVoyage.Framework.Exemple.Metier;
using BoVoyage.Framework.UI;
using Class;

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


        private readonly List<Destination> liste = new List<Destination>();

        public ModuleDestination(Application application, string nomModule)
            : base(application, nomModule)
        {
            this.liste = new List<Destination>
            {
                //new Client{Id = 1, Nom = "BAZAN", Prenom = "Yannick", DateNaissance = "",Email = "ybazan.pro@live.fr" },
                //new Client{Id = 2, Nom = "PEANT", Prenom = "Frédéric", Email = "f.peant@gtm-ingenierie.fr" },
            };
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

            var Destination = new Destination
            (
                continent: ConsoleSaisie.SaisirChaineObligatoire("continent ?"),
                pays: ConsoleSaisie.SaisirChaineObligatoire("pays ?"),
                region: ConsoleSaisie.SaisirChaineObligatoire("region ?"),
                description: ConsoleSaisie.SaisirChaineObligatoire("description ?")
            );
   
            this.liste.Add(Destination);
        }
    }
}

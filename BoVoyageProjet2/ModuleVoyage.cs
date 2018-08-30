using System;
using System.Collections.Generic;
//using BoVoyage.Framework.Exemple.Metier;
using BoVoyage.Framework.UI;
using Class;

namespace BoVoyageProjet2APP
{
    public class ModuleVoyage : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Voyage>(x=>x.DateAller, "Date d'Aller", 10),
                InformationAffichage.Creer<Voyage>(x=>x.DateRetour, "Date de Retour", 10),
                InformationAffichage.Creer<Voyage>(x=>x.PlacesDisponibles, "Places Disponibles", 15),
                InformationAffichage.Creer<Voyage>(x=>x.PrixParPersonne, "Prix Par Personne", 10),
                InformationAffichage.Creer<Voyage>(x=>x.IdDestination, "IdDestination", 10),
                InformationAffichage.Creer<Voyage>(x=>x.IdAgenceVoyage, "IdAgenceVoyage", 10),
            };

        private readonly List<Voyage> liste = new List<Voyage>();

        public ModuleVoyage(Application application, string nomModule)
            : base(application, nomModule)
        {
            this.liste = new List<Voyage>
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

            var Voyage = new Voyage
            (
                dateAller : ConsoleSaisie.SaisirDateObligatoire("dateAller ?"),
                dateRetour : ConsoleSaisie.SaisirDateObligatoire("dateRetour ?"),
                placesDisponibles : ConsoleSaisie.SaisirEntierObligatoire("Places Disponibles ?"),
                prixParPersonne : ConsoleSaisie.SaisirEntierObligatoire("Prix Par Personne ?")
            );

            this.liste.Add(Voyage);


        }
    }
}

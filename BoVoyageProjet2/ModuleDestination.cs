using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using Class;
using Service;

namespace BoVoyageProjet2APP
{
    public class ModuleDestination : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageDestinations =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Destination>(x=>x.Continent, "Continent", 20),
                InformationAffichage.Creer<Destination>(x=>x.Pays, "Pays", 20),
                InformationAffichage.Creer<Destination>(x=>x.Region, "Region", 20)
            };

        private static readonly List<InformationAffichage> strategieDelModifDestinations =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Destination>(x=>x.Continent, "Continent", 20),
                InformationAffichage.Creer<Destination>(x=>x.Pays, "Pays", 20),
                InformationAffichage.Creer<Destination>(x=>x.Region, "Region", 20)
            };

        private IEnumerable<Destination> liste = new List<Destination>();

        public ModuleDestination(Application application, string nomModule)
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
            ConsoleHelper.AfficherEntete("Supprimer");

            try
            {
                ServiceDestination service = new ServiceDestination();

                this.liste = service.ListerDestination();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifDestinations);

                service.SupprimerDestination(ConsoleSaisie.SaisirEntierObligatoire("ID de la Destination à supprimer : "));
                ConsoleHelper.AfficherLibelleSaisie("Destination supprimée !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la suppression de la Destination !");
            }
        }

        private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier");

            try
            {
                ServiceDestination service = new ServiceDestination();

                this.liste = service.ListerDestination();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifDestinations);

                Destination destination = service.ChoisirDestination(ConsoleSaisie.SaisirEntierObligatoire("ID de la Destination à modifier : "));

                ConsoleHelper.AfficherLibelleSaisie("Laisser le champ vide pour ne pas le modifier.");

                string saisie = ConsoleSaisie.SaisirChaineOptionnelle("Continent : ");
                destination.Continent = string.IsNullOrWhiteSpace(saisie) ? destination.Continent : saisie;

                saisie = ConsoleSaisie.SaisirChaineOptionnelle("Pays : ");
                destination.Pays = string.IsNullOrWhiteSpace(saisie) ? destination.Pays : saisie;

                saisie = ConsoleSaisie.SaisirChaineOptionnelle("Region : ");
                destination.Region = string.IsNullOrWhiteSpace(saisie) ? destination.Region : saisie;

                saisie = ConsoleSaisie.SaisirChaineOptionnelle("Description : ");
                destination.Description = string.IsNullOrWhiteSpace(saisie) ? destination.Description : saisie;

                service.ModifierDestination(destination);
                ConsoleHelper.AfficherLibelleSaisie("Destination modifiée !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la modification de la Destination !");
            }
        }

        private void AfficherListe()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            try
            {
                ServiceDestination service = new ServiceDestination();
                this.liste = service.ListerDestination();
                ConsoleHelper.AfficherListe(this.liste, strategieAffichageDestinations);
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'affichage des Destinations !");
            }
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            try
            {
                var destination = new Destination(
                    continent: ConsoleSaisie.SaisirChaineObligatoire("Civilite : "),
                    pays: ConsoleSaisie.SaisirChaineObligatoire("Civilite : "),
                    region: ConsoleSaisie.SaisirChaineObligatoire("Nom : ")
                );

                var description = ConsoleSaisie.SaisirChaineOptionnelle("Description : ");
                destination.Description = string.IsNullOrWhiteSpace(description) ? null : description;

                ServiceDestination service = new ServiceDestination();
                service.AjouterDestination(destination);
                ConsoleHelper.AfficherLibelleSaisie("Destination ajoutée !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'ajout de la Destination !");
            }
        }
    }
}

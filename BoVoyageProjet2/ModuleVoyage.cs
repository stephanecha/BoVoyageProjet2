using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using Class;
using Service;

namespace BoVoyageProjet2APP
{
    public class ModuleVoyage : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageVoyages =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyage>(x=>x.DateAller, "Aller le", 10),
                InformationAffichage.Creer<Voyage>(x=>x.DateRetour, "Retour le", 10),
                InformationAffichage.Creer<Voyage>(x=>x.PlacesDisponibles, "Places Dispo", 15),
                InformationAffichage.Creer<Voyage>(x=>x.PrixParPersonne, "Prix/Pers", 10),
                InformationAffichage.Creer<Voyage>(x=>x.AgenceVoyage, "Agence", 20),
                InformationAffichage.Creer<Voyage>(x=>x.Destination, "Dest", 50)
            };

        private static readonly List<InformationAffichage> strategieDelModifVoyages =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Voyage>(x=>x.DateAller, "Aller le", 10),
                InformationAffichage.Creer<Voyage>(x=>x.DateRetour, "Retour le", 10),
                InformationAffichage.Creer<Voyage>(x=>x.PlacesDisponibles, "Places Dispo", 15),
                InformationAffichage.Creer<Voyage>(x=>x.PrixParPersonne, "Prix/Pers", 10),
                InformationAffichage.Creer<Voyage>(x=>x.IdAgenceVoyage, "IdAgence", 10),
                InformationAffichage.Creer<Voyage>(x=>x.IdDestination, "IdDest", 10)
            };

        private IEnumerable<Voyage> liste = new List<Voyage>();

        public ModuleVoyage(Application application, string nomModule)
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
                ServiceVoyage service = new ServiceVoyage();

                this.liste = service.ListerVoyage();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifVoyages);

                service.SupprimerVoyage(ConsoleSaisie.SaisirEntierObligatoire("ID du Voyage à supprimer : "));
                ConsoleHelper.AfficherLibelleSaisie("Voyage supprimé !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la suppression du Voyage !");
            }
        }

        private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier");

            try
            {
                ServiceVoyage service = new ServiceVoyage();

                this.liste = service.ListerVoyage();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifVoyages);

                Voyage voyage = service.ChoisirVoyage(ConsoleSaisie.SaisirEntierObligatoire("ID du Voyage à modifier : "));

                ConsoleHelper.AfficherLibelleSaisie("Laisser le champ vide pour ne pas le modifier.");

                DateTime? saisieDate = ConsoleSaisie.SaisirDateOptionnelle("Date Aller : ");
                voyage.DateAller = saisieDate ?? voyage.DateAller;

                saisieDate = ConsoleSaisie.SaisirDateOptionnelle("Date Retour : ");
                voyage.DateRetour = saisieDate ?? voyage.DateRetour;

                int? saisie = ConsoleSaisie.SaisirEntierOptionnel("Places Disponibles : ");
                voyage.PlacesDisponibles = saisie ?? voyage.PlacesDisponibles;

                decimal? prix = ConsoleSaisie.SaisirDecimalOptionnel("Prix Par Personne : ");
                voyage.PrixParPersonne = prix ?? voyage.PrixParPersonne;

                saisie = ConsoleSaisie.SaisirEntierOptionnel("Destination (ID) : ");
                voyage.IdDestination = saisie ?? voyage.IdDestination;

                saisie = ConsoleSaisie.SaisirEntierOptionnel("Agence de Voyage (ID) : ");
                voyage.IdAgenceVoyage = saisie ?? voyage.IdAgenceVoyage;

                service.ModifierVoyage(voyage);
                ConsoleHelper.AfficherLibelleSaisie("Voyage modifié !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la modification du Voyage !");
            }
        }

        private void AfficherListe()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            try
            {
                ServiceVoyage service = new ServiceVoyage();
                this.liste = service.ListerVoyage();
                ConsoleHelper.AfficherListe(this.liste, strategieAffichageVoyages);
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'affichage des Voyages !");
            }
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            try
            {
                var voyage = new Voyage
                (
                    dateAller: ConsoleSaisie.SaisirDateObligatoire("Date Aller : "),
                    dateRetour: ConsoleSaisie.SaisirDateObligatoire("Date Retour : "),
                    placesDisponibles: ConsoleSaisie.SaisirEntierObligatoire("Places Disponibles : "),
                    prixParPersonne: ConsoleSaisie.SaisirDecimalObligatoire("Prix Par Personne : "),
                    idDestination: ConsoleSaisie.SaisirEntierObligatoire("Destination (ID) : "),
                    idAgenceVoyage: ConsoleSaisie.SaisirEntierObligatoire("Agence de voyage (ID) : ")
                );

                ServiceVoyage service = new ServiceVoyage();
                service.AjouterVoyage(voyage);
                ConsoleHelper.AfficherLibelleSaisie("Voyage ajouté !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'ajout du Voyage !");
            }
        }
    }
}

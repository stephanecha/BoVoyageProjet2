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
        private static readonly List<InformationAffichage> strategieAffichageAgences =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Nom, "Nom", 20)
            };

        private static readonly List<InformationAffichage> strategieDelModifAgences =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Nom, "Nom", 20)
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
            ConsoleHelper.AfficherEntete("Supprimer");

            try
            {
                ServiceAgenceVoyage service = new ServiceAgenceVoyage();

                this.liste = service.ListerAgenceVoyage();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifAgences);

                service.SupprimerAgenceVoyage(ConsoleSaisie.SaisirEntierObligatoire("ID de l'Agence de Voyage à supprimer : "));
                ConsoleHelper.AfficherLibelleSaisie("Agence de Voyage supprimée !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la suppression de l'Agence de Voyage !");
            }
        }

        private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier");

            try
            {
                ServiceAgenceVoyage service = new ServiceAgenceVoyage();

                this.liste = service.ListerAgenceVoyage();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifAgences);

                AgenceVoyage agenceVoyage = service.ChoisirAgenceVoyage(ConsoleSaisie.SaisirEntierObligatoire("ID de l'Agence de Voyage à modifier : "));

                ConsoleHelper.AfficherLibelleSaisie("Laisser le champ vide pour ne pas le modifier.");

                string saisie = ConsoleSaisie.SaisirChaineOptionnelle("Nom : ");
                agenceVoyage.Nom = string.IsNullOrWhiteSpace(saisie) ? agenceVoyage.Nom : saisie;

                service.ModifierAgenceVoyage(agenceVoyage);
                ConsoleHelper.AfficherLibelleSaisie("Agence de Voyage modifiée !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la modification de l'Agence de Voyage !");
            }
        }

        private void AfficherListe()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            try
            {
                ServiceAgenceVoyage service = new ServiceAgenceVoyage();
                this.liste = service.ListerAgenceVoyage();
                ConsoleHelper.AfficherListe(this.liste, strategieAffichageAgences);
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'affichage des Agences de Voyage !");
            }
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            try
            {
                var agenceVoyage = new AgenceVoyage(
                    nom: ConsoleSaisie.SaisirChaineObligatoire("Nom : ")
                );

                ServiceAgenceVoyage service = new ServiceAgenceVoyage();
                service.AjouterAgenceVoyage(agenceVoyage);
                ConsoleHelper.AfficherLibelleSaisie("Agence de Voyage ajoutée !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'ajout de l'Agence de Voyage !");
            }
        }
    }
}

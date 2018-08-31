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
        private static readonly List<InformationAffichage> strategieAffichageAssurances =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Assurance>(x=>x.Type, "Type", 10),
                InformationAffichage.Creer<Assurance>(x=>x.Montant, "Montant", 10),
            };

        private static readonly List<InformationAffichage> strategieDelModifAssurances =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Assurance>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Assurance>(x=>x.Type, "Type", 10),
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
            ConsoleHelper.AfficherEntete("Supprimer");

            try
            {
                ServiceAssurance service = new ServiceAssurance();

                this.liste = service.ListerAssurance();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifAssurances);

                service.SupprimerAssurance(ConsoleSaisie.SaisirEntierObligatoire("ID de l'Assurance à supprimer : "));
                ConsoleHelper.AfficherLibelleSaisie("Assurance supprimés !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la suppression de l'Assurance !");
            }
        }

        private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier");

            try
            {
                ServiceAssurance service = new ServiceAssurance();

                this.liste = service.ListerAssurance();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifAssurances);

                ConsoleHelper.AfficherLibelleSaisie("Laisser le champ vide pour ne pas le modifier.");

                Assurance assurance = service.ChoisirAssurance(ConsoleSaisie.SaisirEntierObligatoire("ID de l'Assurance à modifier : "));

                string saisie = ConsoleSaisie.SaisirChaineOptionnelle("Type (ID) : ");

                if (byte.TryParse(saisie, out byte result) && Enum.IsDefined(typeof(TypeAssurance), result))
                    assurance.Type = (TypeAssurance)result;

                decimal? montant = ConsoleSaisie.SaisirDecimalOptionnel("Montant : ");
                assurance.Montant = montant ?? assurance.Montant;

                service.ModifierAssurance(assurance);
                ConsoleHelper.AfficherLibelleSaisie("Assurance modifiée !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la modification de l'Assurance !");
            }
        }

        private void AfficherListe()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            try
            {
                ServiceAssurance service = new ServiceAssurance();
                this.liste = service.ListerAssurance();
                ConsoleHelper.AfficherListe(this.liste, strategieAffichageAssurances);
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'affichage des Assurances !");
            }
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            try
            {
                var assurance = new Assurance(
                    type: (TypeAssurance)byte.Parse(ConsoleSaisie.SaisirChaineObligatoire("type (ID) : ")),
                    montant: ConsoleSaisie.SaisirDecimalObligatoire("Montant : ")
                );

                ServiceAssurance service = new ServiceAssurance();
                service.AjouterAssurance(assurance);
                ConsoleHelper.AfficherLibelleSaisie("Assurance ajoutée !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'ajout de l'Assurance !");
            }
        }
    }
}

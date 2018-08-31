using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using Class;

namespace BoVoyageProjet2APP
{
    public class ModuleClient : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Client>(x=>x.Civilite, "Civilite", 3),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prenom", 10),
                InformationAffichage.Creer<Client>(x=>x.Adresse, "Adresse", 10),
                InformationAffichage.Creer<Client>(x=>x.Telephone, "Telephone", 10),
                InformationAffichage.Creer<Client>(x=>x.Email, "Email", 15),
                InformationAffichage.Creer<Client>(x=>x.DateNaissance, "Date de Naissance", 10),
                InformationAffichage.Creer<Client>(x=>x.Age, "Age", 10),
            };

        private IEnumerable<Client> liste = new List<Client>();

        public ModuleClient(Application application, string nomModule)
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

            var client = new Client
            (
                civilite : ConsoleSaisie.SaisirChaineObligatoire("Civilite ?"),
                nom : ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                prenom : ConsoleSaisie.SaisirChaineObligatoire("Prenom ?"),
                email : ConsoleSaisie.SaisirChaineObligatoire("Email ?"),
                dateNaissance : ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?")
            );

            // this.liste.Add(client);
        }
    }
}

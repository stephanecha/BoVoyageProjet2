using System;
using System.Collections.Generic;
using BoVoyage.Framework.UI;
using Class;
using Service;

namespace BoVoyageProjet2APP
{
    public class ModuleClient : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Civilite, "Civilite", 14),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prenom", 15),
                InformationAffichage.Creer<Client>(x=>x.Adresse, "Adresse", 20),
                InformationAffichage.Creer<Client>(x=>x.Telephone, "Tel", 15),
                InformationAffichage.Creer<Client>(x=>x.Email, "Email", 15),
                InformationAffichage.Creer<Client>(x=>x.Age, "Age", 2)
            };

        private static readonly List<InformationAffichage> strategieDelModifClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Id, "ID", 3),
                InformationAffichage.Creer<Client>(x=>x.Civilite, "Civilite", 14),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prenom", 15),
                InformationAffichage.Creer<Client>(x=>x.Adresse, "Adresse", 20)
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
                ServiceClient service = new ServiceClient();

                this.liste = service.ListerClient();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifClients);

                service.SupprimerClient(ConsoleSaisie.SaisirEntierObligatoire("ID du Client à supprimer : "));
                ConsoleHelper.AfficherLibelleSaisie("Client supprimé !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la suppression du Client !");
            }
        }

        private void Modifier()
        {
            ConsoleHelper.AfficherEntete("Modifier");

            try
            {
                ServiceClient service = new ServiceClient();

                this.liste = service.ListerClient();
                ConsoleHelper.AfficherListe(this.liste, strategieDelModifClients);

                Client client = service.ChoisirClient(ConsoleSaisie.SaisirEntierObligatoire("ID du Client à modifier : "));

                ConsoleHelper.AfficherLibelleSaisie("Laisser le champ vide pour ne pas le modifier.");

                string saisie = ConsoleSaisie.SaisirChaineOptionnelle("Civilite : ");
                client.Civilite = string.IsNullOrWhiteSpace(saisie) ? client.Civilite : saisie;

                saisie = ConsoleSaisie.SaisirChaineOptionnelle("Nom : ");
                client.Nom = string.IsNullOrWhiteSpace(saisie) ? client.Nom : saisie;

                saisie = ConsoleSaisie.SaisirChaineOptionnelle("Prenom : ");
                client.Prenom = string.IsNullOrWhiteSpace(saisie) ? client.Prenom : saisie;

                saisie = ConsoleSaisie.SaisirChaineOptionnelle("Email : ");
                client.Email = string.IsNullOrWhiteSpace(saisie) ? client.Email : saisie;

                saisie = ConsoleSaisie.SaisirChaineOptionnelle("Adresse : ");
                client.Adresse = string.IsNullOrWhiteSpace(saisie) ? client.Adresse : saisie;

                saisie = ConsoleSaisie.SaisirChaineOptionnelle("Téléphone : ");
                client.Telephone = string.IsNullOrWhiteSpace(saisie) ? client.Telephone : saisie;

                DateTime? saisieDate = ConsoleSaisie.SaisirDateOptionnelle("Date de Naissance : ");
                client.DateNaissance = saisieDate ?? client.DateNaissance;

                service.ModifierClient(client);
                ConsoleHelper.AfficherLibelleSaisie("Client modifié !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de la modification du Client !");
            }
        }

        private void AfficherListe()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            try
            {
                ServiceClient service = new ServiceClient();
                this.liste = service.ListerClient();
                ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'affichage des Clients !");
            }
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            try
            {
                var client = new Client(
                    civilite: ConsoleSaisie.SaisirChaineObligatoire("Civilite : "),
                    nom: ConsoleSaisie.SaisirChaineObligatoire("Nom : "),
                    prenom: ConsoleSaisie.SaisirChaineObligatoire("Prenom : "),
                    email: ConsoleSaisie.SaisirChaineObligatoire("Email : "),
                    dateNaissance: ConsoleSaisie.SaisirDateObligatoire("Date de Naissance : "),
                    adresse: ConsoleSaisie.SaisirChaineObligatoire("Adresse : "),
                    telephone: ConsoleSaisie.SaisirChaineObligatoire("Téléphone : ")
                );

                ServiceClient service = new ServiceClient();
                service.AjouterClient(client);
                ConsoleHelper.AfficherLibelleSaisie("Client ajouté !");
            }
            catch
            {
                ConsoleHelper.AfficherMessageErreur("Problème lors de l'ajout du Client !");
            }
        }
    }
}

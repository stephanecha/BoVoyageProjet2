﻿using System;
using System.Collections.Generic;
//using BoVoyage.Framework.Exemple.Metier;
using BoVoyage.Framework.UI;
using Class;

namespace BoVoyageProjet2APP
{
    public class ModuleAgence : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prenom", 10),
                InformationAffichage.Creer<Client>(x=>x.Email, "Email", 15),
                InformationAffichage.Creer<Client>(x=>x.DateNaissance, "Date", 10),
            };

        private readonly List<Client> liste = new List<Client>();

        public ModuleAgence(Application application, string nomModule)
            : base(application, nomModule)
        {
            this.liste = new List<Client>
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
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void Afficher()
        {
            ConsoleHelper.AfficherEntete("Afficher");

            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            //var client = new Client
            //{
            //    Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
            //    Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
            //    Email = ConsoleSaisie.SaisirChaineOptionnelle("Email ?"),
            //    //DateNaissance = ConsoleSaisie.SaisirDateOptionnelle("Date d'inscription ?")
            //};

            //this.liste.Add(client);
        }
    }
}

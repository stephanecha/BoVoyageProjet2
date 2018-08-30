using System;
using System.Linq;
using System.Collections.Generic;
//using BoVoyage.Framework.Exemple.Metier;
using BoVoyage.Framework.UI;
using Class;
using Service;

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

        private  IEnumerable<Voyage> liste = new List<Voyage>();

        public ModuleVoyage(Application application, string nomModule)
            : base(application, nomModule)
        {
            //ServiceAgenceVoyage service = new ServiceAgenceVoyage();

            //this.liste = service.ListerAgenceVoyage();
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

            ServiceVoyage service = new ServiceVoyage();

            this.liste = service.ListerVoyage();
            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var voyage = new Voyage
            (
                dateAller : ConsoleSaisie.SaisirDateObligatoire("dateAller ?"),
                dateRetour : ConsoleSaisie.SaisirDateObligatoire("dateRetour ?"),
                placesDisponibles : ConsoleSaisie.SaisirEntierObligatoire("Places Disponibles ?"),
                prixParPersonne : ConsoleSaisie.SaisirEntierObligatoire("Prix Par Personne ?")
            );
           
            ServiceVoyage service = new ServiceVoyage();
            service.AjouterVoyage(voyage);

        }
    }
}

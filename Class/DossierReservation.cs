﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public enum EtatDossierReservation : byte
    {
        EnAttente,
        EnCours,
        Refusee,
        Acceptee
    }

    public enum RaisonAnnulationDossier : byte
    {
        Client = 1,
        PlacesInsuffisantes
    }

    public class DossierReservation
    {
        public int Id { get; set; }
        public int NumeroUnique { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixParPersonne { get; set; }
        public decimal PrixTotal { get; }
        public EtatDossierReservation EtatDossierReservation { get; set; }
        public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }

        public int IdClient { get; set; }
        public int IdVoyage { get; set; }

        public void Annuler(RaisonAnnulationDossier raison)
        {
            EtatDossierReservation = EtatDossierReservation.Refusee;
            RaisonAnnulationDossier = raison;
        }

        public void ValiderSolvabilité()
        {

        }
        public void Accepter()
        {

        }
    }
}
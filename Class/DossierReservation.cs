﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [Table("DossiersReservations")]
    public class DossierReservation
    {
        public int Id { get; set; }

        [Required]
        public int NumeroUnique { get; set; }

        [Required]
        public string NumeroCarteBancaire { get; set; }

        [Required]
        public decimal PrixParPersonne { get; set; }

        public decimal PrixTotal { get; set; }

        [Required]
        [EnumDataType(typeof(EtatDossierReservation))]
        public EtatDossierReservation Etat { get; set; }

        public int IdClient { get; set; }

        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        
        public int IdVoyage { get; set; }

        [ForeignKey("IdVoyage")]
        public virtual Voyage Voyage { get; set; }
        
        //public virtual ICollection<Assurance> Assurances { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public DossierReservation() { }

        /*public DossierReservation (string numeroCarteBancaire, Client client, Voyage voyage, ICollection<Assurance> assurances, int nbParticipants)
        {
            IdClient = client.Id;
            IdVoyage = voyage.Id;

            string ids = client.Id.ToString() + voyage.Id.ToString() + nbParticipants.ToString() + DateTime.Now.ToString();
            Guid guid = new Guid(ids);
            NumeroUnique = guid.GetHashCode();
            
            NumeroCarteBancaire = numeroCarteBancaire;
            Etat = EtatDossierReservation.EnAttente;

            decimal montantTotalAssurances = 0.0m;
            foreach (Assurance assurance in assurances)
                montantTotalAssurances += assurance.Montant;
            PrixParPersonne = voyage.PrixParPersonne * 1.2m + montantTotalAssurances;
            //PrixTotal =  + montantTotalAssurances;
        }*/

        public void Annuler(RaisonAnnulationDossier raison)
        {
            //Etat = EtatDossierReservation.Refusee;
            //RaisonAnnulation = raison;
        }

        public void ValiderSolvabilité()
        {
            /*foreach (Participant participant in Participants)
                PrixTotal += PrixParPersonne * Convert.ToDecimal(participant.Reduction);*/
        }

        public void Accepter()
        {

        }
    }
}

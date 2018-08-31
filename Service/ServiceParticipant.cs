using System.Collections.Generic;
using Class;
using DAL;

namespace Service
{
    public class ServiceParticipant : IServiceParticipant
    {
        private IDALParticipant dalParticipant;

        public ServiceParticipant()
        {

        }

        public void AjouterParticipant(Participant participant)
        {
            dalParticipant.AjouterParticipant(participant);
        }

        public Participant ChoisirParticipant(int id)
        {
            return dalParticipant.ChoisirParticipant(id);
        }

        public IEnumerable<Participant> FiltrerParticipant(string filtre)
        {
            return dalParticipant.FiltrerParticipant(filtre);
        }

        public IEnumerable<Participant> FiltrerParticipant(int age)
        {
            return dalParticipant.FiltrerParticipant(age);
        }

        public IEnumerable<Participant> ListerParticipant()
        {
            return dalParticipant.ListerParticipant();
        }

        public void ModifierParticipant(Participant participant)
        {
            dalParticipant.ModifierParticipant(participant);
        }

        public void SupprimerParticipant(Participant participant)
        {
            dalParticipant.SupprimerParticipant(participant);
        }

        public void SupprimerParticipant(int id)
        {
            dalParticipant.SupprimerParticipant(id);
        }
    }
}

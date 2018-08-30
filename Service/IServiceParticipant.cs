using System.Collections.Generic;
using Class;

namespace Service
{
    public interface IServiceParticipant
    {
        IEnumerable<Participant> ListerParticipant();

        Participant ChoisirParticipant(int id);

        IEnumerable<Participant> FiltrerParticipant(string filtre);
        IEnumerable<Participant> FiltrerParticipant(int age);

        void AjouterParticipant(Participant participant);

        void ModifierParticipant(Participant participant);

        void SupprimerParticipant(Participant participant);
    }
}

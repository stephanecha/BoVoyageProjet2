using System.Collections.Generic;
using Class;

namespace DAL
{
    public interface IDALParticipant
    {
        IEnumerable<Participant> ListerParticipant();

        Participant ChoisirParticipant(int id);

        IEnumerable<Participant> FiltrerParticipant(string filtre);
        IEnumerable<Participant> FiltrerParticipant(int age);

        void AjouterParticipant(Participant participant);

        void ModifierParticipant(Participant participant);

        void SupprimerParticipant(Participant participant);
        void SupprimerParticipant(int id);
    }
}

using System.Collections.Generic;
using Class;
using DAL;

namespace Service
{
    public class ServiceDestination : IServiceDestination
    {
        private IDALDestination dALDestination;

        public ServiceDestination()
        {
            dALDestination = new DALDestination();
        }

        public void AjouterDestination(Destination destination)
        {
            dALDestination.AjouterDestination(destination);
        }

        public Destination ChoisirDestination(int id)
        {
            return dALDestination.ChoisirDestination(id);
        }

        public IEnumerable<Destination> FiltrerDestination(string filtre)
        {
            return dALDestination.FiltrerDestination(filtre);
        }

        public IEnumerable<Destination> ListerDestination()
        {
            return dALDestination.ListerDestination();
        }

        public void ModifierDestination(Destination destination)
        {
            dALDestination.ModifierDestination(destination);
        }

        public void SupprimerDestination(Destination destination)
        {
            dALDestination.SupprimerDestination(destination);
        }

        public void SupprimerDestination(int id)
        {
            dALDestination.SupprimerDestination(id);
        }
    }
}

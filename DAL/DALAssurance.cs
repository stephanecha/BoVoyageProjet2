using System.Collections.Generic;
using System.Linq;
using Class;

namespace DAL
{
    public class DALAssurance : IDALAssurance
    {
        public void AjouterAssurance(Assurance assurance)
        {
            using (Context context = new Context())
            {
                context.Assurances.Add(assurance);
                context.SaveChanges();
            }
        }

        public Assurance ChoisirAssurance(int id)
        {
            using (Context context = new Context())
            {
                return context.Assurances.Single(x => x.Id == id);
            }
        }

        public IEnumerable<Assurance> FiltrerAssurance(decimal minMontant = 0.0M, decimal maxMontant = decimal.MaxValue)
        {
            using (Context context = new Context())
            {
                return context.Assurances
                                    .Where(x => x.Montant >= minMontant
                                    && x.Montant <= minMontant
                                     )
                                    .ToList();
            }
        }

        public IEnumerable<Assurance> FiltrerAssurance(TypeAssurance typeAssurance)
        {
            using (Context context = new Context())
            {
                return context.Assurances
                                    .Where(x => x.Type == typeAssurance)
                                    .ToList();
            }
        }

        public IEnumerable<Assurance> ListerAssurance()
        {
            using (Context context = new Context())
            {
                return context.Assurances.ToList();
            }
        }

        public void ModifierAssurance(Assurance assurance)
        {
            using (Context context = new Context())
            {
                context.Assurances.Attach(assurance);
                context.Assurances.Remove(assurance);
                context.SaveChanges();
            }
        }

        public void SupprimerAssurance(Assurance assurance)
        {
            using (Context context = new Context())
            {
                context.Assurances.Attach(assurance);
                context.Assurances.Remove(assurance);
                context.SaveChanges();
            }
        }

        public void SupprimerAssurance(int id)
        {
            using (Context context = new Context())
            {
                Assurance assurance = context.Assurances.Single(x => x.Id == id);
                context.Assurances.Remove(assurance);
                context.SaveChanges();
            }
        }
    }
}

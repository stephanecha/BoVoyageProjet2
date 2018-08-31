using BoVoyage.Framework.UI;

namespace BoVoyageProjet2APP
{
    public class Application : ApplicationBase
    {
        public Application()
            : base("BO VOYAGE")
        {
        }

        public ModuleClient ModuleClient { get; private set; }
        public ModuleVoyage ModuleVoyage { get; private set; }
        public ModuleDossier ModuleDossier { get; private set; }
        public ModuleAgence ModuleAgence { get; private set; }
        public ModuleDestination ModuleDestination { get; private set; }
        public ModuleAssurance ModuleAssurance { get; private set; }

        protected override void InitialiserModules()
        {
            this.ModuleClient = this.AjouterModule(new ModuleClient(this, "Clients"));
            this.ModuleVoyage = this.AjouterModule(new ModuleVoyage(this, "Voyages"));
            this.ModuleDossier = this.AjouterModule(new ModuleDossier(this, "Dossier"));
            this.ModuleAgence = this.AjouterModule(new ModuleAgence(this, "Agence"));
            this.ModuleDestination = this.AjouterModule(new ModuleDestination(this, "Destination"));
            this.ModuleAssurance = this.AjouterModule(new ModuleAssurance(this, "Assurance"));
        }
    }
}

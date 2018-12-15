namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    using System.Linq;

    public class Retire : Command, IExecutable
    {

        [Inject]
        private IRepository repository;
        
        public Retire(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository
        {
            get { return repository; }
            private set { repository = value; }
        }

        public override string Execute()
        {
            string typeOfDesiredUnitAsString = this.Data[1];
            this.Repository.RemoveUnit(typeOfDesiredUnitAsString);
            return $"{typeOfDesiredUnitAsString} retired!";
        }
    }
}

namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class Add : Command, IExecutable
    {
        [Inject]
        private IRepository repository;

        [Inject]    
        private IUnitFactory unitFactory;

        public Add(string[] data, IRepository repo, IUnitFactory factory) 
            : base(data)
        {
            this.Repository = repo;
            this.UnitFactory = factory;
        }


        public IRepository Repository
        {
            get { return repository; }
            private set { repository = value; }
        }

        public IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            private set { unitFactory = value; }
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}

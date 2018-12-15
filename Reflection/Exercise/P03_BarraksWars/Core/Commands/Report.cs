namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class Report : Command, IExecutable
    {
        [Inject]
        private IRepository repository;

        public Report(string[] data, IRepository repository) 
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
            string output = this.Repository.Statistics;
            return output;
        }
    }
}

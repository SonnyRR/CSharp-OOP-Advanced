namespace P07_InfernoInfinity.Engine.Entities
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter
    {
        private IRepository repo;

        public CommandInterpreter(IRepository repo)
        {
            this.repo = repo;
        }

        public void Execute(string commandName, string[] data)
        {
            var typeOfCommand = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            var command = (ICommand)Activator.CreateInstance(typeOfCommand, data, this.repo);
            command.Execute();
        }
    }
}

namespace TheTankGame.Core
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    using Contracts;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters = inputParameters.Skip(1).ToList();

            string result = string.Empty;


            //var typeOfManager = Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name == "TankManager");

            var typeOfManager = tankManager.GetType();

            var managerMethods = typeOfManager.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            //TODO
            //If this is null what ?
            var currentMethod = managerMethods.FirstOrDefault(x => x.Name.Contains(command));
            result = (string)currentMethod.Invoke(tankManager, new object[] { inputParameters });

            return result;
        }
    }
}
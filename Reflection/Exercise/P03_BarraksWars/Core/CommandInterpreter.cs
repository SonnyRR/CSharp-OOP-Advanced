namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Core.Commands;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {

        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider provider)
        {
            this.serviceProvider = provider;    
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {            
            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName);

            if (commandType == null)
            {
                //TODO
                throw new ArgumentException();
            }

            if (typeof(IExecutable).IsAssignableFrom(commandType) == false)
            {
                //TODO
                throw new InvalidOperationException();
            }

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(InjectAttribute)))    
                .ToArray();

            object[] injectArgs = fieldsToInject
                .Select(x => this.serviceProvider.GetService(x.FieldType))
                .ToArray();

            object[] constrArgs = new object[] { data }.Concat(injectArgs).ToArray();

            var command = (IExecutable)Activator.CreateInstance(commandType, constrArgs);
            return command;
        }
    }
}

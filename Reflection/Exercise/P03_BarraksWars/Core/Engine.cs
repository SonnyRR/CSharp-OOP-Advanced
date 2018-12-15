namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandIntpr;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandIntpr = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    var cmd = this.commandIntpr.InterpretCommand(data,commandName);
                    Console.WriteLine(cmd.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        
    }
}

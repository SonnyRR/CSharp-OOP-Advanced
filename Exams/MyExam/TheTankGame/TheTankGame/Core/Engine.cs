namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var commandArgs = reader.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string outputResult = string.Empty;

                outputResult = this.commandInterpreter.ProcessInput(commandArgs);

                this.writer.WriteLine(outputResult);

                if (commandArgs[0] == "Terminate")
                {
                    this.isRunning = false;
                }
                
            }
        }
    }
}
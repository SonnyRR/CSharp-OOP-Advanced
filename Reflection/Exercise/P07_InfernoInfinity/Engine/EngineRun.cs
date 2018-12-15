namespace P07_InfernoInfinity.Engine
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Gems;
    using Weapons;
    using Entities;
    using System.Linq;

    public class EngineRun
    {
        IRepository repository;
        CommandInterpreter cmd;

        public EngineRun()
        {
            this.repository = new Repository();
        }

        public void Run()
        {
            while (true)
            {
                string[] inputLine = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputLine[0] == "END")
                    break;



                var cmd = (CommandInterpreter)Activator.CreateInstance(typeof(CommandInterpreter), this.repository);
                cmd.Execute(inputLine[0], inputLine.Skip(1).ToArray());

            }
        }
    }
}

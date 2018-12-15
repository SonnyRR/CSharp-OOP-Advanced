
using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;

    /// <summary>
    /// by g0shk0
    /// </summary>
    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IStage stage;

        private IFestivalController festivalController;
        private ISetController setController;


        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer, IStage stage)
        {
            this.reader = reader;
            this.writer = writer;
            this.stage = stage;

            this.festivalController = festivalController;
            this.setController = setController;
        }

        // дайгаз
        public void Run()
        {
            while (true) // for job security
            {
                var input = reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex) // in case we run out of memory
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
            }

            var end = this.festivalController.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var splitted = input.Split(" ".ToCharArray().First());

            var command = splitted.First();
            var args = splitted.Skip(1).ToArray();

            string output = string.Empty;

            if (command == "LetsRock")
            {
                output = this.setController.PerformSets();
            }

            else
            {
                var festivalControlFunc = this.festivalController.GetType()
                    .GetMethods()
                    .FirstOrDefault(x => x.Name == command);

                output = (string)festivalControlFunc.Invoke(this.festivalController, new object[] { args });

            }
            return output;
        }
    }
}
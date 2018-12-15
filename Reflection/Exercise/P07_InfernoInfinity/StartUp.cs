namespace P07_InfernoInfinity
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Engine;
    using Engine.Entities;

    public class StartUp
    {
        public static void Main()
        {
            //EngineRun engine = new EngineRun();
            //engine.Run();

            var attr = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Weapon")
                .GetCustomAttribute<AuthorAttribute>();


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                    break;

                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"Author: {attr.Name}");
                        break;

                    case "Revision":
                        Console.WriteLine($"Revision: {attr.Revision}");
                        break;

                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {attr.Reviewers}");
                        break;

                    case "Description":
                        Console.WriteLine($"Class description: {attr.Description}.");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

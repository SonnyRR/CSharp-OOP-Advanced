namespace _03.StackImplementation
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var stackImplementation = new Stack<int>();

            string[] args = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            foreach (var item in args)
            {
                stackImplementation.Push(int.Parse(item));
            }

            while (true)
            {
                args = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (args[0] == "END")
                    break;

                try
                {
                    if (args[0] == "Push")
                    {
                        stackImplementation.Push(int.Parse(args[1]));
                    }

                    else if (args[0] == "Pop")
                    {
                        stackImplementation.Pop();
                    }
                }

                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var item in stackImplementation)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stackImplementation)
            {
                Console.WriteLine(item);
            }
        }
    }
}

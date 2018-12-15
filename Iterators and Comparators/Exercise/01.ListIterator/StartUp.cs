namespace _01.ListIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] collectionArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ListIterator<string> listIter = 
                new ListIterator<string>(collectionArgs.Skip(1).ToArray());

            while (true)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];
                
                if (command == "END")
                {
                    break;
                }

                try
                {
                    if (command == "HasNext")
                    {
                        Console.WriteLine(listIter.HasNext());
                    }

                    else if (command == "Print")
                    {
                        listIter.Print();
                    }

                    else if (command == "Move")
                    {
                        Console.WriteLine(listIter.Move());
                    }

                    else if (command == "PrintAll")
                    {
                        listIter.PrintAll();
                        Console.WriteLine();
                    }
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}

namespace _06.Strategy_pattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {

            int numberOfLines = int.Parse(Console.ReadLine());

            HashSet<Person> firstSet = new HashSet<Person>();
            SortedSet<Person> secondSet = new SortedSet<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] inputLine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputLine[0];
                int age = int.Parse(inputLine[1]);

                Person currentPerson = new Person(name, age);

                firstSet.Add(currentPerson);
                secondSet.Add(currentPerson);
            }

            Console.WriteLine(firstSet.Count);
            Console.WriteLine(secondSet.Count);
        }
    }
}

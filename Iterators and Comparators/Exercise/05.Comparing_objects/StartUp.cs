namespace _05.Comparing_objects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] inputLine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputLine[0] == "END")
                    break;

                string name = inputLine[0];
                int age = int.Parse(inputLine[1]);
                string town = inputLine[2];

                Person currentPerson = new Person(name, age, town);
                people.Add(currentPerson);
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[index];

            int equalPeople = 0;

            people.ForEach(x =>
            {
                if (x.CompareTo(personToCompare) == 0)
                {
                    equalPeople++;
                }
            });

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {people.Count - equalPeople} {people.Count}");
            }

            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}

namespace _01.Generic_Box_of_string
{
    using System;
    using GenericsBox;
    public class StartUp
    {
        public static void Main()
        {
            int inputLines = int.Parse(Console.ReadLine());
            BoxCollection<string> stringBox = new BoxCollection<string>();

            for (int i = 0; i < inputLines; i++)
            {
                stringBox.Add(Console.ReadLine());
            }

            Console.WriteLine(stringBox);
        }
    }
}

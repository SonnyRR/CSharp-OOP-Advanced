namespace _05.Generic_count_method
{
    using System;
    using GenericsBox;
    public class StartUp
    {
        public static void Main()
        {
            int inputLines = int.Parse(Console.ReadLine());
            BoxCollection<double> stringBox = new BoxCollection<double>();

            for (int i = 0; i < inputLines; i++)
            {
                stringBox.Add(double.Parse(Console.ReadLine()));
            }

            double itemToCompare = double.Parse(Console.ReadLine());
            int count = stringBox.GetGreaterThan(itemToCompare);
            //Console.WriteLine(stringBox);
            Console.WriteLine(count);
        }
    }
}

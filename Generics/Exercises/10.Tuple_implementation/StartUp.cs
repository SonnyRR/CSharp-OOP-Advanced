namespace _10.Tuple_implementation
{
    using System;
    using Models;
    public class StartUp
    {
        public static void Main()
        {
            string[] firstLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Models.Threeuple<string, string, string> firstThreeuple =
                new Models.Threeuple<string, string, string>($"{firstLine[0]} {firstLine[1]}", firstLine[2], firstLine[3]);

            string[] secondLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Models.Threeuple<string, double, bool> secondThreeuple =
                new Models.Threeuple<string, double, bool>(secondLine[0], double.Parse(secondLine[1]), secondLine[2] == "drunk" ? true : false);

            string[] thirdLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Models.Threeuple<string, double, string> thirdThreeuple =
                new Models.Threeuple<string, double, string>(thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]);

            Console.WriteLine($"{firstThreeuple.Item1} -> {firstThreeuple.Item2} -> {firstThreeuple.Item3}");
            Console.WriteLine($"{secondThreeuple.Item1} -> {secondThreeuple.Item2} -> {secondThreeuple.Item3}");
            Console.WriteLine($"{thirdThreeuple.Item1} -> {thirdThreeuple.Item2} -> {thirdThreeuple.Item3}");

        }
    }
}

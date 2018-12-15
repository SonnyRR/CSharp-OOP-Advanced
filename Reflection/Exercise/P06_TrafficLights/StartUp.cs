namespace P06_TrafficLights
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var lights = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new TrafficLight(x))
                .ToList();

            int numberOfRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotations; i++)
            {
                lights.ForEach(x => x.ChangeSingal());
                Console.WriteLine(string.Join(' ', lights));
            }
        }
    }
}
